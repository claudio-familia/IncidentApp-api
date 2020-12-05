import {Component, Input, OnInit} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from 'src/app/models/employee.model';
import { IncidentHistory } from 'src/app/models/incident-history.model';
import { Incident } from 'src/app/models/incident.model';
import { AlertService } from 'src/app/services/alert.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { IncidentHistoryService } from 'src/app/services/incident-history.service';
import { IncidentService } from 'src/app/services/incident.service';
import { BaseComponent } from '../../shared/base/base.component';

@Component({
  selector: 'app-incident-wizard',
  templateUrl: './incident.wizard.component.html',
  styles: [`
  label {
    font-weight: 700;
  }

  .tabcontent {
    padding: 10px;
  }

  .nav-link, a {
    color: #757575; 
  }

  .nav-link.active {
    font-weight: bold;
  }
  `]
})
export class IncidentWizardComponent extends BaseComponent implements OnInit {
  @Input() incidentId:string  
  incident:Incident = new Incident()
  originalIncident:Incident = new Incident()
  isIncidentClosed: boolean = false
  selectedResponsable: Employee = new Employee()
  responsables: any[]
  responsableFiltered: any[]
  active:number = Number(tabs.InitialInformation);
  constructor(private _incidentService: IncidentService, 
              private _alertService: AlertService, 
              private _modalService: NgbModal, 
              private _incidentHistoryService: IncidentHistoryService, 
              private _employeeService:EmployeeService){
    super(_alertService)
  }
  async ngOnInit(): Promise<void> {
    await this.getIncident();
    this.getEmployees();
  }

  async getIncident(){
    await this._incidentService.getById(this.incidentId).toPromise()
    .then(res => {
      this.incident = res;
      this.originalIncident = {...res}       
    })
    .catch(err => this.getHttpErrorResponse(err))
  }

  getEmployees(){
    this._employeeService.get().subscribe(
      res => {
        this.responsables = res;        
        this.responsableFiltered = res.slice();

        let selectedEmployee = this.responsables.find(item => item.user.id === this.incident.assignedUserId);
        if(selectedEmployee){
          this.selectedResponsable = selectedEmployee;
        }
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  save(){ 
    if(this.active == Number(tabs.ResponsableAssignment)){   
      this.incident.assignedUserId = this.selectedResponsable.user.id;
      this._incidentService.update(this.incident).subscribe(
        res => {
            if(this.selectedResponsable && this.incident.assignedUserId != this.selectedResponsable.user.id)
              this.saveResponsable();
            else
              this._alertService.ToasterNotification('Incidente actualizado', 'Incidente actualizado correctamente', 'success');
        },
        err => this.getHttpErrorResponse(err)
      )
    }         
    if(this.active == Number(tabs.Conclusion)) {
        if(this.incident.closedComment != '' || this.isIncidentClosed){
          if(this.isIncidentClosed){
            this._alertService.ModalNotification('Aviso', '¿Esta seguro que desea cerrar el incidente, una vez hecho esto no se podra modificar?', 'question', 'No, no cerrar')
                .then(res => {
                  this.addConclusion();
                  let message = ''
                  if(!res.isConfirmed){
                    this.isIncidentClosed = false;  
                    message = this.isIncidentClosed ? 'El caso ha sido cerrado correctamente' : 'Se ha agregado nueva información al caso correctamente';
                  }
                  this.incident.isIncidentClosed = this.isIncidentClosed;
                  this._incidentService.update(this.incident).subscribe(
                    res => {this._alertService.ToasterNotification('Incidente actualizado exitosamente', message, 'success');;},
                    err => this.getHttpErrorResponse(err)
                  )
                })
          }else{
            this.addConclusion();
          }
        }
        else
          this._alertService.ToasterNotification('Incidente actualizado', 'Incidente actualizado correctamente', 'success');      
    }
  }

  saveResponsable(){
    let incidentHistoryItem: IncidentHistory = {
      id: 0,
      incidentId: this.incident.id,
      comment : `Se ha asignado el responsable ${this.selectedResponsable.name} ${this.selectedResponsable.lastName}`
    }

    this._incidentHistoryService.create(incidentHistoryItem).subscribe(
      res => {
        this._alertService.ToasterNotification('Incidente actualizado exitosamente', 'El responsable seleccionado ha sido asignado', 'success');
        this._modalService.dismissAll();
      }
    )
  }

  addConclusion(){
    let incidentHistoryItem: IncidentHistory = {
      id: 0,
      incidentId: this.incident.id,
      comment : this.incident.closedComment
    }

    this._incidentHistoryService.create(incidentHistoryItem).subscribe(
      res => {       
        this._modalService.dismissAll();
      },
      err => this.getHttpErrorResponse(err)
    )
  }
}


enum tabs {
  InitialInformation = 1,
  ResponsableAssignment = 2,
  Conclusion = 3
}