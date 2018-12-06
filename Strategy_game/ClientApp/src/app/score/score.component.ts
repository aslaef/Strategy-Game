import { Component, OnInit } from '@angular/core';
import { UserLogin } from '../models/user-dto';
import { UserService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { State } from '../reducer';
import { GetScore } from '../actions';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreComponent implements OnInit {
  public users$: Observable<UserLogin[]>;
  public users: UserLogin[];
  targetid;

  constructor(private userService: UserService, private route: ActivatedRoute, private store: Store<State>) { }

  ngOnInit() {
    this.targetid = this.route.snapshot.paramMap.get('countryId');
    this.getscore();
  }

  getscore() {

    this.store.dispatch(new GetScore());

    this.users$ = this.store.pipe(
      // filter(s => s != null),
      select(s => s.scores),
    );

    this.userService.getScoreList().subscribe(u => {
      this.users = u;
      console.log(u);
    }

      );
  }
}
