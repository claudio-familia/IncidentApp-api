import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() drawer: any
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  logout(){
    this.authService.signOut();
    window.location.replace('/login')
  }
}
