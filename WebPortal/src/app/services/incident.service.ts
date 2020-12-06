import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { config } from 'src/environments/environment';
import { IncidentHistoryDto } from '../models/incident-history.dto.model';
import { Incident } from '../models/incident.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class IncidentService extends BaseService<Incident> {

  _apiUrl: string
  _headers: HttpHeaders

  constructor(public httpClient:HttpClient) {
    super('incident', httpClient);

    this._apiUrl = `${config.ApiUrl}/incident`;
    const token = localStorage.getItem('api-token');
    this._headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }
 
  getHistories(): Observable<IncidentHistoryDto[]>{
    return this.httpClient.get<IncidentHistoryDto[]>(this._apiUrl+'/history', {headers:this._headers});
  }
}
