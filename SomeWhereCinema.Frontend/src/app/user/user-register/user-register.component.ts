import {Component, OnInit} from '@angular/core';
import {FirebaseAuthService} from "../../firebaseService/firebase-auth.service";

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent {
  constructor(public firebaseAuthService:FirebaseAuthService) {
  }
}
