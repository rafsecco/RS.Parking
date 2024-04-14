import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { ControlInOut } from '@app/models/ControlInOut';
import { VehicleType } from '@app/models/VehicleType';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { VehicletypesService } from '@app/services/vehicletypes.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-controlinout-edit',
	templateUrl: './controlinout-edit.component.html',
	styleUrls: ['./controlinout-edit.component.scss'],
})
export class ControlinoutEditComponent implements OnInit {

	modalRef: BsModalRef;
	form: FormGroup;
	controlInOut = {} as ControlInOut;
	vehicleType = {} as VehicleType;
	accordTypesList: AccordType[] = [];
	accordTypeId = 0;

	formatter = new Intl.NumberFormat('pt-BR', {
		style: 'currency',
		currency: 'BRL',

		// These options are needed to round to whole numbers if that's what you want.
		//minimumFractionDigits: 0, // (this suffices for whole numbers, but will print 2500.10 as $2,500.1)
		//maximumFractionDigits: 0, // (causes 2500.99 to be printed as $2,501)
		//console.log(formatter.format(2500)); /* $2,500.00 */
	});

	// formatter = new Intl.NumberFormat('en-US', {
	// 	style: 'currency',
	// 	currency: 'USD',
	// });

	get f(): any {
		return this.form.controls;
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	constructor(
		private fb: FormBuilder,
		private vehicleTypesService: VehicletypesService,
		private accordTypesService: AccordTypesService,
		private controlInOutService: ControlInOutService,
		private router: Router,
		private activatedRouter: ActivatedRoute,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.LoadControlInOut();
		this.Validation();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public Validation(): void {
		this.form = this.fb.group({
			licensePlate: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(7)]],
			vehicleTypeId: [0 + '', [Validators.required]],
			accordTypeId: ['', [Validators.required, Validators.min(1)]],
			dateTimeIn: ['' , [Validators.required]],
			dateTimeOut: ['' , [Validators.required]]
		});
	}

	public LoadControlInOut(): void {
		this.spinner.show();
		let controlInOutId = +this.activatedRouter.snapshot.paramMap.get('id');
		if (controlInOutId !== null && controlInOutId !== 0) {
			this.spinner.show();
			this.controlInOutService.getControlInOutById(controlInOutId).subscribe({
				next: (controlInOut: ControlInOut) => {
					this.controlInOut = {... controlInOut, dateTimeOut: new Date(Date.now()) };
					this.LoadVehicleType();
					this.form.patchValue(this.controlInOut);
					this.LoadAccordTypeList();
				},
				error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
				complete: () => this.spinner.hide()
			});
		}
	}

	public LoadVehicleType(): void {
		let vehicleTypeId = this.controlInOut.vehicleTypeId;
		if (vehicleTypeId !== null && vehicleTypeId !== 0) {
			this.spinner.show();
			this.vehicleTypesService.getVehicleTypeById(vehicleTypeId).subscribe({
				next: (vehicleType: VehicleType) => {
					this.vehicleType = { ... vehicleType };
					this.controlInOut.vehicleType = { ... vehicleType };
				},
				error: (error: any) => { this.toastr.error(`Error loading VehicleType.\n${error}`, 'Error!'); },
				complete: () => this.spinner.hide()
			});
		}
	}

	public LoadAccordTypeList(): void {
		this.spinner.show();
		this.accordTypesService.getAllAccordTypes().subscribe({
			next: (_accordTypes: AccordType[]) => this.accordTypesList = _accordTypes,
			error: (error: any) => { this.toastr.error(`Error loading AccordType.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public getAccordTypeById(id: number): void {
		this.spinner.show();
		this.accordTypesService.getAccordTypeById(id).subscribe({
			next: (_accordType: AccordType) => this.controlInOut.accordType = _accordType,
			error: (error: any) => { this.toastr.error(`Error loading AccordType.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	getVehicleDescription(): string {
		return `${this.vehicleType.id} - ${this.vehicleType.description}`;
	}

	getChangeAccordTypeValue(val:string): void {
		this.accordTypeId = Number(val);
		this.getAccordTypeById(this.accordTypeId);
	}

	getAccordTypeDescription(): string {
		let accordType = {} as AccordType;
		accordType = this.accordTypesList.find(x => x.id == this.accordTypeId)
		return `${accordType.id} - ${accordType.description}`;
	}

	public getPrice(): string {

		//double tolerance = (double)Convert.ToInt32(ConfigurationManager.AppSettings.Get("Tolerance")) / 60;    // 0.0833333333333333;	//5 min defatul
		const tolerance = 5 / 60; //5 min defatul

		let dateIn = new Date(this.controlInOut.dateTimeIn);
		let dateOut = new Date(this.controlInOut.dateTimeOut);

		// let dateIn = new Date("2022-11-19T06:00:00.000000");
		// let dateOut = new Date("2022-11-19T07:00:00.000000");

		//var diffDays = dateOut.getDate() - dateIn.getDate();
		let totalHours = Math.abs(dateOut.getTime() - dateIn.getTime()) / 36e5; //36e5 is the scientific notation for 60*60*1000
		let rest = totalHours - Math.floor(totalHours);
		let totalHoursRounded = (rest > tolerance) ? Math.ceil(totalHours) : Math.floor(totalHours);

		let returnValue:string;
		let totalCost:number;

		switch (this.controlInOut.accordType.discountTypeId) {
			case 1:	// Total
				totalHoursRounded /= this.controlInOut.accordType.percentage / 100;
				returnValue = `${totalHoursRounded} Tickets`;
				break;
			case 2:	// First Hour
				let firstHourCost = this.controlInOut.vehicleType.cost * (this.controlInOut.accordType.percentage / 100);
				let totalHoursCost = totalHoursRounded * this.controlInOut.vehicleType.cost;
				totalCost = totalHoursCost - firstHourCost;
				returnValue = this.formatter.format(totalCost);
				break;
			default:	// No Discount
				totalCost = totalHoursRounded * this.controlInOut.vehicleType.cost;
				returnValue = this.formatter.format(totalCost);
		}

		return returnValue;
	}



	openModalView(event: any, template: TemplateRef<any>): void {
		event.stopPropagation();
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	public checkOutConfirmed(): void {
		this.spinner.show();
		if (this.form.valid) {
			this.controlInOut = Object.assign({}, this.controlInOut, this.form.value);
			this.controlInOutService.updateControlInOut(this.controlInOut).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => { this.spinner.hide(); this.modalRef.hide(); }
			});
		}

	}

	processSuccess(response: any) {
		let toast = this.toastr.success('Control In Out', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.router.navigate(['/controlinout/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error(`Error saving Control In Out.\n${fail}`, 'Error');
	}

}
