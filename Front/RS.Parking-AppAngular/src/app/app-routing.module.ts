import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccordtypesComponent } from './components/accordtypes/accordtypes.component';
import { ControlInOutComponent } from './components/controlinout/controlinout.component';
import { VehicletypesComponent } from './components/vehicletypes/vehicletypes.component';

const routes: Routes = [
	{ path: 'controlinout', component: ControlInOutComponent },
	{ path: 'accordtypes', component: AccordtypesComponent },
	{ path: 'vehicletypes', component: VehicletypesComponent },
	{ path: '', redirectTo: 'controlinout', pathMatch: 'full' },
	{ path: '**', redirectTo: 'controlinout', pathMatch: 'full' }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
