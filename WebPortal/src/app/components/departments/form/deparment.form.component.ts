import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';
import { ModalComponent } from '../../shared/modal/modal.component';

@Component({
  selector: 'app-department-form',
  template: `
    <app-modal [title]="title">
        <app-dynamicform [form]="deparmentForm" (onSave)="save($event)"></app-dynamicform>
    </app-modal>
  `,  
})
export class DepartmentFormComponent {
    @Input() deparmentForm:any
    @Input() title:any
    @Output() dataEmitter:EventEmitter<any> = new EventEmitter<any>();
        
    constructor() {                
    }

    save(data){     
        this.dataEmitter.emit(data);
    }
}
