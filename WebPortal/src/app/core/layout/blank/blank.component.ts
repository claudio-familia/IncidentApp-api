import { Component, OnInit } from '@angular/core';


@Component({
    selector: 'app-layout',
    templateUrl: 'blank.component.html',    
})
export class LayoutComponent {
    options: string[]
	constructor() {
        this.options = ['Inicio','Incidentes','Usuarios','Empleados']
	}
}
