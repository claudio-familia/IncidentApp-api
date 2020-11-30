import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Deparment } from 'src/app/models/deparment.model';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { AlertService } from 'src/app/services/alert.service';
import { DeparmentService } from 'src/app/services/deparment.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { DepartmentFormComponent } from './form/deparment.form.component';


@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent extends BaseComponent implements OnInit {

  deparmentForm: DynamicForm[]
  departments: Deparment[] = [];
  selectedDepartment: Deparment = new Deparment()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _deparmentService: DeparmentService, 
              private _alertService: AlertService,
              private _modalService: NgbModal) {
                super(_alertService)
    this.setColumn()
    this.setHeaders()
    this.deparmentForm = [
      <DynamicForm>{
        name: 'name',
        isRequired: true,
        label: 'Departamento',
        placeholder: 'Digite el nombre del departamento',
        type: 'text',
        value: ''
      }     
    ];
  }
  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('name');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Departamento');
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  ngOnInit() {    
     this.getDepartments()
  }

  getDepartments(){
    this._deparmentService.get().subscribe(
      res => {
        this.departments = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }
  newEntry(){    
    const modal = this._modalService.open(DepartmentFormComponent, new AppSettings().getModalBasicConf());
    modal.componentInstance.deparmentForm = this.deparmentForm;
    modal.componentInstance.title =  'Nuevo departamento'
    modal.componentInstance.dataEmitter.subscribe((data)=>{
      this.save(data)      
    })
  }

  save(data:any[]){
    for(let row of data){
      this.selectedDepartment.id = 0 
      if(row.field == 'name') this.selectedDepartment.name = row.value      
    }    
    this._deparmentService.create(this.selectedDepartment).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Departamento creado correctamente','success')
        this.getDepartments()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  edit(data:any[]){
    for(let row of data){      
      if(row.field == 'name') this.selectedDepartment.name = row.value      
    }        
    this._deparmentService.update(this.selectedDepartment).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Departamento actualizado correctamente','success')
        this.getDepartments()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete(){
    this._deparmentService.delete(this.selectedDepartment.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Departamento eliminado correctamente','success')
        this.getDepartments()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(department:any){
    this.selectedDepartment = department

    if(department.typeAction == 'edit'){
      const modal = this._modalService.open(DepartmentFormComponent, new AppSettings().getModalBasicConf());
      this.deparmentForm.map(item => {        
        if(item.name == 'name'){
          item.value = department.name
        }
      })  
      modal.componentInstance.deparmentForm = this.deparmentForm;
      modal.componentInstance.title =  'Editar departamento'
      modal.componentInstance.dataEmitter.subscribe((data)=>{
        this.edit(data)      
      })          
    }else{
      this._alertService.ModalNotification('Aviso','¿Esta seguro que desea borrar este departamento?','question')
          .then(res => {
            if(res.isConfirmed){
              this.delete()
            }
          })      
    }
  }
}
