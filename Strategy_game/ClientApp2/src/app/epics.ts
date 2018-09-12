import { Injectable } from '@angular/core';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/startWith';
import { CountryService } from './countrymanager/country.service';
import { GameActions } from './app.actions';
import { Epic, createEpicMiddleware, ActionsObservable, ofType, combineEpics } from 'redux-observable';

import { IGameState } from '../store'
import { dispatch } from '@angular-redux/store';
import { mergeMap, mapTo, switchMap, catchError, map } from 'rxjs/operators';
import { AnyAction } from 'redux';
import { error } from 'util';
const epicMiddleware = createEpicMiddleware();
import 'rxjs';
import { of } from 'rxjs';







@Injectable()
export class GameAPIEpics {
  constructor(
    private service: CountryService,
    private actions: GameActions,
  ) {
  }

  saveCounterEpic = (action$: ActionsObservable<AnyAction>) => {

    return action$
      .ofType(GameActions.PLUS_ROUND)
      .pipe(
      mergeMap(() => {
        return this.service.nextRound(1)
            .pipe(
          map(result => ({
            type: GameActions.LOAD_SUCCEEDED
              })),
          catchError(error => of({
            type: GameActions.LOAD_FAILED
              }))
            );
        })
      );
  }


  



  //public createLoadGameEpic(): Epic {
  //  console.log("asd");

  //  return (action$, store) => action$
  //    .switchMap(() => this.service.refreshUsers()
  //      .map(data => this.actions.loadSucceeded(data))
  //      .catch(response => of(this.actions.loadFailed("asd")))
  //  );

  //};

  
}

