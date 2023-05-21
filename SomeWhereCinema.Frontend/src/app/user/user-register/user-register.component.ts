import {Component, OnInit} from '@angular/core';
import {FirebaseAuthService} from "../../firebaseService/firebase-auth.service";
import {UserDto} from "../../dtoes/user-dto";
import {FirestoreService} from "../../firebaseService/firestore.service";

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.scss']
})
export class UserRegisterComponent {
  user: UserDto = {
    name:'',
    email:'',
    tel:0,
  }
  password = '';
  auth: any;

  constructor(private firebaseAuthService:FirebaseAuthService,private firestoreService:FirestoreService) {
    this.auth = firebaseAuthService.auth;
  }

  register(user: UserDto, password: string) {
    this.firebaseAuthService.register(user, password);
    this.firestoreService.create(
      'UserInfo',
      {
        name: user.name,
        email: user.email,
        tel: user.tel,
      });
  }
  signOut() {
    this.firebaseAuthService.logOut();
  }
}
