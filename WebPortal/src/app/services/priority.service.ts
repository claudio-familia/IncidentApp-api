import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Priority } from '../models/priority.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PriorityService extends BaseService<Priority> {  
  constructor(public httpClient:HttpClient) {
    super('priority', httpClient);    
  }
}
