import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { ControlInOut } from '@app/models/ControlInOut';
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

	public controlInOutList: ControlInOut[] = [];

	constructor(
		private router: Router,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
		private controlInOutService: ControlInOutService
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
		this.spinner.hide();
	}

	openModalView(template: TemplateRef<any>, controlInOutId: number): void {
		this.controlInOutId = controlInOutId;
		this.controlInOut = this.controlInOutList.find((x) => x.id == controlInOutId);
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	openEdit(id: number): void {
		this.router.navigate([`/controlinout/edit/${id}`]);
	}

}
