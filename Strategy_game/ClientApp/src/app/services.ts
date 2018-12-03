import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin } from './models/user-dto';
import { IPack, ICountry, IUnit, IBuilding, IPlatoon } from './models/country';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  login(userLogin?: UserLogin) {
    return this.http.post<any>('/api/login', userLogin ).pipe(map(user => {
      // login successful if there's a jwt token in the response
      if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
      }

      return user;
  }));
    // return this.http.post<string>(`/api/userlogin`, { params: <any>userLogin} );
  }
  register(user?: UserLogin) {
    console.log(user.name);
    return this.http.post<boolean>(`/api/register`, user);
  }

  public getAllFor(id: number) {
    return this.http.get<IPack>('/api/getAllFor/' + id );
  }

  public upgrade(selectedC: number, n: number) {
    return this.http.put<ICountry>('api/putupgrade/' + selectedC + '/' + n, null);
  }

  public putUnit(selectedC: ICountry, unitid: number) {
    return this.http.put<IUnit>('api/buyOneUnit/' + unitid, selectedC );
  }

  public putbuilding(selectedC: ICountry, buildingId: number) {
    return this.http.put<IBuilding>('api/buyOneBuilding/' + buildingId, selectedC);
  }

  public putUnitToPlatoon(platoonId, unitId) {
    return this.http.put<IPlatoon>('api/PutUnitToPlatoon/' + platoonId + '/' + unitId, null);
  }

  public AttackCountry(fromId: number, toId: number) {
    const id = fromId + '/' + toId;
    console.log(fromId);
    return this.http.put<IPlatoon>('api/AttackCountry/' + id, null);
  }

  public CreatePlatoon(countryId: number) {
    return this.http.post<IPlatoon>('api/PostPlatoon/' +  countryId, null);

  }

  public getScoreList() {
    return this.http.get<UserLogin[]>('api/userscore');
  }
}
