import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { NgReduxModule, NgRedux } from '@angular-redux/store'; // <- New
import { gameReducer, IGameState, GAME_INITIAL } from '../store'; // < New
import { GameActions } from './app.actions'; // < New



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CountryManagerComponent } from './countrymanager/countrymanager.component';
import { CountryService } from './countrymanager/country.service';
import { ManagerComponent } from './manager/manager.component';
import { DetailsComponent } from './details/details.component';
import { DetailsService } from './details/details.service';
import { GameAPIEpics } from './epics';
import { applyMiddleware, createStore } from 'redux';
import { createEpicMiddleware, ofType, combineEpics } from 'redux-observable';
import { delay } from 'q';
import { mergeMap, switchMap, tap, ignoreElements } from 'rxjs/operators';
import { map } from 'rxjs/operators';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CountryManagerComponent,
    ManagerComponent,
    DetailsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgReduxModule, // <- New

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'countrymanager', component: CountryManagerComponent },
      { path: 'manager', component: ManagerComponent },
      { path: 'details/:id', component: DetailsComponent },
    ])
  ],
  providers:
    [CountryService, DetailsService, GameActions
      ,GameAPIEpics
    ],
  bootstrap: [AppComponent]
})

export class AppModule {

  constructor(
    ngRedux: NgRedux<IGameState>,
    gameEpics: GameAPIEpics
     
  ) {

    const epicMiddleware = createEpicMiddleware();

    
    
    ngRedux.configureStore(
      gameReducer,
      GAME_INITIAL,
      [epicMiddleware]
    );

    const rootEpic = combineEpics(
      gameEpics.round_switcher_epic,
      gameEpics.round_getter_epic

    );

    epicMiddleware.run(rootEpic);
  }
}

