import { UsersActions, UsersActionTypes } from './actions';
import { UserLogin } from './models/user-dto';


export interface State {
  pending: boolean;
  errorMessage: string;
  PageCount: number;
  PageNumber: number;
  Count: number;
  scores: UserLogin[];
}

export const initialState: State = {
  pending: false,
  errorMessage: null,
  PageCount: 0,
  PageNumber: 1,
  Count: 0,
  scores: [],
};

export function reducer(state = initialState, action: UsersActions): State {
  console.log('reducer');
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
    case UsersActionTypes.GetScore: {
      return {
        ...state,
        pending: true,
        errorMessage: null,
      };
    }
    case UsersActionTypes.GetScoreSuccess: {
      return {
        ...state,
        pending: false,
        errorMessage: null,
        scores: action.payload,
      };
    }
    case UsersActionTypes.GetScoreFailure: {
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
