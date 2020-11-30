import { Deparment } from './deparment.model';

export class Position {
    id: number
    name: string;
    departmentId: number;
    department: Deparment
}