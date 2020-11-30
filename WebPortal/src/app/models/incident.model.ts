import { Deparment } from './deparment.model';
import { IncidentHistory } from './incident-history.model';
import { Priority } from './priority.model';
import { User } from './user.model';

export class Incident {
    id: number
    reportedUserId: number;
    assignedUserId: number;
    priorityId: number;
    departmentId: number;    
    title: string;
    description: string;
    closedDate: Date
    closedComment: string; 

    priority: Priority;
    department: Deparment;
    reportedUser: User;
    assignedUser: User
    incidentHistory: IncidentHistory[]
}