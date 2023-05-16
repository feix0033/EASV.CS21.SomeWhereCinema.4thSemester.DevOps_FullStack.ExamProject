import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/firestore';

@Injectable({
  providedIn: 'root'
})
export class FirestoreService {
  private firestore: any;
  values: any[] = [];

  constructor(public firebaseService:FirebaseService) {
    this.firestore = firebaseService.firebaseApplication.firestore();
    this.firestore.useEmulator('127.0.0.1:8081');
  }

  create(collectionPath:string, field:any){
    this.firestore.collection(collectionPath).add(field);
  }

  read(collection: string) {
    this.firestore
      .collection(collection)
      .onSnapshot(snapshot => { snapshot.docChanges().forEach( change => {
          if (change.type == "added") {
            this.values.push({id: change.doc.id, data: change.doc.data()});
          }
          if (change.type == 'modified') {
            const index = this.values.findIndex(modified => modified.id != change.doc.id);
            this.values[index] = {id: change.doc.id, data: change.doc.data()}
          }
          if (change.type == 'removed') {
            this.values = this.values.filter(removed => removed.id != change.doc.id)
          }
      })});
  }

}
