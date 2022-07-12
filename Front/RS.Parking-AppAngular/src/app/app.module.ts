import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgxSpinnerModule } from 'ngx-spinner';

import { AppComponent } from './app.component';
import { NavegationComponent } from './shared/navegation/navegation.component';
import { TitleComponent } from './shared/title/title.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';
import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';

import { VehicletypesService } from './services/vehicletypes.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';

@NgModule({
	declarations: [
		AppComponent,
		VehicletypesComponent,
		AccordtypesComponent,
		NavegationComponent,
		TitleComponent,
		ControlInOutComponent,
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
