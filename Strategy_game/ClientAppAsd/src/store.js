"use strict";
var __assign = (this && this.__assign) || Object.assign || function(t) {
    for (var s, i = 1, n = arguments.length; i < n; i++) {
        s = arguments[i];
        for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
            t[p] = s[p];
    }
    return t;
};
Object.defineProperty(exports, "__esModule", { value: true });
var app_actions_1 = require("./app/app.actions");
exports.GAME_INITIAL = {
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
function gameReducer(lastState, action) {
    switch (action.type) {
        case app_actions_1.GameActions.PLUS_ROUND:
            return __assign({}, lastState, { roundNumber: lastState.roundNumber + 1 });
        case app_actions_1.GameActions.LOAD_SUCCEEDED:
            return __assign({}, lastState, { roundNumber: lastState.roundNumber + 1 });
        case app_actions_1.GameActions.LOAD_FAILED:
            return __assign({}, lastState, { roundNumber: lastState.roundNumber + 1 });
    }
    return lastState;
}
exports.gameReducer = gameReducer;
//# sourceMappingURL=store.js.map