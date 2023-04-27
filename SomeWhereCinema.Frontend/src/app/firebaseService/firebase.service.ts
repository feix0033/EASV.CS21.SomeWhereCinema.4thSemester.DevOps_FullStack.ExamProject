import { Injectable } from '@angular/core';
import firebase from 'firebase/compat/app';

import * as config from '../../../firebaseconfig';



@Injectable({
  providedIn: 'root'
})
export class FirebaseService {
  firebaseApplication: any;
  firebase;

  constructor() {
    this.firebaseApplication = firebase.initializeApp(config.firebaseConfig);
    this.firebase = firebase;
  }

}
