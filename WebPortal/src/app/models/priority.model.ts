import { SLA } from './sla.model';

export class Priority {
    id: number;
    name: string;
    slaId: number;
    sla: SLA
}