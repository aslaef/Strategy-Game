import { Injectable } from '@angular/core';
import { Action } from 'redux';
import { dispatch } from '@angular-redux/store';
import { FluxStandardAction } from 'flux-standard-action';
import { IGame } from './classes/Country';

type Payload = IGame;
interface MetaData { asd: string; };

export type AnimalAPIAction = FluxStandardAction<Payload, MetaData>;

@Injectable()
export class GameActions{
  static readonly PLUS_ROUND = 'PLUS_ROUND';
  static readonly LOAD_SUCCEEDED = 'LOAD_SUCCEEDED';
  static readonly LOAD_FAILED = 'LOAD_FAILED';


  @dispatch()
  plus_round(): Action {
    return { type: GameActions.PLUS_ROUND };
  }

  loadSucceeded(data): Action{
    console.log("success");
    return { type: GameActions.LOAD_SUCCEEDED };
  }

  loadFailed(error_log: string): Action {
    return { type: GameActions.LOAD_FAILED };
  }
}
