import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccordType } from '@app/models/AccordType';
import { ControlInOut } from '@app/models/ControlInOut';
import { VehicleType } from '@app/models/VehicleType';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { VehicletypesService } from '@app/services/vehicletypes.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-reports-list',
	templateUrl: './reports-list.component.html',
	styleUrls: ['./reports-list.component.css'],
	providers: [DatePipe]
})
export class ReportsListComponent implements OnInit {

	form: FormGroup;
	public controlInOutList: ControlInOut[] = [];
	public accordTypes: AccordType[] = [];
	public vehicleTypes: VehicleType[] = [];

	formatter = new Intl.NumberFormat('pt-BR', {
		style: 'currency',
		currency: 'BRL',

		// These options are needed to round to whole numbers if that's what you want.
		//minimumFractionDigits: 0, // (this suffices for whole numbers, but will print 2500.10 as $2,500.1)
		//maximumFractionDigits: 0, // (causes 2500.99 to be printed as $2,501)
		//console.log(formatter.format(2500)); /* $2,500.00 */
	});

	get f(): any {
		return this.form.controls;
	}

	get bsConfig(): any {
		return {
			// isAnimated: true,
			adaptivePosition: true,
			containerClass: 'theme-dark-blue',
			showWeekNumbers: false
		};
	}

	constructor(
		private fb: FormBuilder,
		private localeService: BsLocaleService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
		private datePipe: DatePipe,
		private controlInOutService: ControlInOutService,
		private vehicleTypesService: VehicletypesService,
		private accordTypesService: AccordTypesService
		)
		{
			this.localeService.use('pt-br');
		}

	ngOnInit() {
		this.Validation();
		this.LoadAccordTypeList();
		this.LoadVehicleTypeList();
	}

	public Validation(): void {
		this.form = this.fb.group({
			dateSearch: ['', [Validators.required]]
		});
	}

	public LoadAccordTypeList(): void {
		this.spinner.show();
		this.accordTypesService.getAllAccordTypes().subscribe({
			next: (_accordTypes: AccordType[]) => this.accordTypes = _accordTypes,
			error: (error: any) => { this.toastr.error('Error loading AccordType.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public LoadVehicleTypeList(): void {
		this.spinner.show();
		this.vehicleTypesService.getAllVehicleTypes().subscribe({
			next: (_vehicleTypes: VehicleType[]) => this.vehicleTypes = _vehicleTypes,
			error: (error: any) => { this.toastr.error('Error loading VehicleType.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public searchReport(): void {
		let date = new Date(2022, 10, 25);
		//console.log(this.datePipe.transform(date, 'yyyy-MM-dd'));
		this.spinner.show();
		if (this.form.valid) {
			this.controlInOutService.getControlInOutByRange(this.datePipe.transform(date, 'yyyy-MM-dd')).subscribe({
				next: (_controlInOutList: ControlInOut[]) => { this.controlInOutList = _controlInOutList; },
				error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); this.spinner.hide(); },
				complete: () => { this.spinner.hide(); }
			});
		}
	}

	public getPrice(id:number): string {

		let controlInOut = this.controlInOutList.find(x => x.id == id);

		if (controlInOut.dateTimeOut === null) { return 'N/A'; }

		let accordType:AccordType = this.accordTypes.find(x => x.id == controlInOut.accordType.id);
		let vehicleType:VehicleType = this.vehicleTypes.find(x => x.id == controlInOut.vehicleType.id);

		// let dateIn = new Date(this.controlInOut.dateTimeIn);
		// let dateOut = new Date(this.controlInOut.dateTimeOut);
		let dateIn = new Date(controlInOut.dateTimeIn);
		let dateOut = new Date(controlInOut.dateTimeOut);

		console.log(`DateIn: ${typeof dateIn}\nDateOut: ${typeof dateOut}`);
		console.log(`DateIn: ${typeof controlInOut.dateTimeIn}\nDateOut: ${typeof controlInOut.dateTimeOut}`);

		//double tolerance = (double)Convert.ToInt32(ConfigurationManager.AppSettings.Get("Tolerance")) / 60;    // 0.0833333333333333;	//5 min defatul
		const tolerance = 5 / 60; //5 min defatul

		//var diffDays = dateOut.getDate() - dateIn.getDate();
		let totalHours = Math.abs(controlInOut.dateTimeOut.getTime() - controlInOut.dateTimeIn.getTime()) / 36e5; //36e5 is the scientific notation for 60*60*1000
		let rest = totalHours - Math.floor(totalHours);
		let totalHoursRounded = (rest > tolerance) ? Math.ceil(totalHours) : Math.floor(totalHours);
		let returnValue:string;
		let totalCost:number;

		switch (controlInOut.accordType.id) {
			case 1:	// Total
				totalHoursRounded /= accordType.percentage / 100;
				returnValue = `${totalHoursRounded} Tickets`;
				break;
			case 2:	// First Hour
				let firstHourCost = vehicleType.cost * (accordType.percentage / 100);
				let totalHoursCost = totalHoursRounded * vehicleType.cost;
				totalCost = totalHoursCost - firstHourCost;
				returnValue = this.formatter.format(totalCost);
				break;
			default:	// No Discount
				totalCost = totalHoursRounded * vehicleType.cost;
				returnValue = this.formatter.format(totalCost);
		}

		return returnValue;
	}


	//https://stackoverflow.com/questions/35138424/how-do-i-download-a-file-with-angular2-or-greater
	//https://www.youtube.com/watch?v=tAIxMGUEMqE

	// public downLoadReport(): void {
	// 	this._reportService.getReport().subscribe(data => this.downloadFile(data)),//console.log(data),
	// 		error => console.log('Error downloading the file.'),
	// 		() => console.info('OK');
	// }

	// downloadFile(data: Response) {
	// 	const blob = new Blob([data], { type: 'text/csv' });
	// 	const url= window.URL.createObjectURL(blob);
	// 	window.open(url);
	// }

}
