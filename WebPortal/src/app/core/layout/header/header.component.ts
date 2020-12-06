import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() drawer: any
  userName: string = ''
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.userName = localStorage.getItem('app-user')
  }

  logout(){
    this.authService.signOut();
    window.location.replace('/login')
  }
}
