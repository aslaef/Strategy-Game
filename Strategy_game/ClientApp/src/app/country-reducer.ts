import { UsersActions, UsersActionTypes } from './actions';
import { IPack } from './models/country';
import { CountryActions, CountryActionTypes } from './country-actions';


export interface State {
  countryPack: IPack;
  pending: boolean;
  errorMessage: string;
  CountryId: number;
}

export const initialState: State = {
    countryPack: null,
  pending: false,
  errorMessage: null,
  CountryId: null,
};

export function reducer(state = initialState, action: CountryActions): State {
  console.log(action);
  switch (action.type) {
    case CountryActionTypes.GetCountry: {
      return {
        ...state,
        pending: true,
        errorMessage: null,
      };
    }
    case CountryActionTypes.GetCountrySuccess: {
      return {
        ...state,
        pending: false,
        errorMessage: null,
        countryPack: action.payload,
      };
    }
    case CountryActionTypes.GetCountryFailure: {
      return {
        ...state,
        pending: false,
        errorMessage: action.payload,
      };
    }
    case CountryActionTypes.PutUnit: {
        return {
          ...state,
          pending: true,
          errorMessage: null,
        };
      }
      case CountryActionTypes.PutUnitSuccess: {
        return {
          ...state,
          pending: false,
          errorMessage: null,
          countryPack: action.payload,
        };
      }
      case CountryActionTypes.PutUnitFailure: {
        return {
          ...state,
          pending: false,
          errorMessage: action.payload,
        };
      }
      case CountryActionTypes.BuyUnit: {
        return {
          ...state,
          pending: true,
          errorMessage: null,
        };
      }
      case CountryActionTypes.BuyUnitSuccess: {
        return {
          ...state,
          pending: false,
          errorMessage: null,
          countryPack: action.payload,
        };
      }
      case CountryActionTypes.BuyUnitFailure: {
        return {
          ...state,
          pending: false,
          errorMessage: action.payload,
        };
      }
      case CountryActionTypes.SetIntentToAttack: {
        return {
          ...state,
          pending: true,
          errorMessage: null,
        };
      }
      case CountryActionTypes.SetIntentToAttackSuccess: {
        return {
          ...state,
          pending: false,
          errorMessage: null,
          countryPack: action.payload,
        };
      }
      case CountryActionTypes.SetIntentToAttackFailure: {
        return {
          ...state,
          pending: false,
          errorMessage: action.payload,
        };
      }
      
    default:
      return state;
  }
}
