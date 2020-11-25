import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-dynamictable',
  templateUrl: './dynamictable.component.html',
  styleUrls: ['./dynamictable.component.css']
})
export class DynamictableComponent implements OnInit {
  @Input() Header: string[]
  @Input() BodyValueName: string[]
  @Input() BodyData: any[]

  constructor() { }

  ngOnInit() {
  }

}
