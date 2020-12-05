import { Component, OnInit } from '@angular/core';
import { Priority } from 'src/app/models/priority.model';
import { AlertService } from 'src/app/services/alert.service';
import { PriorityService } from 'src/app/services/priority.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
    selector: 'app-incident-info',
    templateUrl: 'incident.info.component.html'
})
export class IncidentInfoComponent extends BaseComponent implements OnInit {
    priorities: Priority[];  
    constructor(private _alertService: AlertService,
                private _priorityService: PriorityService) {
        super(_alertService);
    }
    ngOnInit(): void {
        this.getPriorities();        
    }

    getPriorities(){
        this._priorityService.get().subscribe(
            res => {
                this.priorities = res;
            },
            err => this.getHttpErrorResponse(err)
        )
    }
}