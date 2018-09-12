import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CountryService } from './country.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Country, IGame, ICountry, IBuilding } from '../classes/Country'
import { DetailsService } from '../details/details.service';
import { Observable } from 'rxjs';
import { combineLatest } from 'rxjs';

import { NgRedux, select } from '@angular-redux/store'; // <- New
import { GameActions } from '../app.actions'; // <- New
import { IGameState } from "../../store"; // <- New

//import { Country } from '../classes/Country';

@Component({
  selector: 'app-countrymanager',
  templateUrl: './countrymanager.component.html'


})
export class CountryManagerComponent implements OnInit{
  ngOnInit(): void {
    this.http.get<ICountry[]>(this.url + 'api/someconts').subscribe(result => {
      this.countries = result;
    }, error => console.error(error));
    this.http.get<IGame>(this.url + 'api/getGame/' + 1).subscribe(result => {
      this.game = result; console.log(result);
    }, error => console.error(error));
  }
  public countries: ICountry[];
  public onecountry: ICountry;
  public penis = 0;
  public url;
  public inputId;
  public name;
  public unit: IUnit;
  public users: IUser[];
  // API's url
  public selectedC: ICountry;
  public selectedA: IArcher;
  public selectedH: IUnit;
  public selectedS: IUnit;
  public selectedF: IBuilding;
  public selectedB: IBuilding;
  //units:
  public game: IGame;
  public details0;
  public details1;
  public details2;
  public readonly Game$: Observable<IGameState>; // <- New

  constructor(
    private ngRedux: NgRedux<IGameState>, // <- New
    private actions: GameActions,
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private countryService: CountryService,
    private detailsService: DetailsService
  ) {
    this.Game$ = ngRedux.select<IGameState>();
    this.url = baseUrl;
  }

  public nuller() {
    this.selectedA = null;
    this.selectedH = null;
    this.selectedS = null;
    this.selectedF = null;
    this.selectedB = null;
  }

  

  public nexxtRound() {
    console.log("asd");
    //console.log(this.Game$.)
    this.ngRedux.dispatch(this.actions.plus_round()); // <- New

  }






  public getCountries() {
    this.http.get<IGame>(this.url + 'api/getGame/' + 1).subscribe(result => {
      this.game = result; console.log(result);
    }, error => console.error(error));
    this.http.get<ICountry[]>(this.url + 'api/someconts').subscribe(result => {
      this.countries = result;
    }, error => console.error(error));
  }

  public getCountryById(id: number) {
    this.http.get<ICountry>(this.url + 'api/somecont/' + id).subscribe(result => {
      this.onecountry = result;
    }, error => console.error(error));
  }

  public addNewUser(name: string) {
    this.countryService.addUser(name);

  }
  public refreshUser() {

    
  
    this.countryService.refreshUsers().subscribe(users => this.users = users);
    
    
  }


  public updater() {
    this.penis = this.penis + 10;
  }

  public deleter(id: number) {
    this.http.delete<ICountry>(this.url + 'api/deletethis/' + id).subscribe(result => {
      this.onecountry = result;
    }, error => console.error(error));
  }

  public adder(name: string) {
    this.countryService.post(name).subscribe(result => this.unitAdder(result));
    
  }

  public unitAdder(c: ICountry) {
    var cid = c.countryId;
    //var id = new Archer(cid);
    this.http.post(this.url + 'api/addUnittoCountry/' + cid, null).subscribe(result => console.log(result));
    this.http.post(this.url + 'api/addHorsemanToCountry/' + cid, null).subscribe(result => console.log(result));
    this.http.post(this.url + 'api/addSoldierToCountry/' + cid, null).subscribe(result => console.log(result));
    this.http.post(this.url + 'api/addFarmToCountry/' + cid, null).subscribe(result => console.log(result));
    this.http.post(this.url + 'api/addBarrakToCountry/' + cid, null).subscribe(result => console.log(result));
    this.detailsService.createPlatoon(c).subscribe(r => console.log(r));
  }

  public horsemanAdder(cid: number) {

    var id = new Archer(cid);
    this.http.post<IUnit>(this.url + 'api/addHorsemanToCountry/' + cid, null).subscribe(result => console.log(result), error => console.error(error));

  }
  public soldierAdder(cid: number) {

    var id = new Archer(cid);
    this.http.post<IUnit>(this.url + 'api/addSoldierToCountry/' + cid, null).subscribe(result => console.log(result), error => console.error(error));

  }
  public farmAdder(cid: number) {

    var id = new Archer(cid);
    this.http.post<IUnit>(this.url + 'api/addFarmToCountry/' + cid, null).subscribe(result => console.log(result), error => console.error(error));

  }
  public barrackAdder(cid: number) {

    var id = new Archer(cid);
    this.http.post<IUnit>(this.url + 'api/addBarrakToCountry/' + cid, null).subscribe(result => console.log(result), error => console.error(error));

  }

  public addGame() {
    this.http.post<IGame>(this.url + 'api/createNewGame', null).subscribe(result => this.game = result, error => console.error(error));
  }
  public nextRound() {
    //this.countryService.nextRound(this.game.gameId)
    //  .subscribe(result => this.game = result, error => console.error(error));
    // round +1
    this.http.put<IGame>(this.url + 'api/nextRound/' + this.game.gameId, null)
      .subscribe(result => this.game = result, error => console.error(error));

  }
  //public parcial_results(id: ICountry) {
  //  var a = this.selectedA;
  //  var h = this.selectedH;
  //  var s = this.selectedS;
  //  var f = this.selectedF;
  //  var b = this.selectedB;
    
    

  //  var potatoesPerround = f.counter * f.potatoesPerRound;
  //  var goldPerround = f.counter * f.population;
  //  var _potatoesPerround =
  //    a.counter * a.food + h.counter * h.food + s.counter * s.food;
  //  var _goldPerround = a.counter * a.salary + h.counter * h.salary + s.counter * s.salary;;

  //  //console.log(this.selectedC);
  //  var newcountry = new Country("");
  //  newcountry.gold = goldPerround - _goldPerround;
  //  newcountry.potatoes = potatoesPerround - _potatoesPerround;
  //  console.log(newcountry);
  //  console.log("id:", id);
  //  this.http.put<ICountry>(this.url + 'api/countryRound/' + id.countryId, newcountry)
  //    .subscribe(result => console.log("ÚJSZAR:",result), error => console.error(error));
  //}



  //public getparams(id: number) {
  //  var sc = new Country("");
  //  sc.countryId = this.selectedC.countryId;
  //    var combined = combineLatest(
  //      this.detailsService.getparamA(sc),
  //      this.detailsService.getparamH(sc),
  //      this.detailsService.getparamS(sc),
  //      this.detailsService.getparamF(sc),
  //      this.detailsService.getparamB(sc)
      
  //  );
    
  //  var subscribe = combined.subscribe(
  //    ([resultA, resultH, resultS, resultF, resultB]) => {
        
  //      this.selectedA = resultA;
  //      this.selectedH = resultH;
  //      this.selectedS = resultS;
  //      this.selectedF = resultF;
  //      this.selectedB = resultB;
        
  //      this.parcial_results(sc);
  //      return null;
  //    }
  //  );
  //}


}
interface IArcher {
  unitId: number;
  defenderPosition: boolean;
  atk: number;
  def: number;
  price: number;
  food: number;
  salary: number;
  counter: number;
  ownerCountry: Country;
}

interface IUnit {
  unitId: number;
  defenderPosition: boolean;
  atk: number;
  def: number;
  price: number;
  food: number;
  salary: number;
  counter: number;
  ownerCountry: Country;
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
  counter: number;
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
