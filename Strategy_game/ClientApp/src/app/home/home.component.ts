import { Component, OnInit } from '@angular/core';
import { UserService } from '../services';
import { Store } from '@ngrx/store';
import { State } from '../reducer';
import { Register, Login } from '../actions';
import { UserLogin } from '../models/user-dto';

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
      CountryName: cname,
      Pass: pw,
    };
    this.store.dispatch(new Register(user));
  }
  login(n: string, pw?: string) {
    console.log(n);
    const user: UserLogin = {
      Name: n,
      Pass: pw,
    };
    this.store.dispatch(new Login(user));
  }

}
