import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducer } from './reducer';
import { UsersEffects } from './effects';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { GameModule } from './game/game.module';
import { MenuComponent } from './menu/menu.component';
import { DetailsComponent } from './details/details.component';
import { ScoreComponent } from './score/score.component';
import { JwtInterceptor } from './_helper/JwtInterceptor.1';

export const effects = [
  UsersEffects,
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    DetailsComponent,
    ScoreComponent,

  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    GameModule,
    StoreModule.forRoot(reducer),
    EffectsModule.forRoot(effects),
  ],
  providers: [
    HttpClientModule,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
