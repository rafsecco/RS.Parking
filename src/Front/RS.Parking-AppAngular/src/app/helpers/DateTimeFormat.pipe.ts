// import { DatePipe } from '@angular/common';
// import { Pipe, PipeTransform } from '@angular/core';
// import { Constants } from '../utils/Constants';

// @Pipe({
// 	name: 'DateTimeFormat',
// })
// export class DateTimeFormatPipe extends DatePipe implements PipeTransform {
// 	override transform(value: any, args?: any): any {
// 		return super.transform(value, Constants.DATE_TIME_FMT);
// 	}
// }

import { Pipe, PipeTransform, Inject, LOCALE_ID } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Constants } from '../utils/Constants'; // Importe suas constantes aqui se necessário

@Pipe({
	name: 'DateTimeFormat',
})
export class DateTimeFormatPipe implements PipeTransform {
	constructor(@Inject(LOCALE_ID) private locale: string) {}

	transform(value: any, args?: any): any {
		const datePipe: DatePipe = new DatePipe(this.locale);
		return datePipe.transform(value, Constants.DATE_TIME_FMT);
	}
}
