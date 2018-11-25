
export interface IGame {
    gameId: number;
    roundNumber: number;
  }
  
  
  export interface ICountry {
    countryId?: number;
    tractor: boolean;
    countryName: string;
    combine: boolean;
    wall: boolean;
    commander: boolean;
    tactican: boolean;
    alchemy: boolean;
    gold: number;
    potatoes: number;
  }
  
  export class Country implements ICountry {
    countryId: number;
    tractor: boolean;
    countryName: string;
    combine: boolean;
    wall: boolean;
    commander: boolean;
    tactican: boolean;
    alchemy: boolean;
    gold: number;
    potatoes: number;
    constructor(CountryName: string) { this.countryName = CountryName; }
  }
  
  
  export interface IBuilding{
    counter: number;
    buildingId: number;
    capacity?: number;
    population?: number;
    potatoesPerRound?: number;
    price: number;
    builder: number;
  }
  
  
  export interface IUnit {
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
  
  export interface IPack {
    c: ICountry;
    a: IUnit;
    h: IUnit;
    s: IUnit;
    f: IBuilding;
    b: IBuilding;
    p: IPlatoon[];
    cs: ICountry[];
  }
  
  
  export interface IPlatoon {
    platoonId: number;
    c: ICountry;
    a: IUnit;
    h: IUnit;
    s: IUnit;
  }
  