import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/auth';
import {UserDto} from "../../interfaces/user-dto";

@Injectable({
  providedIn: 'root'
})

export class FirebaseAuthService {
  auth;
  constructor(public firebaseService:FirebaseService) {
    this.auth = firebaseService.firebaseApplication.auth();
    this.auth.useEmulator('http://127.0.0.1:9099');
  }
   register(user: UserDto, password: string) {
     this.auth.createUserWithEmailAndPassword(user.email, password)
  }
  logIn(user:UserDto, password:string){
    this.auth.signInWithEmailAndPassword(user.email, password)
      .then(success => {
      console.log('logged in')
    }).catch(err => {
      console.log('not logged in' + err)
    })
  }
  logOut(){
    this.auth.signOut();
  }
}
