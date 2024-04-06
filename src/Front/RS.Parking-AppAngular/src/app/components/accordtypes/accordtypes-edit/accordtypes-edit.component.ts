import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { DiscountTypeEnum } from '@app/models/DiscountTypes.enum';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-accordtypes-edit',
	templateUrl: './accordtypes-edit.component.html',
	styleUrls: ['./accordtypes-edit.component.scss'],
})
export class AccordTypesEditComponent implements OnInit {

	accordFormGroup: FormGroup;
	accordTypeId: number;
	public discountTypeEnum: DiscountTypeEnum[] = [];
	public accordType = {} as AccordType;

	get f(): any {
		return this.accordFormGroup.controls;
	}

	constructor(
		private fb: FormBuilder,
		private accordTypesService: AccordTypesService,
		private router: Router,
		private activatedRouter: ActivatedRoute,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.LoadDiscountTypeEnum();
		this.loadAccordType();
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
			discountTypeId: ['0', [Validators.required, Validators.min(0), Validators.max(2) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]]
		});
	}

	public resetForm(): void {
		this.accordFormGroup.reset();
		this.loadAccordType();
		this.myInputFocus.nativeElement.focus();
	}

	public cssValidator(accordFormGroupControl: FormControl): any {
		return {'is-invalid': accordFormGroupControl.errors && accordFormGroupControl.touched};
	}

	public LoadDiscountTypeEnum(): void {
		this.spinner.show();
		this.accordTypesService.getDiscountTypeEnum().subscribe({
			next: (_discountTypes: DiscountTypeEnum[]) => this.discountTypeEnum = _discountTypes,
			error: (error: any) => { this.toastr.error('Error loading DiscountTypeEnum.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public loadAccordType(): void {
		this.accordTypeId = +this.activatedRouter.snapshot.paramMap.get('id');
		if (this.accordTypeId !== null && this.accordTypeId !== 0) {
			this.spinner.show();
			this.accordTypesService.getAccordTypeById(this.accordTypeId).subscribe({
				next: (_accordType: AccordType) => {
					this.accordType = { ... _accordType };
					this.accordFormGroup.patchValue(this.accordType);
				},
				error: (error: any) => { this.toastr.error(`Error loading AccordType.\n${error}`, 'Error!'); },
				complete: () => this.spinner.hide()
			});
		}
	}

	public updateAccordType(): void {
		this.spinner.show();
		if (this.accordFormGroup.valid) {
			this.accordType = Object.assign({}, this.accordType, this.accordFormGroup.value);
			this.accordTypesService.updateAccordType(this.accordType).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
	}

	processSuccess(response: any) {
		let toast = this.toastr.success('Accord', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
			this.router.navigate(['/accordtypes/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error(`Error saving AccordType.\n${fail}`, 'Error');
	}
}
