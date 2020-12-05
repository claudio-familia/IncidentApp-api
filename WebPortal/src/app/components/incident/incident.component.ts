import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IncidentDto } from 'src/app/models/incident.dto.model';
import { Incident } from 'src/app/models/incident.model';
import { AlertService } from 'src/app/services/alert.service';
import { IncidentService } from 'src/app/services/incident.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { IncidentFormComponent } from './form/incident.form.component';
import { IncidentInfoComponent } from './info/incident.info.component';
import { IncidentWizardComponent } from './wizard/incident.wizard.component';

@Component({
  selector: 'app-incident',
  templateUrl: './incident.component.html',
  styleUrls: ['./incident.component.css']
})
export class IncidentComponent extends BaseComponent implements OnInit {
  incidents: Incident[];
  originalIncidents: Incident[];
  searchInput: string

  constructor(private _modalService: NgbModal,
              private _alertService: AlertService,
              private _incidentService: IncidentService) { 
                super(_alertService)
  }

  ngOnInit() {
    this.getIncidents()
  }

  getIncidentFiltered()  {    
    let data:any = this.originalIncidents.slice();

    let response = data.filter(item => {

      let dataToString = '';
      dataToString += item.assignTo.toString()+' ';
      dataToString += item.description.toString()+' ';
      dataToString += item.id.toString()+' ';
      dataToString += item.priority.toString()+' ';
      dataToString += item.title.toString()+' ';
      dataToString += item.isProcessDone ? 'En proceso':'' +' ';
      dataToString += item.isClosed ? 'Cerrad':'' +' ';      

      return dataToString.indexOf(this.searchInput) != -1;
    });

    this.incidents = response;
  }

  newIncident(){    
    const modal = this._modalService.open(IncidentFormComponent, new AppSettings().getModalBasicConf());
    modal.componentInstance.OnSave.subscribe(res => {
      this.create(res)      
    })
  }

  wizard(incident:IncidentDto){    
    const modal = this._modalService.open(IncidentWizardComponent, new AppSettings().getModalBasicConf());
    modal.componentInstance.incidentId = incident.id;
    modal.componentInstance.isClosed = incident.isClosed;
  }

  getIncidents(){
    this._incidentService.get().subscribe(
      res => {
        this.incidents = res;
        this.originalIncidents = res.slice()
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  create(incident: Incident){
    this._incidentService.create(incident).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Incidente creado correctamente','success');
        this.getIncidents();
        this._modalService.dismissAll();
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  showPriorityCard(){    
    this._modalService.open(IncidentInfoComponent, new AppSettings().getModalBasicConf());        
  }

}
