import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { VehicleType } from '../models/VehicleType';

@Injectable()
export class VehicletypesService {
	baseURL = 'https://localhost:5001/VehicleType';

	constructor(private http: HttpClient) {}

	public getAllVehicleTypes(): Observable<VehicleType[]> {
		return this.http.get<VehicleType[]>(this.baseURL);
	}

	public getVehicleTypeById(id: number): Observable<VehicleType> {
		return this.http.get<VehicleType>(`${this.baseURL}/${id}`);
	}

	public saveVehicleType(vehicletype: VehicleType): Observable<VehicleType> {
		return this.http
			.post<VehicleType>(this.baseURL, vehicletype)
			.pipe(take(1));
	}

	public updateVehicleType(vehicletype: VehicleType): Observable<VehicleType> {
		return this.http
			.put<VehicleType>(`${this.baseURL}/${vehicletype.id}`, vehicletype)
			.pipe(take(1));
	}

	public deleteVehicleType(id: number): Observable<any> {
		return this.http
			.delete(`${this.baseURL}/${id.toString()}`)
			.pipe(take(1));
	}
}
