import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { State } from '../reducer';
import { UserService } from '../services';
import { ICountry, IUnit, IBuilding, IPlatoon } from '../models/country';
import { ActivatedRoute } from '@angular/router';

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
  targetid;
  public unitCapacity: number;

  public countryId = 1;
  constructor(private store: Store<State>,
    private userService: UserService, private route: ActivatedRoute,
    ) { }

  ngOnInit() {
    this.targetid = this.route.snapshot.paramMap.get('countryId');

    this.getAll(this.targetid);
  }

  getAll(id: number) {
    this.userService.getAllFor(id).subscribe(result => {
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

  countTrue() {
    let counter = 0;
    if (this.selectedC.alchemy === true) { counter += 1; }
    if (this.selectedC.combine === true) { counter += 1; }
    if (this.selectedC.commander === true) { counter += 1; }
    if (this.selectedC.tactican === true) { counter += 1; }
    if (this.selectedC.wall === true) { counter += 1; }
    if (this.selectedC.tractor === true) { counter += 1; }
    return counter;
  }

  upgrade(n: number) {
    this.userService.upgrade(this.targetid, n).subscribe(r => this.getAll(this.targetid));
  }

  putunit(id: number) {
    this.userService.putUnit(this.selectedC, id)
    .subscribe(result => {
      this.getAll(this.targetid);
    }, error => console.error(error));
  }

  putbuilding(id: number) {
    console.log(id);
    this.userService.putbuilding(this.selectedC, id)
    .subscribe(result => {
      this.getAll(this.targetid);
    }, error => console.error(error));
  }

  PutUnitToPlatoon(platoonId: number, selectedPlatoonUnit) {
    this.userService.putUnitToPlatoon(platoonId, selectedPlatoonUnit)
    .subscribe(result =>
        this.getAll(this.targetid)
      );
  }

  CreatePlatoon(countryId: number) {

    this.userService.CreatePlatoon(this.selectedC.countryId).subscribe(r => this.getAll(this.targetid));
  }

  AttackCountry(platoonid: number, target?: number) {
    // console.log(platoonid);
    this.userService.AttackCountry(platoonid, target)
      .subscribe(r => {this.getAll(this.targetid); });

    if (target == null) {console.error('válassz ellenfelet!'); }
  }
}
