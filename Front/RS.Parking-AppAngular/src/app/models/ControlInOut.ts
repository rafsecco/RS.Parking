import { AccordType } from "./AccordType";
import { VehicleType } from "./VehicleType";

export interface ControlInOut {
	id: number;
	licensePlate: string;
	dateTimeIn: Date;
	dateTimeOut?: Date;
	vehicleTypeId: number;
	vehicleType: VehicleType;
	accordTypeId: number;
	accordType: AccordType;
}
