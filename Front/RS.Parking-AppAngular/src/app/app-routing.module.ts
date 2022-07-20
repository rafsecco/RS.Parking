import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';
import { VehicletypesListComponent } from './components/vehicletypes/vehicletypes-list/vehicletypes-list.component';
import { VehicletypesNewComponent } from './components/vehicletypes/vehicletypes-new/vehicletypes-new.component';

const routes: Routes = [
	{ path: 'controlinout', component: ControlInOutComponent },
	{ path: 'accordtypes', component: AccordtypesComponent },
	{ path: 'vehicletypes', redirectTo: 'vehicletypes/list' },
	{
		path: 'vehicletypes', component: VehicletypesComponent,
		children: [
			{ path: 'new', component: VehicletypesNewComponent },
			{ path: 'list', component: VehicletypesListComponent }
		]
	},
	{ path: '', redirectTo: 'controlinout', pathMatch: 'full' },
	{ path: '**', redirectTo: 'controlinout', pathMatch: 'full' }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
