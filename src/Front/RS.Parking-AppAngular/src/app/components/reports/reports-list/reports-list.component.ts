import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { ControlInOut } from '@app/models/ControlInOut';

@Component({
	selector: 'app-reports-list',
	templateUrl: './reports-list.component.html',
	styleUrls: ['./reports-list.component.css'],
	providers: [DatePipe]
})
export class ReportsListComponent implements OnInit {

	public form: FormGroup;
	public controlInOutList: ControlInOut[] = [];

	constructor(
		private controlInOutService: ControlInOutService,
		private formBuilder: FormBuilder,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
		private localeService: BsLocaleService,
		private datePipe: DatePipe)
		{
			this.localeService.use('pt-br');
		}

	ngOnInit() {
		//this.searchReport();
		this.Validation();
	}

	get bsConfig(): any {
		return {
			isAnimated: true,
			adaptivePosition: true,
			containerClass: 'theme-dark-blue',
			showWeekNumbers: false
		};
	}

	public Validation(): void {
		const todayLessOneDay = new Date();
    	todayLessOneDay.setDate(todayLessOneDay.getDate() - 1); // Subtrai 1 dia
		//console.log(todayLessOneDay)
		this.form = this.formBuilder.group({
			dateSearch: [todayLessOneDay, [Validators.required]]
		});
	}

	public searchReport(): void {
		const dateSearchValue = this.form.get('dateSearch').value;
		//console.log('Valor de dateSearch:', dateSearchValue);
		let dateSearchValueTransform =this.datePipe.transform(dateSearchValue, 'yyyy-MM-dd');
		//console.log(dateSearchValueTransform);

		// OK
		// let dateNow=new Date();
		// let latest_date =this.datePipe.transform(dateNow, 'yyyy-MM-dd');
		// console.log(dateNow);
		// console.log(latest_date);

		if (this.form.valid) {
			this.spinner.show();
			this.controlInOutService.getControlInOutByRange(dateSearchValueTransform).subscribe({
				next: (_controlInOutList: ControlInOut[]) => {
					this.controlInOutList = _controlInOutList;
				},
				error: (error: any) => this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'),
				complete: () => { this.spinner.hide(); }
			});
			this.spinner.hide();
		}
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
