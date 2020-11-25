import { Component, OnInit } from '@angular/core';
import { Deparment } from 'src/app/models/deparment.model';
import { DynamicForm } from 'src/app/models/dynamic-form.model';
import { DeparmentService } from 'src/app/services/deparment.service';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.css']
})
export class DepartmentsComponent implements OnInit {

  deparmentForm: DynamicForm[]
  departments: Deparment[] = [];
  tableHeader: string[] = [];
  tableProperties: string[] = [];

  constructor(private deparmentService: DeparmentService) {
    this.tableHeader.push('#');
    this.tableHeader.push('Departamento');
    this.tableProperties.push('id');
    this.tableProperties.push('name');
    
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

  ngOnInit() {
     this.deparmentService.get().subscribe(
      res => {
        this.departments = res
      }
    )
  }

  save(data:any){
    console.log(data)
  }
}
