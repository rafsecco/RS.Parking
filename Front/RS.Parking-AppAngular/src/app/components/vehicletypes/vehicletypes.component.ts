import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { VehicleType } from '@app/models/VehicleType';
import { VehicletypesService } from '@app/services/vehicletypes.service';

@Component({
	selector: 'app-vehicletypes',
	templateUrl: './vehicletypes.component.html',
	styleUrls: ['./vehicletypes.component.scss'],
	// providers: [VehicletypesService]
})
export class VehicletypesComponent implements OnInit {

	ngOnInit(): void {

	}
}
