import { Component, OnInit } from '@angular/core';
import { UserService } from '../services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private userService: UserService) { userService.register(); }

  ngOnInit() {

  }

  register(n: string, pw?: string, cname?: string) {
    console.log('asd');
    this.userService.register();
  }
}
