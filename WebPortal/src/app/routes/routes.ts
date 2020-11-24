import { Routes } from '@angular/router';
import { LoginComponent } from '../components/auth/login.component';
import { DepartmentsComponent } from '../components/departments/departments.component';
import { EmployeeComponent } from '../components/employee/employee.component';
import { HomeComponent } from '../components/home/home.component';
import { IncidentHistoryComponent } from '../components/incident-history/incident-history.component';
import { IncidentComponent } from '../components/incident/incident.component';
import { PositionComponent } from '../components/position/position.component';
import { UserComponent } from '../components/user/user.component';

export const routes: Routes = [
	{
		path: 'home',
        component: HomeComponent,
	},
	{
		path: 'incidents',
        component: IncidentComponent,
	},
	{
		path: 'incident-history',
        component: IncidentHistoryComponent,
	},
	{
		path: 'departments',
        component: DepartmentsComponent,
	},
	{
		path: 'positions',
        component: PositionComponent,
	},
	{
		path: 'employees',
        component: EmployeeComponent,
	},
	{
		path: 'users',
        component: UserComponent,
    },
    {
		path: 'login',
        component: LoginComponent,
	},
	{ path: '**', redirectTo: 'home', pathMatch: 'full' }
];