import { Component, EventEmitter, Input, OnInit, Output, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-dynamictable',
  templateUrl: './dynamictable.component.html',
  styleUrls: ['./dynamictable.component.css']
})
export class DynamictableComponent implements OnInit, OnChanges {
  @Input() displayedColumns: string[]
  @Input() nameColumns: string[]
  @Input() datatable: any[]
  @Input() hasOptions: boolean
  @Input() dataSource: MatTableDataSource<any>;
  @Output() element: EventEmitter<any> = new EventEmitter<any>()
  

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }
  ngOnChanges(changes: SimpleChanges): void {       
    this.dataSource = new MatTableDataSource(this.datatable);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.nameColumns.push('options')
    this.dataSource = new MatTableDataSource(this.datatable);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  isDate(field:string){
    return field.indexOf('At') > -1
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  edit(item:any){    
    item.typeAction = 'edit'
    this.element.emit(item)
  }

  delete(item:any){
    item.typeAction = 'delete'
    this.element.emit(item)
  }

}
