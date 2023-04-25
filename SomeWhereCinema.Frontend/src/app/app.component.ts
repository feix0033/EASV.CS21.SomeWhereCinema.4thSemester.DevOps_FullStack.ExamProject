import { Component } from '@angular/core';
import {FireService} from "./fire.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SomeWhereCinema.Frontend';
  user;


  constructor(public firebaseService: FireService) {
  }

  protected readonly FireService = FireService;
}
