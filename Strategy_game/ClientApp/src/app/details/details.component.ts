import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from '../reducer';
import { UserService } from '../services';
import { ICountry, IUnit, IBuilding, IPlatoon } from '../models/country';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  public countries: ICountry[];
  public selectedC: ICountry;
  public selectedA: IUnit;
  public selectedH: IUnit;
  public selectedS: IUnit;
  public selectedF: IBuilding;
  public selectedB: IBuilding;
  public platoon: IPlatoon;
  public platoons: IPlatoon[];

  public unitCapacity: number;

  public countryId = 1004;
  constructor(private store: Store<State>,
    private userService: UserService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.userService.getAllFor(this.countryId).subscribe(result => {
      this.selectedC = result.c;
      this.selectedA = result.a;
      this.selectedH = result.h;
      this.selectedS = result.s;
      this.selectedF = result.f;
      this.selectedB = result.b;
      this.platoons = result.p;
      this.countries = result.cs;
    }, error => console.error(error));
  }



  upgrade(n: number) {
    this.userService.upgrade(this.countryId, n).subscribe(r => this.getAll());
  }

  putunit(id: number) {
    this.userService.putUnit(this.selectedC, id)
    .subscribe(result => {
      this.getAll();
    }, error => console.error(error));
  }

  putbuilding(id: number) {
    console.log(id);
    this.userService.putbuilding(this.selectedC, id)
    .subscribe(result => {
      this.getAll();
    }, error => console.error(error));
  }

  PutUnitToPlatoon(platoonId: number, selectedPlatoonUnit) {
    this.userService.putUnitToPlatoon(platoonId, selectedPlatoonUnit)
    .subscribe(result =>
        this.getAll()
      );
  }

  CreatePlatoon(countryId: number) {

    this.userService.CreatePlatoon(this.selectedC.countryId).subscribe(r => this.getAll());
  }

  AttackCountry(platoonid: number, target?: number) {
    // console.log(platoonid);
    this.userService.AttackCountry(platoonid, target)
      .subscribe(r => {this.getAll(); });

    if (target == null) {console.error('válassz ellenfelet!'); }
  }
}
