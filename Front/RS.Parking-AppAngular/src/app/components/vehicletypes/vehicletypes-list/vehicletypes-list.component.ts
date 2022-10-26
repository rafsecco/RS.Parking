import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { VehicletypesService } from '@app/services/vehicletypes.service';
import { VehicleType } from '@app/models/VehicleType';

@Component({
	selector: 'app-vehicletypes-list',
	templateUrl: './vehicletypes-list.component.html',
	styleUrls: ['./vehicletypes-list.component.scss'],
})
export class VehicletypesListComponent implements OnInit {

	modalRef: BsModalRef;
	message?: string;
	vehicleTypeId: number;
	vehicleType = {} as VehicleType;
	public vehicleTypes: VehicleType[] = [];

	constructor(
		private modalService: BsModalService,
		private vehicleTypesService: VehicletypesService,
		private router: Router,
		private toastr: ToastrService,
		private spinner: NgxSpinnerService
	) {}

	ngOnInit(): void {
		this.LoadVehicleTypeList();
	}

	public LoadVehicleTypeList(): void {
		this.spinner.show();
		this.vehicleTypesService.getAllVehicleTypes().subscribe({
			next: (_vehicleTypes: VehicleType[]) => this.vehicleTypes = _vehicleTypes,
			error: (error: any) => { console.log(error); },
			complete: () => this.spinner.hide()
		});
	}

	openModalView(template: TemplateRef<any>, vehicleTypeId: number): void {
		this.spinner.show();
		this.vehicleTypeId = vehicleTypeId;
		this.vehicleTypesService.getVehicleTypeById(vehicleTypeId).subscribe({
			next: (vehicleType: VehicleType) => {
				this.vehicleType = { ... vehicleType };
			},
			error: (error: any) => {
				this.toastr.error('Error loading VehicleType.', 'Error!');
				console.error(error);
			},
			complete: () => this.spinner.hide()
		});


		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	openEdit(id: number): void {
		this.router.navigate([`/vehicletypes/edit/${id}`]);
	}

	openModal(template: TemplateRef<any>, vehicleTypeId: number): void {
		this.vehicleTypeId = vehicleTypeId;
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	confirmDeleteVehicleType(): void {
		this.message = 'Confirmed!';
		this.modalRef?.hide();
		this.spinner.show();
		this.vehicleTypesService.deleteVehicleType(this.vehicleTypeId).subscribe({
			next: (success: any) => this.processDeleteSuccess(success),
			error: (failure: any) => this.processDeleteFailure(failure),
			complete: () => this.spinner.hide()
		});
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
		this.toastr.error(`Error: ${fail}`, 'Error!');
	}
}
