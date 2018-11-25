import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLogin } from './models/user-dto';
import { IPack, ICountry, IUnit, IBuilding, IPlatoon } from './models/country';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  login(userLogin?: UserLogin) {
    return this.http.post<string>(`/api/userlogin`, { params: <any>userLogin} );
  }
  register(userLogin?: UserLogin) {
    console.log(userLogin.Name);
    return this.http.post<boolean>(`/api/register`, { params: <any>userLogin} );
  }

  public getAllFor(id: number){
    return this.http.get<IPack>('/api/getAllFor/' + id)
  }

  public upgrade(selectedC: number, n: number){
    return this.http.put<ICountry>('api/putupgrade/' + selectedC + "/" + n, null);
  }
  
  public putUnit(selectedC: ICountry, unitid: number){
    return this.http.put<IUnit>('api/buyOneUnit/' + unitid, selectedC)
  }

  public putbuilding(selectedC: ICountry, buildingId: number){
    return this.http.put<IBuilding>('api/buyOneBuilding/' + buildingId, selectedC)
  }

  public putUnitToPlatoon(platoonId, unitId){
    return this.http.put<IPlatoon>('api/PutUnitToPlatoon/' + platoonId + '/' + unitId, null)
  }   

  
}
