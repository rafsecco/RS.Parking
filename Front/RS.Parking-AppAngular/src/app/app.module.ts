import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppComponent } from './app.component';
import { VehicletypesComponent } from './vehicletypes/vehicletypes.component';
import { AccordtypesComponent } from './accordtypes/accordtypes.component';
import { NavegationComponent } from './navegation/navegation.component';

import { VehicletypesService } from './services/vehicletypes.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

@NgModule({
	declarations: [
		AppComponent,
		VehicletypesComponent,
		AccordtypesComponent,
		NavegationComponent,
		DateTimeFormatPipe
	],
	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		BrowserAnimationsModule,
		NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' }),
	],
	providers: [
		VehicletypesService
	],
	bootstrap: [AppComponent],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
