import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ControlInOut } from '@app/models/ControlInOut';
import { discountTypesList } from '@app/models/DiscountTypes.enum';
import { VehicleType } from '@app/models/VehicleType';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { VehicletypesService } from '@app/services/vehicletypes.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-controlinout-edit',
	templateUrl: './controlinout-edit.component.html',
	styleUrls: ['./controlinout-edit.component.scss'],
})
export class ControlinoutEditComponent implements OnInit {

	form: FormGroup;
	controlInOutId = 0;
	accordTypeId = 0;
	discountTypes = discountTypesList;
	vehicleTypeList: VehicleType[] = [];
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
		private vehicleTypeService: VehicletypesService,
		private controlInOutService: ControlInOutService,
		private router: Router,
		private activatedRouter: ActivatedRoute,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.LoadVehicleTypeList();
		this.LoadControlInOut();
		this.Validation();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public Validation(): void {
		this.form = this.fb.group({
			licensePlate: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(7)]],
			accordTypeId: [0 + '', [Validators.required]],
			vehicleTypeId: [0 + '', [Validators.required]],
			dateTimeIn: ['' , [Validators.required]],
			dateTimeOut: ['' , [Validators.required]]
		});
	}

	public resetForm(): void {
		this.form.reset();
		this.LoadControlInOut();
		this.myInputFocus.nativeElement.focus();
	}

	public LoadVehicleTypeList(): void {
		this.spinner.show();
		this.vehicleTypeService.getAllVehicleTypes().subscribe({
			next: (_vehicleTypes: VehicleType[]) => this.vehicleTypeList = _vehicleTypes,
			error: (error: any) => { this.toastr.error(`Error loading VehicleTypes.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public LoadControlInOut(): void {
		this.controlInOutId = +this.activatedRouter.snapshot.paramMap.get('id');
		if (this.controlInOutId !== null && this.controlInOutId !== 0) {
			this.spinner.show();
			this.controlInOutService.getControlInOutById(this.controlInOutId).subscribe({
				next: (controlInOut: ControlInOut) => {
					//this.controlInOut = { dateTimeOut: new Date(), ... controlInOut };
					this.controlInOut = { ... controlInOut };
					this.form.patchValue(this.controlInOut);
				},
				error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
				complete: () => this.spinner.hide()
			});
		}
	}

	public updateControlInOut(): void {
		this.spinner.show();
		if (this.form.valid) {
			this.controlInOut = Object.assign({}, this.controlInOut, this.form.value);
			this.controlInOutService.updateControlInOut(this.controlInOut).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
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
