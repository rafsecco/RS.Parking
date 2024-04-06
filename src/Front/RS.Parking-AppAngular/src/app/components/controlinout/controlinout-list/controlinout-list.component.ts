import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { ControlInOut } from '@app/models/ControlInOut';
import { DiscountTypeEnum } from '@app/models/DiscountTypes.enum';
import { AccordTypesService } from '@app/services/AccordTypes.service';
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
	controlInOutId: number;
	controlInOut = {} as ControlInOut;

	// public discountTypeEnum: DiscountTypeEnum[] = [];
	// public accordTypesList: AccordType[] = [];
	public controlInOutList: ControlInOut[] = [];

	constructor(
		private router: Router,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
		private controlInOutService: ControlInOutService
		// private accordTypesService: AccordTypesService,
	) {}

	ngOnInit(): void {
		// this.LoadDiscountTypeEnum();
		// this.LoadAccordTypeList();
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

	// public LoadDiscountTypeEnum(): void {
	// 	this.spinner.show();
	// 	this.accordTypesService.getDiscountTypeEnum().subscribe({
	// 		next: (_discountTypes: DiscountTypeEnum[]) => this.discountTypeEnum = _discountTypes,
	// 		error: (error: any) => { this.toastr.error('Error loading DiscountTypeEnum.', 'Error!'); },
	// 		complete: () => this.spinner.hide()
	// 	});
	// }

	// public LoadAccordTypeList(): void {
	// 	this.spinner.show();
	// 	this.accordTypesService.getAllAccordTypes().subscribe({
	// 		next: (_accordTypes: AccordType[]) => this.accordTypesList = _accordTypes,
	// 		error: (error: any) => { this.toastr.error('Error loading AccordType.', 'Error!'); },
	// 		complete: () => this.spinner.hide()
	// 	});
	// }

	// public getDiscountTypesNameById(id: number) : string {
	// 	console.log(id);
	// 	if (id === null || id === 0) {
	// 		return "";
	// 	} else {
	// 		return `${id} - ${this.accordTypesList.find(x => x.id == id)?.description}`;
	// 	}
	// }

	openModalView(template: TemplateRef<any>, controlInOutId: number): void {
		//this.spinner.show();
		this.controlInOutId = controlInOutId;
		this.controlInOut = this.controlInOutList.find((x) => x.id == controlInOutId);
		// this.controlInOutService.getControlInOutById(controlInOutId).subscribe({
		// 	next: (controlInOut: ControlInOut) => { this.controlInOut = { ... controlInOut }; },
		// 	error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
		// 	complete: () => this.spinner.hide()
		// });
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	openEdit(id: number): void {
		this.router.navigate([`/controlinout/edit/${id}`]);
	}

}
