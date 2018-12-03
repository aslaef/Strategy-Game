import { Action } from '@ngrx/store';
import { UserLogin } from './models/user-dto';

export enum UsersActionTypes {
  Login = '[Users] Load users',
  LoginSuccess = '[Users] Load users success',
  LoginFailure = '[Users] Load users failure',
  Register = '[Users] Register users',
  RegisterSuccess = '[Users] Register users success',
  RegisterFailure = '[Users] Register users failure',
}

export class Login implements Action {
  public readonly type = UsersActionTypes.Login;
  constructor(public payload?: UserLogin) { }
}

export class LoginSuccess implements Action {
  public readonly type = UsersActionTypes.LoginSuccess;
  constructor(public payload?: number) { }
}

export class LoginFailure implements Action {
  public readonly type = UsersActionTypes.LoginFailure;
  constructor(public payload?: string) { }
}
export class Register implements Action {
  public readonly type = UsersActionTypes.Register;
  constructor(public payload: UserLogin) { }
}

export class RegisterSuccess implements Action {
  public readonly type = UsersActionTypes.RegisterSuccess;
  constructor() { }
}

export class RegisterFailure implements Action {
  public readonly type = UsersActionTypes.RegisterFailure;
  constructor(public payload?: string) { }
}
export type UsersActions =
  Login |
  LoginSuccess |
  LoginFailure |
  Register |
  RegisterSuccess |
  RegisterFailure;
