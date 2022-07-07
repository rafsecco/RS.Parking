import { EnumAccordType } from "./EnumAccordType.enum";

export interface AccordType {
	id: number;
	active: boolean;
	dateCreated: Date;
	description: string;
	accord: EnumAccordType;
	percentage: number;
}
