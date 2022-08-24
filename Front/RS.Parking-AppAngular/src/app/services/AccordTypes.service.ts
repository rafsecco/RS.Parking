import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { AccordType } from '@app/models/AccordType';

@Injectable()
export class AccordTypesService {
	baseURL = 'https://localhost:5001/AccordType';

	constructor(private http: HttpClient) { }

	public getAllAccordTypes(): Observable<AccordType[]> {
		return this.http.get<AccordType[]>(this.baseURL);
	}

	public getAccordTypeById(id: number): Observable<AccordType> {
		return this.http.get<AccordType>(`${this.baseURL}/${id}`);
	}

	public post(accordType: AccordType): Observable<AccordType> {
		return this.http
			.post<AccordType>(this.baseURL, accordType)
			.pipe(take(1));
	}

	public put(accordType: AccordType): Observable<AccordType> {
		return this.http
			.put<AccordType>(`${this.baseURL}/${accordType.id}`, accordType)
			.pipe(take(1));
	}

	public deleteAccordType(id: number): Observable<any> {
		return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
	}
}
