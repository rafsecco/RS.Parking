import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VehicleType } from '../models/VehicleType';

@Injectable(
	// {providedIn: 'root'}
)
export class VehicletypesService {
	baseURL = 'https://localhost:5001/VehicleTypes';

	constructor(private http: HttpClient) { }

	public getAllVehicleTypes(): Observable<VehicleType[]> {
		return this.http.get<VehicleType[]>(this.baseURL);
	}

	public getVehicleTypesById(id: number): Observable<VehicleType> {
		return this.http.get<VehicleType>(`${this.baseURL}/${id}`);
	}
}
