// // export class DateTime {
// // }

// export default class DateTime {
// 	static get today(): DateTime;
// 	static get utcNow(): DateTime;
// 	static get now(): DateTime;

// 	static parse(s: string): DateTime;

// 	get hour(): number;
// 	get minute(): number;
// 	get second(): number;
// 	get millisecond(): number;
// 	get day(): number;
// 	get dayOfWeek(): number;
// 	get month(): number;
// 	get year(): number;
// 	get timeZoneOffset(): TimeSpan;
// 	get msSinceEpoch(): number;

// 	/** Strips time of the day and returns Date only */
// 	get date(): DateTime;

// 	get asJSDate(): Date;

// 	get time(): TimeSpan;

// 	constructor();
// 	constructor(time?: number | string);
// 	constructor(
// 		year?: number,
// 		month?: number,
// 		date?: number,
// 		hours?: number,
// 		minutes?: number,
// 		seconds?: number,
// 		ms?: number
// 	);

// 	add(d: DateTime | TimeSpan): DateTime;

// 	add(
// 		days: number,
// 		hours?: number,
// 		minutes?: number,
// 		seconds?: number,
// 		milliseconds?: number
// 	): DateTime;

// 	addMonths(m: number): DateTime;
// 	addYears(y: number): DateTime;

// 	diff(rhs: Date | DateTime): TimeSpan;
// 	equals(d: DateTime): boolean;

// 	// for easy access, following methods
// 	// are available on intellisense

// 	toLocaleString(
// 		locales?: string | string[],
// 		options?: Intl.DateTimeFormatOptions
// 	): string;

// 	toLocaleDateString(
// 		locales?: string | string[],
// 		options?: Intl.DateTimeFormatOptions
// 	): string;

// 	toLocaleTimeString(
// 		locales?: string | string[],
// 		options?: Intl.DateTimeFormatOptions
// 	): string;

// 	toUTCString(): string;

// 	toISOString(): string;

// 	toJSON(key?: any): string;
// 	toTimeString(): string;
// 	toDateString(): string;
// }
