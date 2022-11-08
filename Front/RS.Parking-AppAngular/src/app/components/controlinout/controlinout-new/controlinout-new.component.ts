import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ControlInOut } from '@app/models/ControlInOut';
import { discountTypesList } from '@app/models/DiscountTypes.enum';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-controlinout-new',
	templateUrl: './controlinout-new.component.html',
	styleUrls: ['./controlinout-new.component.scss'],
})
export class ControlinoutNewComponent implements OnInit {

	form: FormGroup;
	discountTypes = discountTypesList;
	controlInOut = {} as ControlInOut;

	get f(): any {
		return this.form.controls;
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	constructor(
		private fb: FormBuilder,
		private controlInOutService: ControlInOutService,
		private router: Router,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.validation();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public resetForm(): void {
		this.form.reset();
		this.myInputFocus.nativeElement.focus();
	}

	public validation(): void {
		this.form = this.fb.group({
			active: [true, [Validators.required]],
			percentage: ['0', [Validators.required, Validators.min(0.01), Validators.max(9999999999999) ]],
			accord: [0, [Validators.required, Validators.min(0), , Validators.max(2) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]]
		});
	}

	public saveControlInOut(): void {
		this.spinner.show();
		if (this.form.valid) {
			this.controlInOut = Object.assign({}, this.controlInOut, this.form.value);
			this.controlInOutService.saveControlInOut(this.controlInOut).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
	}

	processSuccess(response: any) {
		this.form.reset();
		let toast = this.toastr.success('Control In Out', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.router.navigate(['/controlinout/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error(`Error saving Control In Out. \n${fail}`, 'Error!');
		this.spinner.hide();
	}

}
