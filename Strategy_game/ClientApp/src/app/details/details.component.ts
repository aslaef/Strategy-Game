import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { forEach } from '@angular/router/src/utils/collection';
import { IBuilding, ICountry, IUnit, Country, IPlatoon } from '../classes/Country';
import { DetailsService } from './details.service';
import { concat } from 'rxjs';


//import { Country } from '../classes/Country';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html'

})
export class DetailsComponent implements OnInit {
  ngOnInit(): void {
    
  }
  public url;
  
  public targetid;
  public countries: ICountry[];
  public selectedC: ICountry;
  public selectedA: IUnit;
  public selectedH: IUnit;
  public selectedS: IUnit;
  public selectedF: IBuilding;
  public selectedB: IBuilding;
  public platoon: IPlatoon;
  public platoons: IPlatoon[];

  public details0;
  public details1;
  public details2;
  public unitnumber;
  public errormsg: string;
  public disabler1;

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    @Inject('BASE_URL') baseUrl: string,
    private detailsService: DetailsService,

  ) {
    this.url = baseUrl;

    
    this.targetid = this.route.snapshot.paramMap.get('id');
    this.getAll(this.targetid);
    //this.selector(this.targetid);
    //console.log(this.targetid);
  }
  public getAll(id: number) {
    this.detailsService.getAllFor(this.targetid).subscribe(result => {
      this.selectedC = result.c;
      this.selectedA = result.a;
      this.selectedH = result.h;
      this.selectedS = result.s;
      this.selectedF = result.f;
      this.selectedB = result.b;
      //this.platoon = result.p[0];
      this.platoons = result.p;
      this.countries = result.cs;
      //console.log(this.selectedB.builder);
    }, error => console.error(error));
    var z = document.getElementsByTagName("button");
    for (var x = 0; x < z.length; x++) {
      
    }
  }

  public upgrade(n: number) {
    this.detailsService.upgrade(this.selectedC, n).subscribe(result => {
      this.selectedC = result;
    }, error => console.error(error));

    
  }
  public getparams() {

    this.detailsService.getparamA(this.selectedC).subscribe(result => {
      this.selectedA = result;
    }, error => console.error(error));

    this.detailsService.getparamH(this.selectedC).subscribe(result => {
      this.selectedH = result;
    }, error => console.error(error));

    this.detailsService.getparamS(this.selectedC).subscribe(result => {
      this.selectedS = result;
    }, error => console.error(error));

    this.detailsService.getparamF(this.selectedC).subscribe(result => {
      this.selectedF = result;
    }, error => console.error(error));

    this.detailsService.getparamB(this.selectedC).subscribe(result => {
      this.selectedB = result;
    }, error => console.error(error));
    console.log(this.selectedC);
  }
  public countrychange(price: number) {
    var c = new Country("");
    c.gold = -price;
    this.detailsService.countrychange(c, this.selectedC.countryId).subscribe(result => this.selectedC = result, error => console.error(error));
  }

  public selector(id: number) {
    this.detailsService.selector(id).subscribe(result => {
      this.selectedC = result;
      this.getAll(this.selectedC.countryId);
      console.log("asd", result);
    }, error => console.error(error));
  }

  public putunit(id: number) {
    console.log("asd");
    if (this.selectedC.gold >= this.selectedA.price && this.details0 > this.unitnumber) {
      this.errormsg = null;
      this.detailsService.buyOneUnit(this.selectedC, id)
        .subscribe(result => {
          this.getAll(this.targetid);
        }, error => console.error(error));
    } else {
      this.errormsg = "NINCS RÁ PÉNZED TE CSÖVES !!!!!!!";
      
    }
  }
  public puthorseman(id: number) {
    if (this.selectedC.gold >= this.selectedA.price && this.details0 > this.unitnumber) {
      this.errormsg = null;
      this.detailsService.buyOneUnit(this.selectedC, id)
        .subscribe(result => {
          this.getAll(this.targetid);
        }, error => console.error(error));
    } else { this.errormsg = "NINCS RÁ PÉNZED TE CSÖVES !!!!!!!"; }
  }
  public putsoldier(id: number) {
    if (this.selectedC.gold >= this.selectedA.price && this.details0 > this.unitnumber) {
      this.errormsg = null;
      this.detailsService.buyOneUnit(this.selectedC, id)
        .subscribe(result => {
          this.getAll(this.targetid);
        }, error => console.error(error));
    } else { this.errormsg = "NINCS RÁ PÉNZED TE CSÖVES !!!!!!!"; }
  }
  public putfarm(id: number) {
    console.log(this.selectedF);
    if (this.selectedC.gold >= this.selectedF.price) {
      this.errormsg = null;
      this.detailsService.buyOneBuilding(this.selectedC, this.selectedF.buildingId)
        .subscribe(result => {
          this.getAll(this.targetid);
        }, error => console.error(error));
    } else {
      this.errormsg = "NINCS RÁ PÉNZED TE CSÖVES !!!!!!!";
      this.disabler1 = true;
      
    }
  }
  public putbarrack(id: number) {
    
    if (this.selectedC.gold >= this.selectedA.price) {
      this.errormsg = null;
      this.detailsService.buyOneBuilding(this.selectedC, this.selectedB.buildingId)
        .subscribe(result => {
          this.getAll(this.targetid);
        }, error => console.error(error));
    } else {
    this.errormsg = "NINCS RÁ PÉNZED TE CSÖVES !!!!!!!";
     
    }
  }

  public createPlatoon() {
    this.detailsService.createPlatoon(this.selectedC).subscribe(r => {
      console.log(r);
      this.getAll(this.targetid);
    });

  }
  public refreshPlatoon() {
    this.detailsService.getPlatoon(this.selectedC.countryId).subscribe(r => this.platoon = r);
  }

  public PutArcherToPlatoon() {
    this.detailsService.PutArcherToPlatoon(this.platoon ,this.selectedC.countryId)
      .subscribe(r => { this.platoon = r; this.getAll(this.targetid); });
  }
  public PutHorsemanInPlatoon() {
    this.detailsService.PutHorsemanInPlatoon(this.platoon, this.selectedC.countryId)
      .subscribe(r => { this.platoon = r; this.getAll(this.targetid); });
  }
  public PutSoldierInPlatoon() {
    this.detailsService.PutSoldierInPlatoon(this.platoon, this.selectedC.countryId)
      .subscribe(r => { this.platoon = r; this.getAll(this.targetid); });
  }

  public AttackCountry(target: number, platoonid: number) {
    //console.log(platoonid);
    this.detailsService.AttackCountry(platoonid, target)
      .subscribe(r => { this.platoon = r; this.getAll(this.targetid); });
    
  }
  public selectPlatoon(xxx: number) {
    console.log(xxx);

    for (var t = 0; t < this.platoons.length; t++) {
      if (xxx == this.platoons[t].platoonId) { this.platoon = this.platoons[t]; }
    }
    console.log(this.platoon);



  }

  public capacity() {
    this.details0 = null;
    if (this.selectedB != null) {

      this.details0 = this.selectedB.counter * this.selectedB.capacity;
      return this.details0;
    }
  }
  public farmers() {
    this.details1 = null;
    if (this.selectedF != null) {
      this.details1 = this.selectedF.counter * this.selectedF.population
      return this.details1;
    }
  }
  public potatoesperround() {
    this.details2 = null;
    if (this.selectedF != null) {
      this.details2 = this.selectedF.counter * this.selectedF.potatoesPerRound;
      if (this.selectedC.tractor == true) { this.details2 = this.details2 * 1.1 }
      return this.details2;
    }
  }

  public unitnumberCounter() {
    this.unitnumber = null;
    if (this.selectedA != null && this.selectedS != null && this.selectedH != null) {
      this.unitnumber = this.selectedA.counter + this.selectedS.counter + 2 * this.selectedH.counter;
      
      return this.unitnumber
    }
  }





}
