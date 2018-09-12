import { Action } from 'redux';
import { GameActions } from './app/app.actions';

//export interface IAppState {
//  count: number;
//}



//export const INITIAL_STATE: IAppState = {
//  count: 0,
//};

export interface IGameState {
  gameId: number;
  roundNumber: number;
}
export const GAME_INITIAL: IGameState = {
  gameId: 0,
  roundNumber: 0,
};


//export function rootReducer(lastState: IAppState, action: Action): IAppState {
//  switch (action.type) {
//    case CounterActions.INCREMENT: return { count: lastState.count + 1 };
//    case CounterActions.DECREMENT: return { count: lastState.count - 1 };
//  }

//  // We don't care about any other actions right now.
//  return lastState;
//}

export function gameReducer(lastState: IGameState, action: Action): IGameState {
  switch (action.type) {
    case GameActions.PLUS_ROUND:
      return {
        ...lastState,
        roundNumber: lastState.roundNumber + 1
      };
    case GameActions.LOAD_SUCCEEDED:
      return {
        ...lastState,
        roundNumber: lastState.roundNumber + 1
      };
    case GameActions.LOAD_FAILED:
      return {
        ...lastState,
        roundNumber: lastState.roundNumber + 1
      };
  }
  return lastState;
}
