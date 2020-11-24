import { NgModule } from '@angular/core';
import { MatCardTitle } from '@angular/material/card';
import { AuthLayoutComponent } from './layout/auth/auth-layout.component';
import { LayoutComponent } from './layout/blank/blank.component';
import { MaterialModule } from './material/material.module';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
   LayoutComponent,
   AuthLayoutComponent,
   HeaderComponent,
   FooterComponent,   
  ],
  entryComponents:[
    LayoutComponent,
    AuthLayoutComponent
  ],
  imports: [
    MaterialModule,
    RouterModule
  ],
  exports:[
    LayoutComponent,
    AuthLayoutComponent ,
    MaterialModule   
  ],
  providers: []
})
export class CoreModule { }
