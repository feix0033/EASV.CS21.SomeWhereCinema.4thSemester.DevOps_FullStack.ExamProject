import { Component } from '@angular/core';
import {FirebaseAuthService} from "../../shard/services/firebaseService/firebase-auth.service";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  email: string = "";
  password: string = "";
  constructor(public firebaseAuthService:FirebaseAuthService) {
  }

  userLogin(){

  }
  userLogout(){

  }
}

