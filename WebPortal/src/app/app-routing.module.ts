
import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { LoginComponent } from './components/auth/login.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
	{
		path: '',
        component: HomeComponent,
    },
    {
		path: 'login',
        component: LoginComponent,
	},
	{ path: '**', redirectTo: '', pathMatch: 'full' }
];
@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
