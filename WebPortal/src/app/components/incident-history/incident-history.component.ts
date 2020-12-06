import { Component, OnInit } from '@angular/core';
import { IncidentHistoryDto } from 'src/app/models/incident-history.dto.model';
import { IncidentHistory } from 'src/app/models/incident-history.model';
import { AlertService } from 'src/app/services/alert.service';
import { IncidentHistoryService } from 'src/app/services/incident-history.service';
import { IncidentService } from 'src/app/services/incident.service';
import { BaseComponent } from '../shared/base/base.component';

@Component({
  selector: 'app-incident-history',
  templateUrl: './incident-history.component.html',
  styleUrls: ['./incident-history.component.css']
})
export class IncidentHistoryComponent extends BaseComponent implements OnInit {

  incidents: IncidentHistoryDto[] = []
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _incidentService: IncidentService, private _alertService: AlertService) { 
    super(_alertService)
  }

  ngOnInit() {
    this.getIncidents()
    this.setHeaders();
    this.setColumn();
  }

  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('incident');
    this.tableColumn.push('priority');
    this.tableColumn.push('responsable');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('closedAt');
    this.tableColumn.push('timeToClose');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Incidente');
    this.tableHeader.push('Prioridad');
    this.tableHeader.push('Responsable');    
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de cierre');
    this.tableHeader.push('Tiempo de cierre');
  }

  getIncidents(){
    this._incidentService.getHistories().subscribe(
      res => {        
        this.incidents = res;
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  detail(item){
    console.log(item)
  }

}
