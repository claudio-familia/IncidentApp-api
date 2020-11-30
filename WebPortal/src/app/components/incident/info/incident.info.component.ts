import { Component } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
    selector: 'app-incident-info',
    templateUrl: 'incident.info.component.html'
})
export class IncidentInfoComponent extends BaseComponent {    
    constructor(private _alertService: AlertService) {
        super(_alertService);
    }
}