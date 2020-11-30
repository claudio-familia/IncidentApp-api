import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SLA } from '../models/sla.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class SlaService extends BaseService<SLA> {  
  constructor(public httpClient:HttpClient) {
    super('sla', httpClient);    
  }
}
