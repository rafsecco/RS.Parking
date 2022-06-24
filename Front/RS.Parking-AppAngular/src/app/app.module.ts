import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VehicletypesComponent } from './vehicletypes/vehicletypes.component';
import { AccordtypesComponent } from './accordtypes/accordtypes.component';
import { NavegationComponent } from './navegation/navegation.component';

@NgModule({
	declarations: [
		AppComponent,
		VehicletypesComponent,
		AccordtypesComponent,
		NavegationComponent,
	],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule],
	providers: [],
	bootstrap: [AppComponent],
})
export class AppModule {}
