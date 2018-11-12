import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
})
export class ManagerComponent{
  public url;
  public user: IUser;
  public country: ICountry;
  public units;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
  this.url = baseUrl;
    
  }

  public getStuff(name: string) {


    console.log(this.user);
    console.log(this.country);
    console.log(this.units);
  }

  public getUserByName(name: string) {
    this.http.get<IUser>(this.url + 'api/user/' + name).subscribe(result => {
      this.user = result;
    }, error => console.error(error));
  }


  public getCountryById(id: number) {

    this.http.get<ICountry>(this.url + 'api/somecont/' + id).subscribe(result => {
      this.country = result;
    }, error => console.error(error));
  }

  public getUnitsById(id: number) {

    this.http.get<IUnit[]>(this.url + 'api/getunits/' + id).subscribe(result => {
      this.units = result;
    }, error => console.error(error));
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
