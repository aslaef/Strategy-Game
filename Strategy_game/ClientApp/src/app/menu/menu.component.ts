import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  targetid;
  constructor(    private route: ActivatedRoute,
    ) {
    this.targetid = this.route.snapshot.paramMap.get('countryId');

   }

  ngOnInit() {
  }

}
