import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';
import {FirebaseAuthService} from "../../shard/services/firebaseService/firebase-auth.service";
import {FirestoreService} from "../../shard/services/firebaseService/firestore.service";
import {UserDto} from "../../shard/interfaces/user-dto";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent{
  auth: any;
  values: any[] = [];
  constructor(public firebaseAuthService:FirebaseAuthService, public firestoreService:FirestoreService){
    this.auth  = firebaseAuthService.auth;
    this.firestoreService.read('UserInfo', 'email',this.auth.currentUser.email)
      .then(value => {
        this.values = value;
      })
  }
}
