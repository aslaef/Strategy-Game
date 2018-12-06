import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { DetailsComponent } from './details/details.component';
import { ScoreComponent } from './score/score.component';
import { AuthGuard } from './_guards';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'menu/:countryId', component: MenuComponent, canActivate: [AuthGuard]  },
  {path: 'details/:countryId', component: DetailsComponent },
  {path: 'score/:countryId', component: ScoreComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],


})
export class AppRoutingModule {


 }
