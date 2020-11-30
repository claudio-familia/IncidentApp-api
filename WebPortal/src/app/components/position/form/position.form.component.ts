import{ Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
    selector: 'app-position-form',
    template: `
    <app-modal [title]="title">
        <app-dynamicform [form]="positionForm" (onSave)="save($event)"></app-dynamicform>
    </app-modal>    
    `
})
export class PositionFormComponent {
    @Input() deparmentForm:any
    @Input() title:any
    @Output() dataEmitter:EventEmitter<any> = new EventEmitter<any>();
        
    constructor() {
    }

    save(data){        
        this.dataEmitter.emit(data);
    }
}