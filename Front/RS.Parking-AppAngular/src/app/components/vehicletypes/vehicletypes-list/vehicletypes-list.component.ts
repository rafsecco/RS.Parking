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
	public vehicleTypes: VehicleType[] = [];

	constructor(
		private modalService: BsModalService,
		private toastr: ToastrService,
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

	openModal(template: TemplateRef<any>): void {
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	confirm(): void {
		this.message = 'Confirmed!';
		this.modalRef?.hide();
		this.toastr.success('The record has been successfully deleted!', 'Deleted!');
	}

	decline(): void {
		this.message = 'Declined!';
		this.modalRef?.hide();
	}
}
