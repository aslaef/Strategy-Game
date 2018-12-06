import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { UserService } from './services';
import { Router } from '@angular/router';
import { UsersActionTypes, Login, LoginSuccess, LoginFailure, Register, RegisterSuccess,
  RegisterFailure, GetScore, GetScoreSuccess, GetScoreFailure } from './actions';
import { map, catchError, switchMap } from 'rxjs/operators';
import { of } from 'rxjs';


@Injectable()
export class UsersEffects {
  constructor(private actions$: Actions, private userService: UserService, private router: Router) { }

  @Effect()
  LogIn$ = this.actions$.pipe(
    ofType(UsersActionTypes.Login),
    switchMap(({payload}: Login) => this.userService.login(payload).pipe(
      map(response => new LoginSuccess(response)),
      catchError(error => of(new LoginFailure(error)))
    ))
  );

  @Effect()
  Register$ = this.actions$.pipe(
    ofType(UsersActionTypes.Register),
    switchMap(({payload}: Register) => this.userService.register(payload).pipe(
      map(response => new RegisterSuccess()),
      catchError(error => of(new RegisterFailure(error)))
    ))
  );

  @Effect()
  GetScore$ = this.actions$.pipe(
    ofType(UsersActionTypes.GetScore),
    switchMap(() => this.userService.getScoreList().pipe(
      map(response => new GetScoreSuccess(response)),
      catchError(error => of(new GetScoreFailure(error)))
    ))
  );
}
