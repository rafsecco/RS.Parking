import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import ptBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { provideEnvironmentNgxCurrency, NgxCurrencyInputMode, NgxCurrencyDirective } from 'ngx-currency';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { VehicletypesService } from './services/vehicletypes.service';
import { AccordTypesService } from './services/AccordTypes.service';
import { ControlInOutService } from './services/ControlInOut.service';

import { AppComponent } from './app.component';
import { NavegationComponent } from './shared/navegation/navegation.component';
import { TitleComponent } from './shared/title/title.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';
import { VehicletypesListComponent } from './components/vehicletypes/vehicletypes-list/vehicletypes-list.component';
import { VehicletypesNewComponent } from './components/vehicletypes/vehicletypes-new/vehicletypes-new.component';
import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';
import { VehicletypesEditComponent } from './components/vehicletypes/vehicletypes-edit/vehicletypes-edit.component';
import { AccordTypesListComponent } from './components/accordtypes/accordtypes-list/accordtypes-list.component';
import { AccordTypesNewComponent } from './components/accordtypes/accordtypes-new/accordtypes-new.component';
import { AccordTypesEditComponent } from './components/accordtypes/accordtypes-edit/accordtypes-edit.component';
import { ControlInOutListComponent } from './components/controlinout/controlinout-list/controlinout-list.component';
import { ControlinoutEditComponent } from './components/controlinout/controlinout-edit/controlinout-edit.component';
import { ControlinoutNewComponent } from './components/controlinout/controlinout-new/controlinout-new.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportsListComponent } from './components/reports/reports-list/reports-list.component';

registerLocaleData(ptBr, 'pt-BR');
defineLocale('pt-br', ptBrLocale);

@NgModule({
	declarations: [
		AppComponent,
		NavegationComponent,
		TitleComponent,
		DateTimeFormatPipe,
		VehicletypesComponent,
		VehicletypesListComponent,
		VehicletypesNewComponent,
		VehicletypesEditComponent,
		AccordtypesComponent,
		AccordTypesListComponent,
		AccordTypesNewComponent,
		AccordTypesEditComponent,
		ControlInOutComponent,
		ControlInOutListComponent,
		ControlinoutEditComponent,
		ControlinoutNewComponent,
		ReportsComponent,
		ReportsListComponent
	],
	imports: [
		BrowserModule,
		ReactiveFormsModule,
		AppRoutingModule,
		HttpClientModule,
		BrowserAnimationsModule,
		ModalModule.forRoot(),
		BsDatepickerModule.forRoot(),
		NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
		NgxCurrencyDirective,
		ToastrModule.forRoot({
			timeOut: 2000,
			positionClass: 'toast-bottom-right',
			preventDuplicates: true,
			progressBar: true
		})
	],
	providers: [
		{ provide: LOCALE_ID, useValue: "pt-BR"},
		VehicletypesService,
		AccordTypesService,
		ControlInOutService,
		provideEnvironmentNgxCurrency({
			align: "left",
			allowNegative: true,
			allowZero: true,
			decimal: ",",
			precision: 2,
			prefix: "R$ ",
			suffix: "",
			thousands: ".",
			nullable: true,
			min: null,
			max: null,
			inputMode: NgxCurrencyInputMode.Financial,
		})
	],
	bootstrap: [AppComponent],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
