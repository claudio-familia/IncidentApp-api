import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/home/home.component';
import { CoreModule } from './core/core.module';
import { LoginComponent } from './components/auth/login.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthService } from './services/auth.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AlertService } from './services/alert.service';
import { ToastrModule } from 'ngx-toastr';
import { IncidentComponent } from './components/incident/incident.component';
import { IncidentHistoryComponent } from './components/incident-history/incident-history.component';
import { DepartmentsComponent } from './components/departments/departments.component';
import { PositionComponent } from './components/position/position.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { UserComponent } from './components/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    IncidentComponent,
    IncidentHistoryComponent,
    DepartmentsComponent,
    PositionComponent,
    EmployeeComponent,
    UserComponent
  ],
  entryComponents:[
    HomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      progressBar: true,
      progressAnimation: 'increasing',
      enableHtml: true
    })
  ],
  providers: [AuthService, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
