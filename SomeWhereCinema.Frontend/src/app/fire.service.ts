import { Injectable } from '@angular/core';
import firebase from 'firebase/compat/app';
import 'firebase/compat/firestore';
import 'firebase/compat/auth';
import 'firebase/compat/storage';

import * as config from '../../firebaseconfig';
@Injectable({
  providedIn: 'root'
})
export class FireService {
  firebaseApplication;
  firestore: firebase.firestore.Firestore;
  testDate: any[] = [];


  constructor(){
    this.firebaseApplication = firebase.initializeApp(config.firebaseConfig);
    this.firestore = firebase.firestore();

    this.getTestData();
  }

  async getTestData() {
    this.firestore
      .collection('testCollection')
      .onSnapshot(snapshot => {
        snapshot
          .docChanges()
          .forEach(change => {
            this.testDate.push({
              testFieldData: change.doc.get('testField2'),
              data: change.doc.data(),
              id: change.doc.id,
            })
          })
      })
  }


}
