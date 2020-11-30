import { User } from './user.model';
import { Position } from './position.model';

export class Employee {
    id: number
    positionId: number;    
    userId: number;
    name: string;
    lastName: string;
    cedula: string;
    email: string;
    phoneNumber: string;
    bornDate: Date

    position: Position;
    user: User
}