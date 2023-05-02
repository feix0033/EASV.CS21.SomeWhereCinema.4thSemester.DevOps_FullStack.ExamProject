import { Component } from '@angular/core';
import {FirestoreService} from "../../firebaseService/firestore.service";
import {FirebaseAuthService} from "../../firebaseService/firebase-auth.service";
import {UserLogoutComponent} from "../user-logout/user-logout.component";
import {UserInfoComponent} from "../user-info/user-info.component";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  email: any;
  password: any;
  constructor(public firestoreService:FirestoreService, public firebaseAuthService:FirebaseAuthService) {
  }

  protected readonly UserLogoutComponent = UserLogoutComponent;
  protected readonly UserInfoComponent = UserInfoComponent;
}

