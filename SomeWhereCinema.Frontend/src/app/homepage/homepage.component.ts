import { Component } from '@angular/core';
import {FirebaseAuthService} from "../firebaseService/firebase-auth.service";
import {FirebaseService} from "../firebaseService/firebase.service";

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent {


  constructor(public firebaseAuthService:FirebaseAuthService) {
  }
}
