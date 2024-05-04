import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpHeaders } from '@angular/common/http';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import * as XLSX from 'xlsx';
import { ControlInOutService } from '@app/services/ControlInOut.service';
import { ControlInOut } from '@app/models/ControlInOut';

@Component({
	selector: 'app-reports-list',
	templateUrl: './reports-list.component.html',
	styleUrls: ['./reports-list.component.css'],
	providers: [DatePipe],
})
export class ReportsListComponent implements OnInit {
	public form: FormGroup;
	public controlInOutList: ControlInOut[] = [];

	constructor(
		private controlInOutService: ControlInOutService,
		private formBuilder: FormBuilder,
		private spinner: NgxSpinnerService,
		private toastr: ToastrService,
		private localeService: BsLocaleService,
		private datePipe: DatePipe
	) {
		this.localeService.use('pt-br');
	}

	ngOnInit() {
		this.Validation();
		this.searchReport();
	}

	get bsConfig(): any {
		return {
			isAnimated: true,
			adaptivePosition: true,
			containerClass: 'theme-dark-blue',
			showWeekNumbers: false,
		};
	}

	public Validation(): void {
		const todayLessOneDay = new Date();
		todayLessOneDay.setDate(todayLessOneDay.getDate() - 1); // Subtrai 1 dia

		this.form = this.formBuilder.group({
			dateSearch: [todayLessOneDay, [Validators.required]],
		});
	}

	public searchReport(): void {
		const dateSearchValue = this.form.get('dateSearch').value;
		let dateSearchValueTransform = this.datePipe.transform(dateSearchValue, 'yyyy-MM-dd');

		// OK
		// let dateNow=new Date();
		// let latest_date =this.datePipe.transform(dateNow, 'yyyy-MM-dd');

		if (this.form.valid) {
			this.spinner.show();
			this.controlInOutService
				.getControlInOutByRange(dateSearchValueTransform)
				.subscribe({
					next: (_controlInOutList: ControlInOut[]) => { this.controlInOutList = _controlInOutList; },
					error: (error: any) => this.toastr.error( `Error loading Control In Out.\n${error}`, 'Error!'),
					complete: () => { this.spinner.hide(); }
				});
			this.spinner.hide();
		}
	}

	public downloadExcel(): void {
		const dateSearchValue = this.form.get('dateSearch').value;
		let dateSearchValueTransform = this.datePipe.transform(dateSearchValue, 'yyyy-MM-dd');
		let fileName = `ReportExcel_${dateSearchValueTransform}.xlsx`;

		// passing table id
		let data = document.getElementById('table-data');
		const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(data);

		// Generate workbook and add worksheet
		const wb: XLSX.WorkBook = XLSX.utils.book_new();
		XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

		// Save to file
		XLSX.writeFile(wb, fileName);
	}

	downloadCSV() {
		this.spinner.show();
		const dateSearchValue = this.form.get('dateSearch').value;
		let dateSearchValueTransform =this.datePipe.transform(dateSearchValue, 'yyyy-MM-dd');

		// Fazer a solicitação HTTP para a API
		this.controlInOutService
			.getCSVFileDownload(dateSearchValueTransform)
			.subscribe((response: any) => {
				const fileName = this.getFilenameFromContentDisposition(response.headers);

				// Criar um Blob com os dados da resposta
				const blob = new Blob([response.body], { type: 'text/csv' });

				// Criar um link temporário para o Blob
				const url = window.URL.createObjectURL(blob);

				// Criar um elemento de link e atribuir a URL do Blob a ele
				const link = document.createElement('a');
				link.href = url;
				// Definir o nome do arquivo para download usando o nome extraído da resposta da API
				link.setAttribute('download', fileName);
				// Simular um clique no link para iniciar o download
				document.body.appendChild(link);
				link.click();
				// Limpar o link e revogar o URL do Blob
				document.body.removeChild(link);
				window.URL.revokeObjectURL(url);
			});
		this.spinner.hide();
	}

	// Função para extrair o nome do arquivo do cabeçalho content-disposition
	getFilenameFromContentDisposition(headers: HttpHeaders) {
		const contentDispositionHeader = headers.get('content-disposition');
		const filename = contentDispositionHeader
			.split(';')[1].trim()
			.split('=')[1].trim();
		return filename;
	}
}
