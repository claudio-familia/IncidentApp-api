import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { config } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthService {    
    constructor(private http:HttpClient) {        
    }

    signIn(username: string, password:string) : Observable<any> {
        const user = { Username: username, Password: password };
        return this.http.post(`${config.ApiUrl}/auth/login`, user);
    }
}