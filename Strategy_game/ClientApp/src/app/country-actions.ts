import { Action } from '@ngrx/store';
import { UserLogin } from './models/user-dto';
import { IPack, IUnit } from './models/country';

export enum CountryActionTypes {
    GetCountry = '[Country] Load Country',
    GetCountrySuccess = '[Country] Load Country success',
    GetCountryFailure = '[Country] Load Country failure',

    PutUnit = '[Country] Put unit',
    PutUnitSuccess = '[Country] Put unit success',
    PutUnitFailure = '[Country] Put unit failure',

    BuyUnit = '[Country] Buy unit',
    BuyUnitSuccess = '[Country] Buy unit success',
    BuyUnitFailure = '[Country] Buy unit failure',
    
    SetIntentToAttack = '[Country] Attack country',
    SetIntentToAttackSuccess = '[Country] Attack country success',
    SetIntentToAttackFailure = '[Country] Attack country failure',
}
export class SetIntentToAttack implements Action {
    public readonly type = CountryActionTypes.SetIntentToAttack;
    constructor(public payload?: number) { }
  }
  
  export class SetIntentToAttackSuccess implements Action {
    public readonly type = CountryActionTypes.SetIntentToAttackSuccess;
    constructor(public payload?: IPack) { }
  }
  
  export class SetIntentToAttackFailure implements Action {
    public readonly type = CountryActionTypes.SetIntentToAttackFailure;
    constructor(public payload?: string) { }
  }

export class BuyUnit implements Action {
    public readonly type = CountryActionTypes.BuyUnit;
    constructor(public payload?: number) { }
  }
  
  export class BuyUnitSuccess implements Action {
    public readonly type = CountryActionTypes.BuyUnitSuccess;
    constructor(public payload?: IPack) { }
  }
  
  export class BuyUnitFailure implements Action {
    public readonly type = CountryActionTypes.BuyUnitFailure;
    constructor(public payload?: string) { }
  }

export class PutUnit implements Action {
    public readonly type = CountryActionTypes.PutUnit;
    constructor(public payload?: number) { }
  }
  
  export class PutUnitSuccess implements Action {
    public readonly type = CountryActionTypes.PutUnitSuccess;
    constructor(public payload?: IPack) { }
  }
  
  export class PutUnitFailure implements Action {
    public readonly type = CountryActionTypes.PutUnitFailure;
    constructor(public payload?: string) { }
  }

export class GetCountry implements Action {
  public readonly type = CountryActionTypes.GetCountry;
  constructor(public payload?: number) { }
}

export class GetCountrySuccess implements Action {
  public readonly type = CountryActionTypes.GetCountrySuccess;
  constructor(public payload?: IPack) { }
}

export class GetCountryFailure implements Action {
  public readonly type = CountryActionTypes.GetCountryFailure;
  constructor(public payload?: string) { }
}

export type CountryActions =
GetCountry |
GetCountrySuccess |
GetCountryFailure | 
PutUnit | 
PutUnitSuccess| 
PutUnitFailure | 
BuyUnit |
BuyUnitSuccess |
BuyUnitFailure | 
SetIntentToAttack | 
SetIntentToAttackSuccess | 
SetIntentToAttackFailure;
