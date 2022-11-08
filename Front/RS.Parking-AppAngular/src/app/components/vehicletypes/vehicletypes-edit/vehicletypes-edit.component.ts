import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleType } from '@app/models/VehicleType';
import { VehicletypesService } from '@app/services/vehicletypes.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-vehicletypes-edit',
	templateUrl: './vehicletypes-edit.component.html',
	styleUrls: ['./vehicletypes-edit.component.scss'],
})
export class VehicletypesEditComponent implements OnInit {

	form: FormGroup;
	vehicleType = {} as VehicleType;
	vehicleTypeId: number;

	get f(): any {
		return this.form.controls;
	}

	constructor(
		private fb: FormBuilder,
		private vehicleTypesService: VehicletypesService,
		private router: Router,
		private activatedRouter: ActivatedRoute,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.loadVehicleType();
		this.validation();
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	public validation(): void {
		this.form = this.fb.group({
			active: [true, [Validators.required]],
			cost: ['0', [Validators.required, Validators.min(0.01), Validators.max(9999999999999) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
			id: ['',''],
			dateCreated: ['','']
		});
	}

	public resetForm(): void {
		this.form.reset({ active: true });
		this.loadVehicleType();
		this.myInputFocus.nativeElement.focus();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public loadVehicleType(): void {
		this.vehicleTypeId = +this.activatedRouter.snapshot.paramMap.get('id');
		if (this.vehicleTypeId !== null && this.vehicleTypeId !== 0) {
			this.spinner.show();
			this.vehicleTypesService.getVehicleTypeById(this.vehicleTypeId).subscribe({
				next: (vehicleType: VehicleType) => {
					this.vehicleType = { ... vehicleType };
					this.form.patchValue(this.vehicleType);
				},
				error: (error: any) => {
					this.toastr.error('Error loading VehicleType.', 'Error!');
				},
				complete: () => this.spinner.hide()
			});
		}
	}

	public updateVehicleType(): void {
		this.spinner.show();
		if (this.form.valid) {
			this.vehicleType = Object.assign({}, this.vehicleType, this.form.value);
			this.vehicleTypesService.updateVehicleType(this.vehicleType).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
	}

	processSuccess(response: any) {
		let toast = this.toastr.success('Vehicle', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
			this.router.navigate(['/vehicletypes/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error('Error saving VehicleType', 'Error');
		this.spinner.hide();
	}
}
