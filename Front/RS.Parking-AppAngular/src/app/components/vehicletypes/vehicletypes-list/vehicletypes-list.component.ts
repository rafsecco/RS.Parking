import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { VehicleType } from '@app/models/VehicleType';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { VehicletypesService } from '@app/services/vehicletypes.service';



@Component({
	selector: 'app-vehicletypes-list',
	templateUrl: './vehicletypes-list.component.html',
	styleUrls: ['./vehicletypes-list.component.scss'],
})
export class VehicletypesListComponent implements OnInit {

	modalRef: BsModalRef;
	message?: string;
	vehicleTypeId: number;
	public vehicleTypes: VehicleType[] = [];

	constructor(
		private modalService: BsModalService,
		private toastr: ToastrService,
		private vehicleTypesService: VehicletypesService,
		private spinner: NgxSpinnerService
	) {}

	ngOnInit(): void {
		this.LoadVehicleTypeList();
		/** spinner starts on init */
		//this.spinner.show();

		// setTimeout(() => {
		// 	/** spinner ends after 5 seconds */
		// 	this.spinner.hide();
		// }, 5000);
	}

	public LoadVehicleTypeList(): void {
		this.spinner.show();
		this.vehicleTypesService.getAllVehicleTypes().subscribe({
			next: (_vehicleTypes: VehicleType[]) => this.vehicleTypes = _vehicleTypes,
			error: (error: any) => {
				console.log(error);
			},
			complete: () => this.spinner.hide()
		});
	}

	openModal(template: TemplateRef<any>, vehicleTypeId: number): void {
		this.vehicleTypeId = vehicleTypeId;
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	confirmDeleteVehicleType(): void {
		this.message = 'Confirmed!';
		this.modalRef?.hide();
		this.spinner.show();
		this.vehicleTypesService.deleteVehicleType(this.vehicleTypeId)
			.subscribe({
				next: (success: any) => this.processDeleteSuccess(success),
				error: (failure: any) => this.processDeleteFailure(failure)
				// complete: () => this.spinner.hide()
			}).add(() => this.spinner.hide());

		// 	(result: any) => {
		// 		//this.toastr.success('Vehicle successfully deleted!', 'Deleted!');
		// 		// console.log(result);
		// 		// if (result.message === 'Deleted!') {
		// 		// 	this.toastr.success('Vehicle successfully deleted!', 'Deleted!');
		// 		this.LoadVehicleTypeList();
		// 		// }
		// 	},
		// 	(error: any) => {
		// 		// console.error(error);
		// 		// this.toastr.error(`Error when trying to delete the vehicle ${this.vehicleTypeId}`, 'Error');
		// 	},
		// 	() => this.spinner.hide()
		// );
		// this.spinner.hide()
	}

	declineDeleteVehicleType(): void {
		this.message = 'Declined!';
		this.modalRef?.hide();
	}

	processDeleteSuccess(success: any) {
		console.log(success);
		if (success.message === 'Deleted') {
			this.toastr.success('Vehicle successfully deleted!', 'Deleted!');
			this.LoadVehicleTypeList();
		}
	}

	processDeleteFailure(fail: any){
		console.error(fail);
		//this.toastr.error(`Error: ${fail}`, 'Error!');
		this.toastr.error(`Error: `, 'Error!');
	}
}
