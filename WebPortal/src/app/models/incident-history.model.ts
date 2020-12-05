import { Incident } from './incident.model';

export class IncidentHistory {
    id: number;
    incidentId: number;
    comment: string
    incident?: Incident
}