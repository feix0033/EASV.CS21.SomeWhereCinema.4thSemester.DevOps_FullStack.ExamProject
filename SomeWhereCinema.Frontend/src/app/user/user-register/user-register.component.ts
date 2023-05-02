import { Component } from '@angular/core';
import {FirebaseAuthService} from "../../firebaseService/firebase-auth.service";

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent {
  email: any;
  password: any;
  constructor(public firebaseAuth:FirebaseAuthService) {
  }
}
