import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
	selector: 'app-vehicletypes-new',
	templateUrl: './vehicletypes-new.component.html',
	styleUrls: ['./vehicletypes-new.component.scss'],
})
export class VehicletypesNewComponent implements OnInit {

	form: FormGroup;

	get f(): any {
		return this.form.controls;
	}

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {
		this.validation();
	}

	// id: number;
	// active: boolean
	// dateCreated: Date;
	// cost: number;
	// description: string;

	public validation(): void {
		this.form = this.fb.group({
			//id: ['true'],
			active: ['true'],
			//dateCreated: [''],
			cost: ['0', [Validators.required, Validators.min(0.01), Validators.max(9999999999999) ]],
			description: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]]
		});
	}

	public resetForm(): void {
		this.form.reset();
	}

	public saveVehicleType(): void {

	}

}
