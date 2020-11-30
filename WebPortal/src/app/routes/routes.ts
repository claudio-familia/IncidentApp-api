import { Routes } from '@angular/router';
import { LoginComponent } from '../components/auth/login.component';
import { DepartmentsComponent } from '../components/departments/departments.component';
import { EmployeeComponent } from '../components/employee/employee.component';
import { HomeComponent } from '../components/home/home.component';
import { IncidentHistoryComponent } from '../components/incident-history/incident-history.component';
import { IncidentComponent } from '../components/incident/incident.component';
import { PositionComponent } from '../components/position/position.component';
import { PriorityComponent } from '../components/priority/priority.component';
import { SlaComponent } from '../components/sla/sla.component';
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
		path: 'slas',
        component: SlaComponent,
    },
	{
		path: 'priorities',
        component: PriorityComponent,
    },
    {
		path: 'login',
        component: LoginComponent,
	},
	{ path: '**', redirectTo: 'home', pathMatch: 'full' }
];