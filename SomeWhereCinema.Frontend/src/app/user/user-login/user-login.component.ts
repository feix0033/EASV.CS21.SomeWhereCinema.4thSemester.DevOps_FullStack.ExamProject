import { Component } from '@angular/core';
import {FirestoreService} from "../../firebaseService/firestore.service";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  email: any;
  password: any;
  constructor(public firestoreService:FirestoreService) {
  }
}

