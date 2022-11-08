import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { ControlInOut } from '@app/models/ControlInOut';
import { discountTypesList } from '@app/models/DiscountTypes.enum';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-controlinout-list',
	templateUrl: './controlinout-list.component.html',
	styleUrls: ['./controlinout-list.component.scss'],
})
export class ControlInOutListComponent implements OnInit {

	modalRef: BsModalRef;
	enumAccordType: typeof discountTypesList = discountTypesList;
	controlInOutId: number;
	controlInOut = {} as ControlInOut;
	public controlInOutList: ControlInOut[] = [];

	constructor(
		private router: Router,
		private controlInOutService: ControlInOutService,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
	) {}

	ngOnInit(): void {
		this.LoadControlInOutList();
	}

	public LoadControlInOutList(): void {
		this.spinner.show();
		this.controlInOutService.getAllControlInOutActive().subscribe({
			next: (_controlInOutList: ControlInOut[]) => this.controlInOutList = _controlInOutList,
			error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public getDiscountTypesNameById(id: number) : string {
		return `${id} - ${discountTypesList.find(x => x.id === id)?.name}`
	}

	openModalView(template: TemplateRef<any>, controlInOutId: number): void {
		this.spinner.show();
		this.controlInOutId = controlInOutId;
		this.controlInOutService.getControlInOutById(controlInOutId).subscribe({
			next: (controlInOut: ControlInOut) => { this.controlInOut = { ... controlInOut }; },
			error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	openEdit(id: number): void {
		this.router.navigate([`/controlinout/edit/${id}`]);
	}

}
