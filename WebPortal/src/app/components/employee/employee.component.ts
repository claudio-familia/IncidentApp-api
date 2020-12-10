import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { Employee } from 'src/app/models/employee.model';
import { Position } from 'src/app/models/position.model';
import { User } from 'src/app/models/user.model';
import { AlertService } from 'src/app/services/alert.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { PositionService } from 'src/app/services/position.service';
import { UserService } from 'src/app/services/user.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { BaseFormComponent } from '../shared/base/form.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent extends BaseComponent implements OnInit {

  
  employeeForm: DynamicForm[]
  employees: Employee[] = [];
  positions: Position[] = [];
  users: any[] = [];  
  selectedEmployee: Employee = new Employee()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _employeeService: EmployeeService,
    private _alertService: AlertService,
    private _modalService: NgbModal,
    private _positionService: PositionService,
    private _userService: UserService) {
      super(_alertService)
    this.setColumn()
    this.setHeaders()    
  }

  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('position');
    this.tableColumn.push('name');
    this.tableColumn.push('lastName');
    this.tableColumn.push('cedula');
    this.tableColumn.push('email');
    this.tableColumn.push('phoneNumber');
    this.tableColumn.push('bornDate');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Posición');
    this.tableHeader.push('Nombre');
    this.tableHeader.push('Apellido');
    this.tableHeader.push('Cédula');
    this.tableHeader.push('Email');
    this.tableHeader.push('Teléfono');
    this.tableHeader.push('Fecha de nacimiento');    
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  async ngOnInit() {
    this.getEmployees()
    await this.getPositions();
    await this.getUsers();
    this.setForm();
  }

  setForm(){
    this.employeeForm = [
      <DynamicForm>{
        name: 'position',
        isRequired: true,
        label: 'Posición',
        placeholder: 'Seleccione la posición del empleado',
        type: 'select',
        value: '',
        valueArray: this.positions,
        valueFiltered: this.positions.slice()
      },
      <DynamicForm>{
        name: 'user',
        isRequired: true,
        label: 'Usuario',
        placeholder: 'Seleccione el usuario del empleado',
        type: 'select',
        value: '',
        valueArray: this.users,
        valueFiltered: this.users.slice()
      },
      <DynamicForm>{
        name: 'name',
        isRequired: true,
        label: 'Nombre',
        placeholder: 'Digite el nombre del empleado',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'lastname',
        isRequired: true,
        label: 'Apellido',
        placeholder: 'Digite el apellido del empleado',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'cedula',
        isRequired: true,
        label: 'Cédula',
        placeholder: 'Digite la cédula del empleado',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'email',
        isRequired: true,
        label: 'Correo electronico',
        placeholder: 'Digite el email del empleado',
        type: 'email',
        value: ''      
      },
      <DynamicForm>{
        name: 'phonenumber',
        isRequired: true,
        label: 'Teléfono o celular',
        placeholder: 'Digite el teléfono o celular del empleado',
        type: 'text',
        value: ''
      },      
      <DynamicForm>{
        name: 'borndate',
        isRequired: true,
        label: 'Fecha de nacimiento',
        placeholder: 'Digite la fecha de nacimiento del empleado',
        type: 'date',
        value: ''
      }
    ];
  }

  getEmployees() {
    this._employeeService.get().subscribe(
      res => {
        this.employees = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  async getPositions(){
    await this._positionService.get().toPromise()
        .then(
          res => {
            this.positions = res
          }
        )
        .catch(err => {
          this.getHttpErrorResponse(err)
        })
  }
  async getUsers(){
    await this._userService.get().toPromise()
        .then(
          res => {
            res.map(item => {
              this.users.push({
                id: item.id,
                name: item.username
              })
            })
          }
        )
        .catch(err => {
          this.getHttpErrorResponse(err)
        })
  }

  newEntry() {
     const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
     modal.componentInstance.form = this.employeeForm;
     modal.componentInstance.title =  'Nuevo empleado'
     modal.componentInstance.dataEmitter.subscribe((data)=>{
       this.save(data)
     })
  }

  save(data:any[]){
    for(let row of data){
      this.selectedEmployee.id = 0 
      if(row.field == 'position') this.selectedEmployee.positionId = row.value
      if(row.field == 'user') this.selectedEmployee.userId = row.value
      if(row.field == 'name') this.selectedEmployee.name = row.value
      if(row.field == 'lastname') this.selectedEmployee.lastName = row.value
      if(row.field == 'cedula') this.selectedEmployee.cedula = row.value
      if(row.field == 'email') this.selectedEmployee.email = row.value
      if(row.field == 'phonenumber') this.selectedEmployee.phoneNumber = row.value
      if(row.field == 'borndate') this.selectedEmployee.bornDate = row.value      
    }    
    this._employeeService.create(this.selectedEmployee).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Empleado creado correctamente','success')
        this.getEmployees()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(employee: any) {
    const position = {...employee.position}
    const user = {...employee.user}
    employee.position = null;
    employee.user = null;
    this.selectedEmployee = employee

    if(employee.typeAction == 'edit'){
      const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
      this.employeeForm.map(item => {        
        if(item.name == 'position') item.value = employee.positionId
        if(item.name == 'user') item.value = employee.userId
        if(item.name == 'name') item.value = employee.name
        if(item.name == 'lastname') item.value = employee.lastName
        if(item.name == 'cedula') item.value = employee.cedula
        if(item.name == 'email') item.value = employee.email
        if(item.name == 'phonenumber') item.value = employee.phoneNumber
        if(item.name == 'borndate') {
          let date = new Date(employee.bornDate);                     
          item.value = `${date.getFullYear()}-${date.getMonth() < 10 ? '0':''}${date.getMonth() + 1}-${date.getDate()}`
        }
      })  
      modal.componentInstance.form = this.employeeForm;
      modal.componentInstance.title =  'Editar empleado'
      modal.componentInstance.dataEmitter.subscribe((data)=>{
        this.edit(data)      
      })          
    }else{
      this._alertService.ModalNotification('Aviso','¿Esta seguro que desea borrar este empleado?','question')
          .then(res => {
            if(res.isConfirmed){
              this.delete()
            }else{
              this.selectedEmployee.position = position;
              this.selectedEmployee.user = user;
            }
          })      
    }
  }

  edit(data:any[]){    
    for(let row of data){      
      if(row.field == 'position') this.selectedEmployee.positionId = row.value
      if(row.field == 'user') this.selectedEmployee.userId = row.value
      if(row.field == 'name') this.selectedEmployee.name = row.value
      if(row.field == 'lastname') this.selectedEmployee.lastName = row.value
      if(row.field == 'cedula') this.selectedEmployee.cedula = row.value
      if(row.field == 'email') this.selectedEmployee.email = row.value
      if(row.field == 'phonenumber') this.selectedEmployee.phoneNumber = row.value
      if(row.field == 'borndate') this.selectedEmployee.bornDate = row.value  
    }        
    this._employeeService.update(this.selectedEmployee).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Empleado actualizado correctamente','success')
        this.getEmployees()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete(){
    this._employeeService.delete(this.selectedEmployee.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Empleado eliminado correctamente','success')
        this.getEmployees()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

}
