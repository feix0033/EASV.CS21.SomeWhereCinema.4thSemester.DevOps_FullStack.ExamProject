import { Component } from '@angular/core';
import {FirebaseAuthService} from "./firebaseService/firebase-auth.service";
import {UserService} from "./user/user.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SomeWhereCinema.Frontend';


  constructor(public userService:UserService) {
  }
}
