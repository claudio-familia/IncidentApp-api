import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'app-login',	
    templateUrl: `login.component.html`,
    styleUrls: ['./login.component.css']
})
export class LoginComponent {
    hidePassword:boolean = true;
    username: string;
    password: string;

	constructor(private authService: AuthService) {
    }
    
    login(){
        console.log(this.username, this.password)
        const response = this.authService.signIn(this.username, this.password);
        response.subscribe(
            res => {
                console.log(res);
            }
        );
    }
}
