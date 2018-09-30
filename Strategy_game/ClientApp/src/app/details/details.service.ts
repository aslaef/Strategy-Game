import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPlatoon, IBuilding, ICountry, IUnit, IPack } from '../classes/Country';
import { Observable } from 'rxjs';

@Injectable()
export class DetailsService {
  public url;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public upgrade(selectedC: ICountry, n: number): Observable<ICountry> {
    return this.http.put<ICountry>(this.url + 'api/putupgrade/' + selectedC.countryId + "/" + n, null);
  }

  public getparamA(selectedC: ICountry): Observable<IUnit> {
    return this.http.get<IUnit>(this.url + 'api/getArcherFor/' + selectedC.countryId);
  }
  public getparamH(selectedC: ICountry): Observable<IUnit> {
    return this.http.get<IUnit>(this.url + 'api/getHorsemanFor/' + selectedC.countryId);
  }
  public getparamS(selectedC: ICountry): Observable<IUnit> {
    return this.http.get<IUnit>(this.url + 'api/getSoldierFor/' + selectedC.countryId);
  }
  public getparamF(selectedC: ICountry): Observable<IBuilding> {
    return this.http.get<IBuilding>(this.url + 'api/getFarmFor/' + selectedC.countryId);
  }
  public getparamB(selectedC: ICountry): Observable<IBuilding> {
    return this.http.get<IBuilding>(this.url + 'api/getBarrackFor/' + selectedC.countryId);
  }

  public selector(id: number): Observable<ICountry> {
    return this.http.get<ICountry>(this.url + 'api/somecont/' + id);
  }

  public putA(selectedA: IUnit, id: number): Observable<IUnit> {
    return this.http.put<IUnit>(this.url + 'api/putUnittoCountry/' + selectedA.unitId, null);
  }
  public putH(selectedH: IUnit, id: number): Observable<IUnit> {
    return this.http.put<IUnit>(this.url + 'api/putHorsemanToCountry/' + selectedH.unitId, null);
  }
  public putS(selectedS: IUnit, id: number): Observable<IUnit> {
    return this.http.put<IUnit>(this.url + 'api/putSoldierToCountry/' + selectedS.unitId, null)
  }
  public putF(selectedF: IBuilding, id: number): Observable<IBuilding> {
    return this.http.put<IBuilding>(this.url + 'api/putFarmToCountry/' + selectedF.buildingId, null)
  }
  public putB(selectedB: IBuilding, id: number): Observable<IBuilding> {
    return this.http.put<IBuilding>(this.url + 'api/putBarrackToCountry/' + selectedB.buildingId, null)
  }

  public countrychange(selectedC: ICountry, id: number): Observable<ICountry> {
    return this.http.put<ICountry>(this.url + 'api/countryRound/' + id, selectedC)
  }

  public buyOneUnit(selectedC: ICountry, unitid: number): Observable<IUnit> {
    console.log("asd");
    return this.http.put<IUnit>(this.url + 'api/buyOneUnit/' + unitid, selectedC)
  }

  public buyOneBuilding(selectedC: ICountry, unitid: number): Observable<IUnit> {
    return this.http.put<IUnit>(this.url + 'api/buyOneBuilding/' + unitid, selectedC)
  }

  public getAllFor(id: number): Observable<IPack> {
    return this.http.get<IPack>(this.url + 'api/getAllFor/' + id)
  }

  public createPlatoon(c: ICountry): Observable<IPlatoon>  {
    return this.http.post<IPlatoon>(this.url + 'api/PostPlatoon/' +  c.countryId, null)
      
  }

  public getPlatoon(id: number): Observable<IPlatoon> {
    return this.http.get<IPlatoon>(this.url + 'api/GetPlatoon/' + id)
  }

  public PutArcherToPlatoon(p: IPlatoon, id: number): Observable<IPlatoon> {
    return this.http.put<IPlatoon>(this.url + 'api/PutArcherInPlatoon/' + id + '/' + p.platoonId, null)
  }
  public PutHorsemanInPlatoon(p: IPlatoon, id: number): Observable<IPlatoon> {
    return this.http.put<IPlatoon>(this.url + 'api/PutHorsemanInPlatoon/' + id + '/' + p.platoonId, null)
  }
  public PutSoldierInPlatoon(p: IPlatoon, id: number): Observable<IPlatoon> {
    return this.http.put<IPlatoon>(this.url + 'api/PutSoldierInPlatoon/' + id + '/' + p.platoonId, null)
  }

  public AttackCountry(fromId: number, toId: number): Observable<IPlatoon> {
    var id = fromId + '/' + toId;
    console.log(fromId);
    return this.http.put<IPlatoon>(this.url + 'api/AttackCountry/' + id, null)
  }


}
