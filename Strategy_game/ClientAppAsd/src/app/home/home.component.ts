import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent{
  public url;


  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
  this.url = baseUrl;
    
  }

  public createDeffaultUser(name: string) {

    var u = new User(name);
    console.log(u.name);
    this.http.post<IUser>(this.url + 'api/DefUser', u).subscribe(result => console.log(result), error => console.error(error));
  }




}

interface IUnit {
  unitId: number;
  defenderPosition: boolean;
  atk: number;
  def: number;
  price: number;
  food: number;
  salary: number;
  ownerCountry: Country;
}

interface ICountry {
  countryId: number;
  tractor: boolean;
  countryName: string;
  combine: boolean;
  wall: boolean;
  commander: boolean;
  tactican: boolean;
  alchemy: boolean;

}

class Country implements ICountry {
  countryId: number;
  tractor: boolean;
  countryName: string;
  combine: boolean;
  wall: boolean;
  commander: boolean;
  tactican: boolean;
  alchemy: boolean;
  constructor(CountryName: string) { this.countryName = CountryName; }
}

class Archer implements IUnit {
  unitId: number;
  defenderPosition: boolean;
  atk: number;
  def: number;
  price: number;
  food: number;
  salary: number;
  ownerCountry: Country;
  constructor(id: number) { this.unitId = id; }
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
