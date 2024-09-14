import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { ControlInOut } from '@app/models/ControlInOut';
import { Observable, take } from 'rxjs';

@Injectable()
export class ControlInOutService {

	baseURL = 'http://localhost:5000/ControlInOut';

	constructor(private http: HttpClient) {}

	public getAllControlInOutActive(): Observable<ControlInOut[]> {
		return this.http.get<ControlInOut[]>(this.baseURL);
	}

	public getControlInOutById(id: number): Observable<ControlInOut> {
		return this.http.get<ControlInOut>(`${this.baseURL}/${id}`);
	}

	public getControlInOutByRange(date: string): Observable<ControlInOut[]> {
		return this.http.get<ControlInOut[]>(`${this.baseURL}/${date}`);
	}

	public getCSVFileDownload(date: string): any {
		const headers = new HttpHeaders().set('Accept', 'text/csv');

		return this.http.get(`${this.baseURL}/DownloadCSV/${date}`, {
			headers,
			responseType: 'blob',
			observe: 'response',
		});
	}

	// public getFileDownload(): any {
	// 	return this.http.get(`${this.baseURL}/download`, {observe: 'response', responseType:'blob'});
	// }

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
