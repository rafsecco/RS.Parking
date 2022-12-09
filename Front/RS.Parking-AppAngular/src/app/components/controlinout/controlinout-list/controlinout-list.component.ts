import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { ControlInOut } from '@app/models/ControlInOut';
import { discountTypesList } from '@app/models/DiscountTypes.enum';
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
	enumAccordType: typeof discountTypesList = discountTypesList;
	controlInOutId: number;
	controlInOut = {} as ControlInOut;

	public accordTypesList: AccordType[] = [];
	public controlInOutList: ControlInOut[] = [];

	constructor(
		private router: Router,
		private accordTypesService: AccordTypesService,
		private controlInOutService: ControlInOutService,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
	) {}

	ngOnInit(): void {
		this.LoadAccordTypeList();
		this.LoadControlInOutList();
	}

	public LoadAccordTypeList(): void {
		this.spinner.show();
		this.accordTypesService.getAllAccordTypes().subscribe({
			next: (_accordTypes: AccordType[]) => this.accordTypesList = _accordTypes,
			error: (error: any) => { this.toastr.error('Error loading AccordType.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
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
		console.log(id);
		if (id === null || id === 0) {
			return "";
		} else {
			return `${id} - ${this.accordTypesList.find(x => x.id == id)?.description}`;
		}
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
