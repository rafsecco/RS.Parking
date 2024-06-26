import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { DiscountTypeEnum } from '@app/models/DiscountTypes.enum';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-accordtypes-list',
	templateUrl: './accordtypes-list.component.html',
	styleUrls: ['./accordtypes-list.component.scss'],
})
export class AccordTypesListComponent implements OnInit {

	modalRef: BsModalRef;
	message?: string;
	accordTypeId: number;
	accordType = {} as AccordType;
	public accordTypes: AccordType[] = [];
	public discountTypeEnum: DiscountTypeEnum[] = [];

	constructor(
		private modalService: BsModalService,
		private accordTypesService: AccordTypesService,
		private router: Router,
		private toastr: ToastrService,
		private spinner: NgxSpinnerService
	) {}

	ngOnInit(): void {
		this.LoadDiscountTypeEnum();
		this.LoadAccordTypeList();
	}

	public getDiscountTypesById(id: number) : string {
		return `${id} - ${this.discountTypeEnum.find(x => x.id === id)?.description}`
	}

	public LoadAccordTypeList(): void {
		this.spinner.show();
		this.accordTypesService.getAllAccordTypes().subscribe({
			next: (_accordTypes: AccordType[]) => this.accordTypes = _accordTypes,
			error: (error: any) => { this.toastr.error('Error loading AccordType.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
		this.spinner.hide();
	}

	public LoadDiscountTypeEnum(): void {
		this.spinner.show();
		this.accordTypesService.getDiscountTypeEnum().subscribe({
			next: (_discountTypes: DiscountTypeEnum[]) => this.discountTypeEnum = _discountTypes,
			error: (error: any) => { this.toastr.error('Error loading DiscountTypeEnum.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
		this.spinner.hide();
	}

	openModalView(template: TemplateRef<any>, accordTypeId: number): void {
		this.spinner.show();
		this.accordTypeId = accordTypeId;
		this.accordTypesService.getAccordTypeById(accordTypeId).subscribe({
			next: (accordType: AccordType) => { this.accordType = { ... accordType }; },
			error: (error: any) => { this.toastr.error('Error loading AccordType.', 'Error!'); },
			complete: () => this.spinner.hide()
		});
		this.spinner.hide();
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	openEdit(id: number): void {
		this.router.navigate([`/accordtypes/edit/${id}`]);
	}

	openModal(template: TemplateRef<any>, accordTypeId: number): void {
		this.accordTypeId = accordTypeId;
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	confirmDeleteAccordType(): void {
		this.message = 'Confirmed!';
		this.modalRef?.hide();
		this.spinner.show();
		this.accordTypesService.deleteAccordType(this.accordTypeId).subscribe({
			next: (success: any) => this.processDeleteSuccess(success),
			error: (failure: any) => this.processDeleteFailure(failure),
			complete: () => this.spinner.hide()
		});
		this.spinner.hide();
	}

	declineDeleteAccordType(): void {
		this.message = 'Declined!';
		this.modalRef?.hide();
	}

	processDeleteSuccess(success: any) {
		if (success.message === 'Deleted') {
			this.toastr.success('Accord successfully deleted!', 'Deleted!');
			this.LoadAccordTypeList();
		}
	}

	processDeleteFailure(fail: any){
		this.toastr.error(`Error: ${fail}`, 'Error!');
	}
}
