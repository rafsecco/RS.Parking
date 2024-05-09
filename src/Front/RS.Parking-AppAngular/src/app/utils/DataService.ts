import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root',
})
export class DateService {
	constructor() {}

	// Função para converter uma string UTC em objeto de data
	convertUTCStringToDate(utcString: string): Date {
		return new Date(utcString);
	}
}
