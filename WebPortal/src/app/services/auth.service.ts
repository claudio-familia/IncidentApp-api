import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { config } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';

@Injectable({ providedIn: 'root' })
export class AuthService {    
    constructor(private http:HttpClient) {        
    }

    signIn(username: string, password:string) : Observable<LoginModel> {
        const user = { Username: username, Password: password };
        return this.http.post<LoginModel>(`${config.ApiUrl}/auth/login`, user);
    }

    signOut(){
        localStorage.removeItem('api-token')
        localStorage.removeItem('app-user')        
    }
}