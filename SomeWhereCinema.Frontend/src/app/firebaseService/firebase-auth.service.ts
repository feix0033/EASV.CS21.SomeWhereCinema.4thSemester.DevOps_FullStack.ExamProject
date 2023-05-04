import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/auth';

@Injectable({
  providedIn: 'root'
})
export class FirebaseAuthService {
  auth: any;

  constructor(public firebaseService:FirebaseService) {
    this.auth = firebaseService.firebaseApplication.auth();
    this.auth.useEmulator('http://localhost:9099')
  }
  register(email:string, password:string){
    this.auth.createUserWithEmailAndPassword(email, password);
    // this.logIn(email,password);
  }
  logIn(email:string, password:string){
    this.auth.signInWithEmailAndPassword(email, password);
  }
  logOut(){
    this.auth.signOut();
  }
}
