import { Injectable } from '@angular/core';
import 'firebase/compat/firestore';
import {FirebaseService} from "./firebase.service";

@Injectable({
  providedIn: 'root'
})
export class FirestoreService {
  private firestore: any ;
  private data: any[]=[];

  constructor(private firebaseService:FirebaseService) {
    this.firestore = this.firebaseService.firebase.firestore();
  }

  create(){
    this.firestore.collection('user').add(this.data);
  }
}
