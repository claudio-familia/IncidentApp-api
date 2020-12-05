import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Incident } from 'src/app/models/incident.model';
import { Priority } from 'src/app/models/priority.model';
import { AlertService } from 'src/app/services/alert.service';
import { PriorityService } from 'src/app/services/priority.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
    selector: 'app-incident-form',
    templateUrl: 'incident.form.component.html',
    styles: [`
        label {
            font-weight: 700;
        }
    `]
})
export class IncidentFormComponent extends BaseComponent implements OnInit {

    @Output() OnSave: EventEmitter<any> = new EventEmitter<any>()
    @Input() withModal: boolean = true;

    @Input() incident: Incident = new Incident();
    priorities: Priority[];
    events: any[];
    eventsFiltered: any[];
    constructor(private _alertService: AlertService,
                private _priorityService: PriorityService,
                private _modalService: NgbModal) {
        super(_alertService);
        this.events = [
            'Condición crítica de salud.',
            'Accidentes de tránsito',
            'Casos de dificultad respiratoria',
            'Reportes de violencia doméstica',
            'Casos de agresión física',
            'Reportes de personas en estado inconsciente',
            'Casos de persona en peligro',
            'Casos de ginecología/obstetricia',
            'Casos de caída',
            'Casos de personas heridas',
            'Casos de incendio',
            'Casos de dolor de pecho'
        ]
        this.eventsFiltered = this.events.slice()
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

    save(){
        this.OnSave.emit(this.incident)
    }

    cancel(){
        this._modalService.dismissAll();
    }
}