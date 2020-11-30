import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DynamicForm } from 'src/app/models/dynamic-form.model';

@Component({
  selector: 'app-dynamicform',
  templateUrl: './dynamicform.component.html',
  styleUrls: ['./dynamicform.component.css']
})
export class DynamicformComponent implements OnInit {
  @Input() form: DynamicForm[]
  @Output() onSave: EventEmitter<any> = new EventEmitter<any>()
  constructor(private _modalService: NgbModal) { }

  ngOnInit() {
  }

  save(){
    const formCapture = [];
    for(let item of this.form){
      formCapture.push({...item})
    }

    const response = [];

    formCapture.map(item => {      
      response.push({
        'field': item.name, 
        'value': item.value
      })
    });
    
    this.onSave.emit(response);
    this.cancel();
  }  

  cancel(){
    this.form.map(item => {
      item.value = ''
    });
    this._modalService.dismissAll()
  }

}
