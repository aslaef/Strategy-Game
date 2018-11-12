import { UsersActions, UsersActionTypes } from './actions';


export interface State {
  pending: boolean;
  errorMessage: string;
  PageCount: number;
  PageNumber: number;
  Count: number;
}

export const initialState: State = {
  pending: false,
  errorMessage: null,
  PageCount: 0,
  PageNumber: 1,
  Count: 0,
};

export function reducer(state = initialState, action: UsersActions): State {
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

      };
    }
    case UsersActionTypes.LoginFailure: {
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
