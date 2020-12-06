import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';

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
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './components/shared/modal/modal.component';
import { MaterialModule } from './core/material/material.module';
import { MatSelectFilterModule } from 'mat-select-filter';
import { BaseFormComponent } from './components/shared/base/form.component';
import { SlaComponent } from './components/sla/sla.component';
import { PriorityComponent } from './components/priority/priority.component';
import { IncidentFormComponent } from './components/incident/form/incident.form.component';
import { IncidentInfoComponent } from './components/incident/info/incident.info.component';
import { IncidentWizardComponent } from './components/incident/wizard/incident.wizard.component';
import { IncidentDetailComponent } from './components/incident/detail/incident.detail.component';
import { registerLocaleData } from '@angular/common';
import localeDo from '@angular/common/locales/es-DO';
import { AngularFontAwesomeModule } from 'angular-font-awesome';


registerLocaleData(localeDo, 'es');

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
    BaseFormComponent,
    ModalComponent,
    SlaComponent,
    PriorityComponent,
    IncidentFormComponent,
    IncidentInfoComponent,
    IncidentWizardComponent,
    IncidentDetailComponent
  ],
  entryComponents: [
    HomeComponent,
    LoginComponent,
    BaseFormComponent,
    IncidentFormComponent,
    IncidentInfoComponent,
    IncidentWizardComponent,
    IncidentDetailComponent
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
    AngularFontAwesomeModule,
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
  providers: [AuthService, AlertService, NgbActiveModal, { provide: LOCALE_ID, useValue: 'es-DO'}],
  bootstrap: [AppComponent]
})
export class AppModule { }
