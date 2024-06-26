import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { VehicleType } from '@app/models/VehicleType';

import { VehicletypesService } from '@app/services/vehicletypes.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-vehicletypes-new',
	templateUrl: './vehicletypes-new.component.html',
	styleUrls: ['./vehicletypes-new.component.scss'],
})
export class VehicletypesNewComponent implements OnInit {

	form: FormGroup;
	vehicleType = {} as VehicleType;

	get f(): any {
		return this.form.controls;
	}

	constructor(
		private fb: FormBuilder,
		private vehicletypesService: VehicletypesService,
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
		this.form = this.fb.group({
			active: [true, [Validators.required]],
			cost: ['0', [Validators.required, Validators.min(0.01), Validators.max(9999999999999.99) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]]
		});
	}

	public resetForm(): void {
		this.form.reset({ active: true });
		this.myInputFocus.nativeElement.focus();
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public saveVehicleType(): void {
		this.spinner.show();
		if (this.form.valid) {
			this.vehicleType = Object.assign({}, this.vehicleType, this.form.value);
			this.vehicletypesService.saveVehicleType(this.vehicleType).subscribe({
				next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
		this.spinner.hide();
	}

	processSuccess(response: any) {
		this.form.reset();
		let toast = this.toastr.success('Vehicle', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.router.navigate(['/vehicletypes/list']);
			});
		}
	}

	processFailure(fail: any) {
		this.toastr.error('Error saving VehicleType', 'Error');
	}

}
