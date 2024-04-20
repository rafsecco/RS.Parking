import { Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccordType } from '@app/models/AccordType';
import { ControlInOut } from '@app/models/ControlInOut';
import { AccordTypesService } from '@app/services/AccordTypes.service';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-controlinout-edit',
	templateUrl: './controlinout-edit.component.html',
	styleUrls: ['./controlinout-edit.component.scss'],
})
export class ControlinoutEditComponent implements OnInit {

	modalRef: BsModalRef;
	form: FormGroup;
	controlInOut = {} as ControlInOut;
	accordTypesList: AccordType[] = [];
	accordTypeId = 0;

	formatter = new Intl.NumberFormat('pt-BR', {
		style: 'currency',
		currency: 'BRL',

		// These options are needed to round to whole numbers if that's what you want.
		//minimumFractionDigits: 0, // (this suffices for whole numbers, but will print 2500.10 as $2,500.1)
		//maximumFractionDigits: 0, // (causes 2500.99 to be printed as $2,501)
		//console.log(formatter.format(2500)); /* $2,500.00 */
	});

	// formatter = new Intl.NumberFormat('en-US', {
	// 	style: 'currency',
	// 	currency: 'USD',
	// });

	constructor(
		private fb: FormBuilder,
		private accordTypesService: AccordTypesService,
		private controlInOutService: ControlInOutService,
		private router: Router,
		private activatedRouter: ActivatedRoute,
		private modalService: BsModalService,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService
	) {}

	ngOnInit(): void {
		this.LoadControlInOut();
		this.Validation();
	}

	@ViewChild("angularFocus") myInputFocus: ElementRef;
	ngAfterViewInit() {
		this.myInputFocus.nativeElement.focus();
	}

	get f(): any {
		return this.form.controls;
	}

	public cssValidator(formControl: FormControl): any {
		return {'is-invalid': formControl.errors && formControl.touched};
	}

	public Validation(): void {
		this.form = this.fb.group({
			licensePlate: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(7)]],
			//vehicleTypeId: [0 + '', [Validators.required]],
			accordTypeId: ['', [Validators.required, Validators.min(1)]],
			dateTimeIn: ['' , [Validators.required]],
			dateTimeOut: ['' , [Validators.required]],
			vehicleType: this.fb.group({
				id: '',
				active: '',
				dateCreated: '',
				cost:  '',
				description:  ''
			})
		});
	}

	public LoadControlInOut(): void {
		let controlInOutId = +this.activatedRouter.snapshot.paramMap.get('id');
		if (controlInOutId !== null && controlInOutId !== 0) {
			this.spinner.show();
			this.controlInOutService.getControlInOutById(controlInOutId).subscribe({
				next: (_controlInOut: ControlInOut) => {
					this.controlInOut = {... _controlInOut, dateTimeOut: new Date(Date.now()) };
					this.form.patchValue(this.controlInOut);
					// Preencher os valores de vehicleType com os valores recebidos da API
					this.form.get('vehicleType').patchValue(this.controlInOut.vehicleType);
					this.LoadAccordTypeList();
				},
				error: (error: any) => { this.toastr.error(`Error loading Control In Out.\n${error}`, 'Error!'); },
				complete: () => this.spinner.hide()
			});
		}
	}

	public LoadAccordTypeList(): void {
		this.spinner.show();
		this.accordTypesService.getAllAccordTypes().subscribe({
			next: (_accordTypes: AccordType[]) => this.accordTypesList = _accordTypes,
			error: (error: any) => { this.toastr.error(`Error loading AccordType.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	public getAccordTypeById(id: number): void {
		this.spinner.show();
		this.accordTypesService.getAccordTypeById(id).subscribe({
			next: (_accordType: AccordType) => this.controlInOut.accordType = _accordType,
			error: (error: any) => { this.toastr.error(`Error loading AccordType.\n${error}`, 'Error!'); },
			complete: () => this.spinner.hide()
		});
	}

	getChangeAccordTypeValue(val:string): void {
		this.accordTypeId = Number(val);
		this.getAccordTypeById(this.accordTypeId);
	}

	getAccordTypeDescription(): string {
		return `${this.controlInOut.accordType.id} - ${this.controlInOut.accordType.description}`;
	}

	openModalView(event: any, template: TemplateRef<any>): void {
		event.stopPropagation();
		this.updateControlInOut();
		this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
	}

	public updateControlInOut(): void {
		if (this.form.valid) {
			this.spinner.show();
			this.controlInOut = Object.assign({}, this.controlInOut, this.form.value);
			this.controlInOutService.updateControlInOut(this.controlInOut).subscribe({
				next: (_controlInOut: ControlInOut) => {
					this.controlInOut = {... _controlInOut };
					this.form.patchValue(this.controlInOut);
					// Preencher os valores de vehicleType com os valores recebidos da API
					this.form.get('vehicleType').patchValue(this.controlInOut.vehicleType);
				},
				//next: success => this.processSuccess(success),
				error: failure => this.processFailure(failure),
				complete: () => this.spinner.hide()
			});
		}
	}

	public confirmCheckOut(): void {
		// print checkout
		console.log("Print Payment voucher!");
		let toast = this.toastr.success('Check Out', 'Thanks! Check back often!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.modalRef.hide();
				this.router.navigate(['/controlinout/list']);
			});
		}
	}

	public cancelCheckOut(): void {
		if (this.form.valid) {
			this.controlInOut = Object.assign({}, this.controlInOut, this.form.value);
			this.controlInOut.dateTimeOut = null;
			this.controlInOutService.updateControlInOut(this.controlInOut).subscribe({
				next: success => {
					this.processSuccess(success);
				},
				error: failure => this.processFailure(failure),
				complete: () => { this.spinner.hide(); }
			});
		}
	}

	private processSuccess(response: any) {
		let toast = this.toastr.success('Control In Out', 'Success!');
		if (toast) {
			toast.onHidden.subscribe(() => {
				this.modalRef.hide();
				this.router.navigate(['/controlinout/list']);
			});
		}
	}

	private processFailure(fail: any) {
		this.toastr.error(`Error saving Control In Out.\n${fail}`, 'Error');
	}

	public formatDate(): void {

		const now = new Date(Date.now())
		console.log(`new Date(Date.now()): ${now}`)

		const date = new Date()
		console.log(`new Date(): ${date}`)

		const currentDate = new Date(); // Isso retorna a data e hora atual em relação ao UTC
		const localDate = new Date(currentDate.getTime() - (currentDate.getTimezoneOffset() * 60000));
		console.log(`localDate: ${localDate}`); // Isso imprimirá a data e hora atual no fuso horário local

		console.log(`controlInOut.dateTimeOut: ${this.controlInOut.dateTimeOut}`);
		console.log(`Form.dateTimeOut: ${this.form.get('dateTimeOut')}`);
	}

}
