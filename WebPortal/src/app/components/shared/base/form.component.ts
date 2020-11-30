import { Component, Input, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-base-form',
  template: `
    <app-modal [title]="title">
        <app-dynamicform [form]="form" (onSave)="save($event)"></app-dynamicform>
    </app-modal>
  `,  
})
export class BaseFormComponent {
    @Input() form:any
    @Input() title:any
    @Output() dataEmitter:EventEmitter<any> = new EventEmitter<any>();
        
    constructor() {                
    }

    save(data: any){     
        this.dataEmitter.emit(data);
    }
}