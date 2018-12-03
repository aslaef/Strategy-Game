import { UsersActions, UsersActionTypes } from './actions';


export interface State {
  pending: boolean;
  errorMessage: string;
  CountryId: number;
}

export const initialState: State = {
  pending: false,
  errorMessage: null,
  CountryId: null,
};

export function reducer(state = initialState, action: UsersActions): State {
  console.log(action);
  switch (action.type) {
    case UsersActionTypes.Login: {
      return {
        ...state,
        pending: true,
        errorMessage: null,
      };
    }
    case UsersActionTypes.LoginSuccess: {
      return {
        ...state,
        pending: false,
        errorMessage: null,
        CountryId: action.payload,
      };
    }
    case UsersActionTypes.LoginFailure: {
      return {
        ...state,
        pending: false,
        errorMessage: action.payload,
      };
    }
    case UsersActionTypes.Register: {
      return {
        ...state,
        pending: true,
        errorMessage: null,
      };
    }
    case UsersActionTypes.RegisterSuccess: {
      return {
        ...state,
        pending: false,
        errorMessage: null,

      };
    }
    case UsersActionTypes.RegisterFailure: {
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
