import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IncidentHistory } from '../models/incident-history.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class IncidentHistoryService extends BaseService<IncidentHistory> {  
  constructor(public httpClient:HttpClient) {
    super('incidenthistory', httpClient);
  }
}
