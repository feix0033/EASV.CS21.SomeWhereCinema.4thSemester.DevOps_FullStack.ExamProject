import { Component } from '@angular/core';
import {FirebaseAuthService} from "../../firebaseService/firebase-auth.service";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {

  constructor(public firebaseAuthService:FirebaseAuthService) {
  }
}
