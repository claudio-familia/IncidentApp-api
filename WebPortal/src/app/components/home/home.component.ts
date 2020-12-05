import { Component, OnInit } from '@angular/core';
import { MenuItemModel } from 'src/app/models/menu-item.model';


@Component({
    selector: 'app-home',	
    templateUrl: './home.component.html',
    styleUrls: ['home.component.css']
})
export class HomeComponent {
    menu: MenuItemModel[];
	constructor() {
        this.menu = [
            {
                name: 'Incidentes',
                description : 'Registra un nuevo incidente para iniciar con el proceso.',
                image: 'assets/img/incident.png',
                url: '/incidents'
            },
            {
                name: 'Historial de incidentes',
                description : 'Administra y maneja los incidentes en el tiempo.',
                image: 'assets/img/timetable.png',
                url: '/incident-history'
            },
            {
                name: 'Departamentos',
                description : 'Crea, consulta y administra los departamentos.',
                image: 'assets/img/department.png',
                url: '/departments'
            },
            {
                name: 'Puestos',
                description : 'Crea, consulta y administra los puestos de trabajo.',
                image: 'assets/img/position.png',
                url: '/positions'
            },
            {
                name: 'Empleados',
                description : 'Administración de la gestión humana.',
                image: 'assets/img/employee.png',
                url: '/employees'
            },
            {
                name: 'Usuarios',
                description : 'Crea, consulta y administra los usuarios del sistema.',
                image: 'assets/img/users.png',
                url: '/users'
            },
            {
                name: 'Prioridades',
                description : 'Establece cuales son tus prioridades.',
                image: 'assets/img/employee.png',
                url: '/priorities'
            },
            {
                name: 'SLAs',
                description : 'Tiempo de compromiso para solucionar un incidente.',
                image: 'assets/img/users.png',
                url: '/slas'
            }
        ];
	}
}
