import { HttpClient } from '@angular/common/http';
import { UserLogin } from './models/user-login';

export class UserService {
  constructor(private http: HttpClient) { }

  login(userLogin?: UserLogin) {
    return this.http.get<string>(`/api/userlogin`, { params: <any>userLogin} );
  }
}
