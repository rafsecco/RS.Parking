import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';
import { VehicletypesListComponent } from './components/vehicletypes/vehicletypes-list/vehicletypes-list.component';
import { VehicletypesNewComponent } from './components/vehicletypes/vehicletypes-new/vehicletypes-new.component';
import { VehicletypesEditComponent } from './components/vehicletypes/vehicletypes-edit/vehicletypes-edit.component';
import { AccordTypesListComponent } from './components/accordtypes/accordtypes-list/accordtypes-list.component';
import { AccordTypesNewComponent } from './components/accordtypes/accordtypes-new/accordtypes-new.component';
import { AccordTypesEditComponent } from './components/accordtypes/accordtypes-edit/accordtypes-edit.component';
import { ControlInOutListComponent } from './components/controlinout/controlinout-list/controlinout-list.component';
import { ControlinoutEditComponent } from './components/controlinout/controlinout-edit/controlinout-edit.component';
import { ControlinoutNewComponent } from './components/controlinout/controlinout-new/controlinout-new.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReportsListComponent } from './components/reports/reports-list/reports-list.component';

const routes: Routes = [
	{ path: 'controlinout', redirectTo: 'controlinout/list' },
	{
		path: 'controlinout', component: ControlInOutComponent,
		children: [
			{ path: 'edit/:id', component: ControlinoutEditComponent },
			{ path: 'list', component: ControlInOutListComponent },
			{ path: 'new', component: ControlinoutNewComponent }
		]
	},
	{ path: 'accordtypes', redirectTo: 'accordtypes/list' },
	{
		path: 'accordtypes', component: AccordtypesComponent,
		children: [
			{ path: 'edit/:id', component: AccordTypesEditComponent },
			{ path: 'list', component: AccordTypesListComponent },
			{ path: 'new', component: AccordTypesNewComponent }
		]
	},
	{ path: 'vehicletypes', redirectTo: 'vehicletypes/list' },
	{
		path: 'vehicletypes', component: VehicletypesComponent,
		children: [
			{ path: 'edit/:id', component: VehicletypesEditComponent },
			{ path: 'list', component: VehicletypesListComponent },
			{ path: 'new', component: VehicletypesNewComponent }
		]
	},
	{ path: 'reports', redirectTo: 'reports/list' },
	{
		path: 'reports', component: ReportsComponent,
		children: [
			{ path: 'list', component: ReportsListComponent }
		]
	},

	{ path: '', redirectTo: 'controlinout/list', pathMatch: 'full' },
	{ path: '**', redirectTo: 'controlinout/list', pathMatch: 'full' }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
