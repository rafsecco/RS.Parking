import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicletypes',
  templateUrl: './vehicletypes.component.html',
  styleUrls: ['./vehicletypes.component.scss']
})
export class VehicletypesComponent implements OnInit {

  public vehicleTypes: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getVehicleTypes();
  }

  public getVehicleTypes() {

    this.http.get('https://localhost:5001/VehicleTypes').subscribe(
      response => this.vehicleTypes = response,
      error => console.log(error)
    );
  };

}
