import { NgModule } from '@angular/core';
import { MatCardTitle } from '@angular/material/card';
import { AuthLayoutComponent } from './layout/auth/auth-layout.component';
import { LayoutComponent } from './layout/blank/blank.component';
import { MaterialModule } from './material/material.module';

@NgModule({
  declarations: [
   LayoutComponent,
   AuthLayoutComponent
  ],
  entryComponents:[
    LayoutComponent,
    AuthLayoutComponent
  ],
  imports: [
    MaterialModule
  ],
  exports:[
    LayoutComponent,
    AuthLayoutComponent ,
    MaterialModule   
  ],
  providers: []
})
export class CoreModule { }
