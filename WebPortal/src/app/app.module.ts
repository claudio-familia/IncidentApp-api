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
import { DynamicformComponent } from './components/shared/dynamicform/dynamicform.component';
import { DynamictableComponent } from './components/shared/dynamictable/dynamictable.component';
import {NgbActiveModal, NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { DepartmentFormComponent } from './components/departments/form/deparment.form.component';
import { ModalComponent } from './components/shared/modal/modal.component';
import { MaterialModule } from './core/material/material.module';
import { PositionFormComponent } from './components/position/form/position.form.component';
import { MatSelectFilterModule } from 'mat-select-filter';


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
    UserComponent,
    DynamicformComponent,
    DynamictableComponent,
    DepartmentFormComponent,
    PositionFormComponent,
    ModalComponent
  ],
  entryComponents:[
    HomeComponent,
    LoginComponent,
    DepartmentFormComponent,
    PositionFormComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    MaterialModule,
    MatSelectFilterModule,
    ToastrModule.forRoot({
      progressBar: true,
      progressAnimation: 'increasing',
      enableHtml: true
    })
  ],
  exports: [
    NgbModule,
    MaterialModule
  ],
  providers: [AuthService, AlertService, NgbActiveModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
