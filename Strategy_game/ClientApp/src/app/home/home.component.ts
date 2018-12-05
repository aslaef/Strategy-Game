import { Component, OnInit } from '@angular/core';
import { UserService } from '../services';
import { Store } from '@ngrx/store';
import { State } from '../reducer';
import { Register, Login } from '../actions';
import { UserLogin } from '../models/user-dto';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  id: number;
  constructor(
    private store: Store<State>,
    private userService: UserService,
    private router: Router,
    ) { }

  ngOnInit() {

  }

  register(n: string, pw?: string, cname?: string) {
    console.log(n);
    const user: UserLogin = {
      name: n,
      countryName: cname,
      pass: pw,
    };
    this.store.dispatch(new Register(user));
  }
  login(n: string, pw?: string) {
    console.log(n);
    const user: UserLogin = {
      name: n,
      pass: pw,
    };
    this.userService.login(user).pipe(first())
    .subscribe(
        data => {
            this.router.navigate(['menu/' + data.countryId]);
        },
        error => {
            console.log(error);
        });
  }

}
