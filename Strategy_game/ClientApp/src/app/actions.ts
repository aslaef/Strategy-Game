import { Action } from '@ngrx/store';

export enum UsersActionTypes {
  Login = '[Users] Load users',
  LoginSuccess = '[Users] Load users success',
  LoginFailure = '[Users] Load users failure',
}

export class Login implements Action {
  public readonly type = UsersActionTypes.Login;
  constructor(public payload?: string) { }
}

export class LoginSuccess implements Action {
  public readonly type = UsersActionTypes.LoginSuccess;
  constructor(public payload?: string) { }
}

export class LoginFailure implements Action {
  public readonly type = UsersActionTypes.LoginFailure;
  constructor(public payload?: string) { }
}

export type UsersActions =
  Login |
  LoginSuccess |
  LoginFailure;
