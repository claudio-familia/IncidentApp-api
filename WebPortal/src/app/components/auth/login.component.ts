import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/services/alert.service';
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
    errorTitle: string = 'Error al validar';

    constructor(private authService: AuthService, 
                private alertService: AlertService,
                private router: Router) {
    }
    
    login(){        
        const response = this.authService.signIn(this.username, this.password);
        response.subscribe(
            res => {
                localStorage.setItem('api-token', res.token);
                localStorage.setItem('app-user', res.username);
                window.location.replace('/home');
            },
            error => {                
                switch(error.status){
                    case 401: 
                        this.alertService.ToasterNotification(this.errorTitle, 'Usuario o contraseña invalida', 'error');
                    break;
                    case 404:
                        this.alertService.ToasterNotification(this.errorTitle, 'Este usuario no existe', 'error');
                    break;                    
                    default:
                        this.alertService.ToasterNotification(this.errorTitle, 'Ha ocurrido un error en el servicio', 'error');
                }
            }
        );
    }    
}