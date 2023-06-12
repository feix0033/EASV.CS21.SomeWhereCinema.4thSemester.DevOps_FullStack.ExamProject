import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {FirebaseAuthService} from "../../shard/services/firebaseService/firebase-auth.service";
import {FirestoreService} from "../../shard/services/firebaseService/firestore.service";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit{
  auth: any;
  orders: any[] = [];

  constructor(public firebaseAuthService:FirebaseAuthService, public firestoreService:FirestoreService){
  }

  ngOnInit(): void {
    this.auth = this.firebaseAuthService.auth;
    this.firestoreService.readAll(this.auth.currentUser.uid)
      .then(docs => {
        for (const doc of docs) {
          this.orders.push(doc);
        }
      })
  }
}
