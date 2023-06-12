import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/firestore';

@Injectable({
  providedIn: 'root'
})

export class FirestoreService {

  private firestore: any;
  values: any[] = [];
  orderDoc: any[] = [];

  constructor(public firebaseService:FirebaseService) {
    this.firestore = firebaseService.firebaseApplication.firestore();
    this.firestore.useEmulator('localhost',8081);
  }

  create(collectionPath:string, field:any){
    this.firestore.collection(collectionPath).add(field);
  }

  async read(collection:string,condition1:any,condition2:string) {
    const col = await this.firestore
      .collection(collection)
      .where(condition1,'==',condition2)
      .get();
    this.values = col.docs.map(d => d.data());
    return this.values;
  }

  async readAll(collection: string) {
    const col = await this.firestore
      .collection(collection)
      .get();
    this.orderDoc = col.docs.map(d => d.data());
    return this.orderDoc;
  }
}
