import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { discountTypesList } from '@app/models/DiscountTypes.enum';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-accordtypes-new',
	templateUrl: './accordtypes-new.component.html',
	styleUrls: ['./accordtypes-new.component.scss'],
})
export class AccordTypesNewComponent implements OnInit {

	accordFormGroup: FormGroup;
	accordType = {} as AccordType;
	discountTypes = discountTypesList;

	get f(): any {
		return this.accordFormGroup.controls;
	}

	constructor(
		private fb: FormBuilder,
		private accordTypesService: AccordTypesService,
		private router: Router,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.validation();
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	public validation(): void {
		this.accordFormGroup = this.fb.group({
			active: [true, [Validators.required]],
			percentage: ['0', [Validators.required, Validators.min(0.00), Validators.max(9999999999999) ]],
			accord: ['0', [Validators.required, Validators.min(0), , Validators.max(2) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]]
		});
	}

	public resetForm(): void {
		this.accordFormGroup.reset({ active: true });
		this.myInputFocus.nativeElement.focus();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public saveAccordType(): void {
		this.spinner.show();
		if (this.accordFormGroup.valid) {
			this.accordType = Object.assign({}, this.accordType, this.accordFormGroup.value);
			this.accordTypesService.saveAccordType(this.accordType).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
	}

	processSuccess(response: any) {
		this.accordFormGroup.reset();
		let toast = this.toastr.success('Accord', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.router.navigate(['/accordtypes/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error('Error saving AccordType', 'Error');
		this.spinner.hide();
	}
}
