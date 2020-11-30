import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { User } from 'src/app/models/user.model';
import { AlertService } from 'src/app/services/alert.service';
import { UserService } from 'src/app/services/user.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { BaseFormComponent } from '../shared/base/form.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent extends BaseComponent implements OnInit {

  userForm: DynamicForm[]
  users: User[] = [];
  selectedUser: User = new User()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _userService: UserService, 
              private _alertService: AlertService,
              private _modalService: NgbModal) {
                super(_alertService)
    this.setColumn()
    this.setHeaders()
    this.userForm = [
      <DynamicForm>{
        name: 'username',
        isRequired: true,
        label: 'Nombre de usuario',
        placeholder: 'Digite el nombre del usuario',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'password',
        isRequired: true,
        label: 'Contraseña',
        placeholder: 'Digite la contraseña del usuario',
        type: 'password',
        value: ''
      },      
      <DynamicForm>{
        name: 'confirmpassword',
        isRequired: true,
        label: 'Confirmar contraseña',
        placeholder: 'Confirme la contraseña del usuario',
        type: 'password',
        value: ''
      } 
    ];
  }
  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('username');    
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Usuario');
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  ngOnInit() {    
     this.getUsers()
  }

  getUsers(){    
    this._userService.get().subscribe(
      res => {
        this.users = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }
  newEntry(){    
    const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());    
    modal.componentInstance.form = this.userForm;
    modal.componentInstance.title =  'Nuevo usuario'
    modal.componentInstance.dataEmitter.subscribe((data)=>{
      this.save(data)      
    })
  }

  save(data:any[]){
    for(let row of data){
      this.selectedUser.id = 0 
      if(row.field == 'username') this.selectedUser.username = row.value
      if(row.field == 'password') this.selectedUser.password = row.value
    }    
    this._userService.create(this.selectedUser).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Usuario creado correctamente','success')
        this.getUsers()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  edit(data:any[]){
    for(let row of data){      
      if(row.field == 'username') this.selectedUser.username = row.value      
    }        
    this._userService.update(this.selectedUser).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Usuario actualizado correctamente','success')
        this.getUsers()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete(){
    this._userService.delete(this.selectedUser.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Usuario eliminado correctamente','success')
        this.getUsers()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(user:any){
    this.selectedUser = user

    if(user.typeAction == 'edit'){
      const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
      this.userForm.map(item => {        
        if(item.name == 'username'){
          item.value = user.username
        }
      })  
      modal.componentInstance.form = this.userForm;
      modal.componentInstance.title =  'Editar usuario'
      modal.componentInstance.dataEmitter.subscribe((data)=>{
        this.edit(data)      
      })          
    }else{
      this._alertService.ModalNotification('Aviso','¿Esta seguro que desea borrar este usuario?','question')
          .then(res => {
            if(res.isConfirmed){
              this.delete()
            }
          })      
    }
  }

}
