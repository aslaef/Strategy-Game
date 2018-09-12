import { Action, AnyAction } from 'redux';
import { GameActions, GameAction } from './app/app.actions';

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
  gameId: 1,
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

export function countryReducer(lastState: IGameState, action: GameAction) {
  
}





export function gameReducer(lastState: IGameState, action: GameAction): IGameState {
  console.log('in reducer');
  switch (action.type) {
    case GameActions.GET_ROUND:
      console.log('GET_ROUND')
      return {
        ...lastState,
        //roundNumber: lastState.roundNumber + 1
      };
    case GameActions.ROUND_OK:
      console.log('ROUND_OK')
      return {
        ...lastState,
        roundNumber: action.payload.roundNumber
      };



    case GameActions.PLUS_ROUND:
      console.log('in plus round')
      return {
        ...lastState,
        //roundNumber: lastState.roundNumber + 1
      };
    case GameActions.LOAD_SUCCEEDED:
      console.log('load succeeded')
      return {
        ...lastState,
        roundNumber: action.payload.roundNumber + 1
        
      };
    case GameActions.LOAD_FAILED:
      return {
        ...lastState,
      };
  }
  return lastState;
}
