import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { DiscountTypeEnum } from '@app/models/DiscountTypes.enum';
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
	public accordType = {} as AccordType;
	public discountTypeEnum: DiscountTypeEnum[] = [];

	constructor(
		private fb: FormBuilder,
		private accordTypesService: AccordTypesService,
		private router: Router,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.LoadDiscountTypeEnum();
		this.validation();
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	get f(): any {
		return this.accordFormGroup.controls;
	}

	public LoadDiscountTypeEnum(): void {
		this.spinner.show();
		this.accordTypesService.getDiscountTypeEnum().subscribe({
			next: (_discountTypes: DiscountTypeEnum[]) => this.discountTypeEnum = _discountTypes,
			error: (error: any) => { this.toastr.error('Error loading DiscountTypeEnum.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
		this.spinner.hide();
	}

	public validation(): void {
		this.accordFormGroup = this.fb.group({
			active: [true, [Validators.required]],
			percentage: [null, [Validators.required, Validators.min(0), Validators.max(100) ]],
			accord: ['0', [Validators.required, Validators.min(0), , Validators.max(2) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
			discountTypeId: [0, [Validators.required, Validators.min(0), Validators.max(2) ]],
		});
	}

	public resetForm(): void {
		this.accordFormGroup.reset({ active: true });
		this.LoadDiscountTypeEnum();
		this.validation();
		this.myInputFocus.nativeElement.focus();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public saveAccordType(): void {
		this.spinner.show();
		if (this.accordFormGroup.valid) {
			this.accordType = Object.assign({}, this.accordType, this.accordFormGroup.value);
			this.accordType.percentage = this.accordType.percentage / 100;
			this.accordTypesService.saveAccordType(this.accordType).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
		this.spinner.hide();
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
