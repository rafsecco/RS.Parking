import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import ptBr from '@angular/common/locales/pt';
import {registerLocaleData} from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { NgxCurrencyModule, CurrencyMaskInputMode } from 'ngx-currency';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

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


registerLocaleData(ptBr, 'pt-BR');

export const customCurrencyMaskConfig = {
	prefix: 'R$ ',
	thousands: '.',
	decimal: ',',
	align: 'left',
	allowNegative: true,
	allowZero: true,
	precision: 2,
	suffix: '',
	nullable: true,
	min: null,
	max: null,
	inputMode: CurrencyMaskInputMode.FINANCIAL,
};

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
  ControlinoutNewComponent
	],
	imports: [
		BrowserModule,
		ReactiveFormsModule,
		AppRoutingModule,
		HttpClientModule,
		BrowserAnimationsModule,
		ModalModule.forRoot(),
		NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
		NgxCurrencyModule.forRoot(customCurrencyMaskConfig),
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
		ControlInOutService
	],
	bootstrap: [AppComponent],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
