import { Injectable } from '@angular/core';

import firebase from 'firebase/compat/app';
import 'firebase/compat/auth';
import 'firebase/compat/firestore';
import 'firebase/compat/storage';

import * as config from '../../firebaseconfig';

@Injectable({
  providedIn: 'root'
})

export class FireService {
  firebaseApplication;
  firestore: firebase.firestore.Firestore;
  firebaseAuth: firebase.auth.Auth;


  constructor(){
    this.firebaseApplication = firebase.initializeApp(config.firebaseConfig);
    this.firebaseAuth = firebase.auth();
    this.firestore = firebase.firestore();
  }

  register(email:string, password: string){
    this.firebaseAuth.createUserWithEmailAndPassword(email,password);
  }

  signIn(email:string, password: string){
    this.firebaseAuth.signInWithEmailAndPassword(email,password);
  }

  signOut(){
    this.firebaseAuth.signOut();
  }

  getUser(){
    return this.firebaseAuth.currentUser;
  }




}
