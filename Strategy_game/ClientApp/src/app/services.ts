import { HttpClient } from '@angular/common/http';
import { UserLogin } from './models/user-login';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  login(userLogin?: UserLogin) {
    return this.http.get<string>(`/api/userlogin`, { params: <any>userLogin} );
  }
  register(userLogin?: UserLogin) {
    console.log('register');
    return this.http.get<string>(`/api/somecont/10`, { params: <any>userLogin} ).subscribe();
  }
}
