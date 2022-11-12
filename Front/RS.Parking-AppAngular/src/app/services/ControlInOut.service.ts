import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ControlInOut } from '@app/models/ControlInOut';
import { Observable, take } from 'rxjs';

@Injectable()
export class ControlInOutService {

	baseURL = 'https://localhost:5001/ControlInOut';

	constructor(private http: HttpClient) {}

	public getAllControlInOutActive(): Observable<ControlInOut[]> {
		return this.http.get<ControlInOut[]>(this.baseURL);
	}

	public getControlInOutById(id: number): Observable<ControlInOut> {
		return this.http.get<ControlInOut>(`${this.baseURL}/${id}`);
	}

	public saveControlInOut(controlInOut: ControlInOut): Observable<ControlInOut> {
		return this.http
			.post<ControlInOut>(this.baseURL, controlInOut)
			.pipe(take(1));
	}

	public updateControlInOut(controlInOut: ControlInOut): Observable<ControlInOut> {
		return this.http
			.put<ControlInOut>(`${this.baseURL}/${controlInOut.id}`, controlInOut)
			.pipe(take(1));
	}

}
