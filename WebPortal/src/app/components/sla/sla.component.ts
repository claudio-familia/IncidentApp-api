import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { SLA } from 'src/app/models/sla.model';
import { AlertService } from 'src/app/services/alert.service';
import { SlaService } from 'src/app/services/sla.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { BaseFormComponent } from '../shared/base/form.component';

@Component({
  selector: 'app-sla',
  templateUrl: './sla.component.html',
  styleUrls: ['./sla.component.css']
})
export class SlaComponent extends BaseComponent implements OnInit {

  slaForm: DynamicForm[]
  slas: SLA[] = [];
  selectedSla: SLA = new SLA()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _slaService: SlaService, 
              private _alertService: AlertService,
              private _modalService: NgbModal) {
                super(_alertService)
    this.setColumn()
    this.setHeaders()
    this.slaForm = [
      <DynamicForm>{
        name: 'description',
        isRequired: true,
        label: 'Descripción',
        placeholder: 'Digite la descripción del tiempo de compromiso',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'hours',
        isRequired: true,
        label: 'Cantidad de horas',
        placeholder: 'Digite la cantidad de horas del tiempo de compromiso',
        type: 'text',
        value: ''
      }
    ];
  }
  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('description');
    this.tableColumn.push('hours');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#');
    this.tableHeader.push('Descripción');
    this.tableHeader.push('Horas');
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  ngOnInit() {    
     this.getSlas()
  }

  getSlas(){
    this._slaService.get().subscribe(
      res => {
        this.slas = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }
  newEntry(){    
    const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
    modal.componentInstance.form = this.slaForm;
    modal.componentInstance.title =  'Nuevo tiempo de compromiso'
    modal.componentInstance.dataEmitter.subscribe((data)=>{
      this.save(data)      
    })
  }

  save(data:any[]){
    for(let row of data){
      this.selectedSla.id = 0 
      if(row.field == 'description') this.selectedSla.description = row.value      
      if(row.field == 'hours') this.selectedSla.hours = row.value      
    }    
    this._slaService.create(this.selectedSla).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Tiempo de compromiso creado correctamente','success')
        this.getSlas()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  edit(data:any[]){
    for(let row of data){      
      if(row.field == 'description') this.selectedSla.description = row.value      
      if(row.field == 'hours') this.selectedSla.hours = row.value    
    }        
    this._slaService.update(this.selectedSla).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Tiempo de compromiso actualizado correctamente','success')
        this.getSlas()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete(){
    this._slaService.delete(this.selectedSla.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso','Tiempo de compromiso eliminado correctamente','success')
        this.getSlas()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(sla:any){
    this.selectedSla = sla

    if(sla.typeAction == 'edit'){
      const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
      this.slaForm.map(item => {        
        if(item.name == 'description'){
          item.value = sla.description
        }
        if(item.name == 'hours'){
          item.value = sla.hours
        }
      })  
      modal.componentInstance.form = this.slaForm;
      modal.componentInstance.title =  'Editar tiempo de compromiso'
      modal.componentInstance.dataEmitter.subscribe((data)=>{
        this.edit(data)      
      })          
    }else{
      this._alertService.ModalNotification('Aviso','¿Esta seguro que desea borrar este tiempo de compomiso?','question')
          .then(res => {
            if(res.isConfirmed){
              this.delete()
            }
          })      
    }
  }
}