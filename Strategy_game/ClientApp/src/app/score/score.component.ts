import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../models/user-dto';
import { UserService } from '../services';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreComponent implements OnInit {
  public users: UserLogin[];


  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getscore();
  }

  getscore() {
    this.userService.getScoreList().subscribe(u => {
      this.users = u;
      console.log(u);
    }

      );
  }
}
