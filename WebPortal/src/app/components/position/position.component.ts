import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PositionService } from '../../services/position.service';
import { DynamicForm } from '../../models/dynamic-form.model';
import { Position } from '../../models/position.model';
import { AlertService } from '../../services/alert.service';
import { AppSettings } from 'src/environments/environment';
import { PositionFormComponent } from './form/position.form.component';
import { Deparment } from 'src/app/models/deparment.model';
import { DeparmentService } from 'src/app/services/deparment.service';
import { BaseComponent } from '../shared/base/base.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.css']
})
export class PositionComponent extends BaseComponent implements OnInit {

  positionForm: DynamicForm[]
  positions: Position[] = [];
  departments: Deparment[] = [];
  selectedPosition: Position = new Position()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _positionService: PositionService,
    private _alertService: AlertService,
    private _modalService: NgbModal,
    private _deparmentService: DeparmentService,
    private _router: Router) {
      super(_alertService)
    this.setColumn()
    this.setHeaders()    
  }

  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('name');
    this.tableColumn.push('department');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Posición');
    this.tableHeader.push('Departamento');
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  async ngOnInit() {
    this.getPositions()
    await this.getDepartments();
    this.setForm();
  }

  setForm(){
    this.positionForm = [
      <DynamicForm>{
        name: 'name',
        isRequired: true,
        label: 'Posición',
        placeholder: 'Digite el nombre de la posición',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'departmentId',
        isRequired: true,
        label: 'Departamento',
        placeholder: 'Seleccione el departamento de la posición',
        type: 'select',
        value: '',
        valueArray: this.departments,
        valueFiltered: this.departments.slice()
      }
    ];
  }

  getPositions() {
    this._positionService.get().subscribe(
      res => {
        this.positions = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  async getDepartments(){
    await this._deparmentService.get().toPromise()
        .then(
          res => {
            this.departments = res
          }
        )
        .catch(err => {
          this.getHttpErrorResponse(err)
        })
  }

  newEntry() {
     const modal = this._modalService.open(PositionFormComponent, new AppSettings().getModalBasicConf());
     modal.componentInstance.positionForm = this.positionForm;
     modal.componentInstance.title =  'Nueva posición'
     modal.componentInstance.dataEmitter.subscribe((data)=>{
       this.save(data)
     })
  }

  save(data:any[]){
    for(let row of data){
      this.selectedPosition.id = 0 
      if(row.field == 'name') this.selectedPosition.name = row.value
      if(row.field == 'departmentId') this.selectedPosition.departmentId = row.value    
    }    
    this._positionService.create(this.selectedPosition).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Posición creado correctamente','success')
        this.getPositions()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(position: any) {
    const department = {...position.department}
    position.department = null;
    this.selectedPosition = position

    if(position.typeAction == 'edit'){
      const modal = this._modalService.open(PositionFormComponent, new AppSettings().getModalBasicConf());
      this.positionForm.map(item => {        
        if(item.name == 'name'){
          item.value = position.name
        }
        if(item.name == 'departmentId'){
          item.value = position.departmentId
        }        
      })  
      modal.componentInstance.positionForm = this.positionForm;
      modal.componentInstance.title =  'Editar Posición'
      modal.componentInstance.dataEmitter.subscribe((data)=>{
        this.edit(data)      
      })          
    }else{
      this._alertService.ModalNotification('Aviso','¿Esta seguro que desea borrar esta posición?','question')
          .then(res => {
            if(res.isConfirmed){
              this.delete()
            }else{
              this.selectedPosition.department = department;
            }
          })      
    }
  }

  edit(data:any[]){    
    for(let row of data){      
      if(row.field == 'name') this.selectedPosition.name = row.value;
      if(row.field == 'departmentId') this.selectedPosition.departmentId = row.value;
    }        
    this._positionService.update(this.selectedPosition).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Posición actualizada correctamente','success')
        this.getPositions()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete(){
    this._positionService.delete(this.selectedPosition.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Posición eliminada correctamente','success')
        this.getPositions()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }


}
