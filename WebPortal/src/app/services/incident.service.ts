import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Incident } from '../models/incident.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class IncidentService extends BaseService<Incident> {  
  constructor(public httpClient:HttpClient) {
    super('incident', httpClient);    
  }
}
