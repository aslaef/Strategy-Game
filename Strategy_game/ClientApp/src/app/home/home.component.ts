import { Component, OnInit } from '@angular/core';
import { UserService } from '../services';
import { Store } from '@ngrx/store';
import { State } from '../reducer';
import { Register } from '../actions';
import { UserLogin } from '../models/user-login';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    private store: Store<State>,
    private userService: UserService) { }

  ngOnInit() {

  }

  register(n: string, pw?: string, cname?: string) {
    console.log(n);
    const user: UserLogin = {
      Name: n,
      CountryName: pw,
      Pass: cname,
    };
    this.store.dispatch(new Register(user));
  }
}
