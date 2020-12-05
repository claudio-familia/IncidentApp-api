import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  @Input() title:string
  @Input() hasBodyClasses: boolean
  @Input() bodyClasses: string
  constructor(private _activeModal: NgbActiveModal) { }

  closeModal(){
    this._activeModal.close();
  }

  ngOnInit() {
  }

}
