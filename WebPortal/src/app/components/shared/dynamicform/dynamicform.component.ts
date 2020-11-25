import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DynamicForm } from 'src/app/models/dynamic-form.model';

@Component({
  selector: 'app-dynamicform',
  templateUrl: './dynamicform.component.html',
  styleUrls: ['./dynamicform.component.css']
})
export class DynamicformComponent implements OnInit {
  @Input() form: DynamicForm[]
  @Output() onSave: EventEmitter<any> = new EventEmitter<any>()
  constructor() { }

  ngOnInit() {
  }

  save(){
    const response = [];    
    this.form.map(item => {      
      response.push({
        'field': item.name, 
        'value': item.value
      })
    });
    
    this.onSave.emit(response);
  }

  cancel(fun: any){
    this.form.map(item => {
      item.value = ''
    });
  }

}
