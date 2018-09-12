import { Injectable } from '@angular/core';
import { Action, AnyAction } from 'redux';
import { dispatch } from '@angular-redux/store';
import { FluxStandardAction } from 'flux-standard-action';
import { IGame } from './classes/Country';

type Payload = IGame;
interface MetaData { asd: string; };

export type GameAction = FluxStandardAction<Payload, MetaData>;



@Injectable()
export class GameActions{
  static readonly PLUS_ROUND = 'PLUS_ROUND';
  static readonly LOAD_SUCCEEDED = 'LOAD_SUCCEEDED';
  static readonly LOAD_FAILED = 'LOAD_FAILED';

  static readonly GET_ROUND = 'GET_ROUND';
  static readonly ROUND_OK = 'ROUND_OK';
  static readonly ROUND_FAILED = 'ROUND_FAILED';

  get_round(): GameAction {
    
    return {
      type: GameActions.GET_ROUND,

    }
  }
  round_ok(data): GameAction {
    return {
      type: GameActions.ROUND_OK,
      payload: data
    }
  }








  plus_round(): GameAction {
    console.log('1');
    return {
      type: GameActions.PLUS_ROUND,
      payload: null
    };
  }

  loadSucceeded(data: Payload): GameAction {
    console.log(data);
    return {
      type: GameActions.LOAD_SUCCEEDED,
      payload: data
      
    };
  }
  //}
  //loadSucceeded = (payload: Payload): GameAction => (
  //  {
  //  type: GameActions.LOAD_SUCCEEDED,
  //  payload,
    
  //})
  loadFailed(error_log: string): Action {
    return { type: GameActions.LOAD_FAILED };
  }
}


@Injectable()
export class CountryActions {
  static readonly LOAD_COUNTRY = '';
}
