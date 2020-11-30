import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { Priority } from 'src/app/models/priority.model';
import { SLA } from 'src/app/models/sla.model';
import { AlertService } from 'src/app/services/alert.service';
import { PriorityService } from 'src/app/services/priority.service';
import { SlaService } from 'src/app/services/sla.service';
import { AppSettings } from 'src/environments/environment';
import { BaseComponent } from '../shared/base/base.component';
import { BaseFormComponent } from '../shared/base/form.component';

@Component({
  selector: 'app-priority',
  templateUrl: './priority.component.html',
  styleUrls: ['./priority.component.css']
})
export class PriorityComponent extends BaseComponent implements OnInit {

  priorityForm: DynamicForm[]
  priorities: Priority[] = [];
  slas: any[] = [];
  selectedPriority: Priority = new Priority()
  tableHeader: string[] = [];
  tableColumn: string[] = [];

  constructor(private _priorityService: PriorityService,
    private _alertService: AlertService,
    private _modalService: NgbModal,
    private _slaService: SlaService) {
    super(_alertService)
    this.setColumn()
    this.setHeaders()
  }

  setColumn() {
    this.tableColumn.push('id');
    this.tableColumn.push('name');
    this.tableColumn.push('sla');
    this.tableColumn.push('createdAt');
    this.tableColumn.push('updatedAt');
  }

  setHeaders() {
    this.tableHeader.push('#'); 
    this.tableHeader.push('Prioridad');
    this.tableHeader.push('Tiempo de compromiso');
    this.tableHeader.push('Fecha de creación');
    this.tableHeader.push('Fecha de actualización');
  }

  async ngOnInit() {
    this.getPriorities()
    await this.getSlas();
    this.setForm();
  }

  setForm() {
    this.priorityForm = [
      <DynamicForm>{
        name: 'name',
        isRequired: true,
        label: 'Prioridad',
        placeholder: 'Digite el nombre de la prioridad',
        type: 'text',
        value: ''
      },
      <DynamicForm>{
        name: 'slaId',
        isRequired: true,
        label: 'Tiempo de comrpomiso',
        placeholder: 'Seleccione el tiempo de compromiso de la prioridad',
        type: 'select',
        value: '',
        valueArray: this.slas,
        valueFiltered: this.slas.slice()
      }
    ];
  }

  getPriorities() {
    this._priorityService.get().subscribe(
      res => {
        this.priorities = res
      },
      err => this.getHttpErrorResponse(err)
    )
  }

  async getSlas() {
    await this._slaService.get().toPromise()
      .then(
        res => {
          res.map(item => {
            this.slas.push({
              id: item.id,
              name: item.description+' Tiempo de compromiso: '+item.hours+' horas.'
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
    modal.componentInstance.form = this.priorityForm;
    modal.componentInstance.title = 'Nueva prioridad'
    modal.componentInstance.dataEmitter.subscribe((data) => {
      this.save(data)
    })
  }

  save(data: any[]) {
    for (let row of data) {
      this.selectedPriority.id = 0
      if (row.field == 'name') this.selectedPriority.name = row.value
      if (row.field == 'slaId') this.selectedPriority.slaId = row.value
    }
    this._priorityService.create(this.selectedPriority).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso', 'Prioridad creada correctamente', 'success')
        this.getPriorities()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  editDelete(priority: any) {
    const sla = { ...priority.sla }
    priority.department = null;
    this.selectedPriority = priority

    if (priority.typeAction == 'edit') {
      const modal = this._modalService.open(BaseFormComponent, new AppSettings().getModalBasicConf());
      this.priorityForm.map(item => {
        if (item.name == 'name') {
          item.value = priority.name
        }
        if (item.name == 'slaId') {
          item.value = priority.slaId
        }
      })
      modal.componentInstance.form = this.priorityForm;
      modal.componentInstance.title = 'Editar prioridad'
      modal.componentInstance.dataEmitter.subscribe((data) => {
        this.edit(data)
      })
    } else {
      this._alertService.ModalNotification('Aviso', '¿Esta seguro que desea borrar esta prioridad?', 'question')
        .then(res => {
          if (res.isConfirmed) {
            this.delete()
          } else {
            this.selectedPriority.sla = sla;
          }
        })
    }
  }

  edit(data: any[]) {
    for (let row of data) {
      if (row.field == 'name') this.selectedPriority.name = row.value
      if (row.field == 'slaId') this.selectedPriority.slaId = row.value
    }
    this._priorityService.update(this.selectedPriority).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso', 'Prioridad actualizada correctamente', 'success')
        this.getPriorities()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }

  delete() {
    this._priorityService.delete(this.selectedPriority.id.toString()).subscribe(
      res => {
        this._alertService.ToasterNotification('Exitoso', 'Prioridad eliminada correctamente', 'success')
        this.getPriorities()
        this._modalService.dismissAll();
      },
      err => {
        this.getHttpErrorResponse(err)
      }
    )
  }
}