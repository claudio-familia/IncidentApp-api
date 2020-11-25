import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Deparment } from '../models/deparment.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class DeparmentService extends BaseService<Deparment> {  
  constructor(public httpClient:HttpClient) {
    super('deparment', httpClient);    
  }
}
