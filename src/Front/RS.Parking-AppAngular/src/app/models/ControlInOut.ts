import { AccordType } from "./AccordType";
import { VehicleType } from "./VehicleType";

export interface ControlInOut {
	id: number;
	licensePlate: string;
	dateTimeIn: Date;
	dateTimeOut?: Date;
	price: string;

	vehicleType: VehicleType;
	accordType: AccordType;

	accordTypeId: number;
	vehicleTypeId: number;
	vehicleTypeName: string;
}
