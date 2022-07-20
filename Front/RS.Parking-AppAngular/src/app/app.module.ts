import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AppRoutingModule } from './app-routing.module';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { VehicletypesService } from './services/vehicletypes.service';

import { AppComponent } from './app.component';
import { NavegationComponent } from './shared/navegation/navegation.component';
import { TitleComponent } from './shared/title/title.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';
import { VehicletypesListComponent } from './components/vehicletypes/vehicletypes-list/vehicletypes-list.component';
import { VehicletypesNewComponent } from './components/vehicletypes/vehicletypes-new/vehicletypes-new.component';
import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';

@NgModule({
	declarations: [
		AppComponent,
		NavegationComponent,
		TitleComponent,
		DateTimeFormatPipe,
		ControlInOutComponent,
		AccordtypesComponent,
		VehicletypesComponent,
		VehicletypesListComponent,
		VehicletypesNewComponent,
	],
	imports: [
		BrowserModule,
		ReactiveFormsModule,
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
