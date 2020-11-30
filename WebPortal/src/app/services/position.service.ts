import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Position } from 'src/app/models/position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionService extends BaseService<Position> {  
  constructor(public httpClient:HttpClient) {
    super('position', httpClient);    
  }
}
