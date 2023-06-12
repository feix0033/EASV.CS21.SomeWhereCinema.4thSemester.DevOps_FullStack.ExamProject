import {Component, OnInit} from '@angular/core';
import {FirebaseAuthService} from "../../shard/services/firebaseService/firebase-auth.service";
import {UserDto} from "../../shard/interfaces/user-dto";
import {FirestoreService} from "../../shard/services/firebaseService/firestore.service";

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
    this.firebaseAuthService.register(user.email, password, user);
    this.firestoreService.create('UserInfo', {
        email: this.user.email
      });
  }

  signOut() {
    this.firebaseAuthService.logOut();
  }
}
