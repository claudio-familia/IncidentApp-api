import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',  
  templateUrl: `app.component.html`,
})
export class AppComponent implements OnInit {
  title = 'Incident-App | Home';
  token:any;
  get isAuthenticated() {
    return this.token != null;
  }
  constructor(private router:Router){
    this.token = localStorage.getItem('api-token');    
  }
  ngOnInit(): void {
    if(!this.isAuthenticated) this.router.navigateByUrl('/login');
  }
}
