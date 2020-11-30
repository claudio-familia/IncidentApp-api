import { Component } from '@angular/core';
import { AlertService } from 'src/app/services/alert.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
    selector: 'app-incident-form',
    templateUrl: 'incident.form.component.html'
})
export class IncidentFormComponent extends BaseComponent {    
    constructor(private _alertService: AlertService) {
        super(_alertService);
    }
}