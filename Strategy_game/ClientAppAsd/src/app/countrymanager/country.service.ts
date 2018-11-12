import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country, IGame, ICountry, IBuilding } from '../classes/Country'
import { Observable } from 'rxjs';

@Injectable()
export class CountryService {
  public onecountry: ICountry;
  public url;
  public users: IUser[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  public post(name: string) : Observable<ICountry>{
    var c = new Country(name);

    return this.http.post<ICountry>(this.url + 'api/poster', c);
    
  }

  public getRound(id: number): Observable<IGame> {
    console.log("in service-getround");
    return this.http.get<IGame>(this.url + 'api/getGame/' + 1)
  }


  public nextRound(id: number): Observable<IGame>{
    console.log("in service-nextround");
    return this.http.put<IGame>(this.url + 'api/nextRound/' + id, null)
  }

  public addUser(name: string) {
    var u = new User(name);
    console.log(u.name);
    this.http.post<IUser>(this.url + 'api/addUser', u).subscribe(result => console.log(result), error => console.error(error));

    
    }

  public refreshUsers(): Observable<IUser[]> {
    
    return this.http.get<IUser[]>(this.url + 'api/getUsers')
    
    }

}

interface IUser {
  userID: number;
  score: number;
  name: string;
  gold: number;
}

class User implements IUser {
  userID: number;
  score: number;
  name: string;
  gold: number;
  constructor(Name: string) {this.name = Name;}
}

