import { Component, OnInit } from '@angular/core';

import { VehicleType } from '@app/models/VehicleType';

import { NgxSpinnerService } from 'ngx-spinner';
import { VehicletypesService } from '@app/services/vehicletypes.service';

@Component({
	selector: 'app-vehicletypes-list',
	templateUrl: './vehicletypes-list.component.html',
	styleUrls: ['./vehicletypes-list.component.scss'],
})
export class VehicletypesListComponent implements OnInit {
	public vehicleTypes: VehicleType[] = [];

	constructor(
		private vehicleTypesService: VehicletypesService,
		private spinner: NgxSpinnerService
	) {}

	ngOnInit(): void {
		this.getVehicleTypes();
		/** spinner starts on init */
		this.spinner.show();

		// setTimeout(() => {
		// 	/** spinner ends after 5 seconds */
		// 	this.spinner.hide();
		// }, 5000);
	}

	public getVehicleTypes(): void {
		this.vehicleTypesService.getAllVehicleTypes().subscribe({
			next: (_vehicleTypes: VehicleType[]) => this.vehicleTypes = _vehicleTypes,
			error: (error: any) => {
				this.spinner.hide();
				console.log(error);
			},
			complete: () => this.spinner.hide()
		});
	}
}
