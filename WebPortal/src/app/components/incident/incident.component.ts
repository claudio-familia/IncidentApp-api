import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AppSettings } from 'src/environments/environment';
import { IncidentFormComponent } from './form/incident.form.component';
import { IncidentInfoComponent } from './info/incident.info.component';

@Component({
  selector: 'app-incident',
  templateUrl: './incident.component.html',
  styleUrls: ['./incident.component.css']
})
export class IncidentComponent implements OnInit {

  constructor(private _modalService: NgbModal) { }

  ngOnInit() {
  }

  newIncident(){    
    this._modalService.open(IncidentFormComponent, new AppSettings().getModalBasicConf());        
  }

  showPriorityCard(){    
    this._modalService.open(IncidentInfoComponent, new AppSettings().getModalBasicConf());        
  }

}
