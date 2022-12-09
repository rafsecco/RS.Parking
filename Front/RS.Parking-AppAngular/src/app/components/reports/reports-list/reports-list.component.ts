import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
	selector: 'app-reports-list',
	templateUrl: './reports-list.component.html',
	styleUrls: ['./reports-list.component.css'],
})
export class ReportsListComponent implements OnInit {

	form: FormGroup;

	get f(): any {
		return this.form.controls;
	}

	get bsConfig(): any {
		return {
			isAnimated: true,
			adaptivePosition: true,
			containerClass: 'theme-dark-blue',
			showWeekNumbers: false
		};
	}

	constructor(
		private fb: FormBuilder,
		private localeService: BsLocaleService,
		private spinner: NgxSpinnerService)
		{
			this.localeService.use('pt-br');
		}

	ngOnInit() {
		this.Validation();
	}

	public Validation(): void {
		this.form = this.fb.group({
			dateRange: ['', [Validators.required]]
		});
	}

	public searchReport(): void {
		this.spinner.show();
		if (this.form.valid) {

			// this.vehicleType = Object.assign({}, this.vehicleType, this.form.value);
			// this.vehicletypesService.saveVehicleType(this.vehicleType).subscribe({
			// 	next: success => this.processSuccess(success),
			// 	error: failure => this.processFailure(failure),
			// 	complete: () => this.spinner.hide()
			// });

		}
	}

}
