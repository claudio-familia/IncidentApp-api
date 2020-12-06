import { Component, Input, OnInit } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { IncidentHistoryService } from 'src/app/services/incident-history.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
    selector: 'app-incident-detail',
    templateUrl:'./incident.detail.component.html',
    styleUrls: ['./incident.detail.component.css']
})
export class IncidentDetailComponent extends BaseComponent implements OnInit { 
    
    @Input() incidentId: number
    incident:any = null
    
    constructor(private _alertService:AlertService, 
                private _incidentHistoryService:IncidentHistoryService) {
        super(_alertService);
        
    }
    ngOnInit(): void {
        this.getIncident()
    }    
    getIncident() {
       this._incidentHistoryService.getById(this.incidentId.toString()).subscribe(
           res => {
            this.incident = res;
           },
           err => this.getHttpErrorResponse(err)
       )
    }
}