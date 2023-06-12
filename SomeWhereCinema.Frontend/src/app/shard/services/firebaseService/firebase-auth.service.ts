import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/auth';
import {UserDto} from "../../interfaces/user-dto";

@Injectable({
  providedIn: 'root'
})

export class FirebaseAuthService {

  auth: any;

  constructor(public firebaseService:FirebaseService) {
    this.auth = firebaseService.firebaseApplication.auth();
    this.auth.useEmulator('http://127.0.0.1:9099');
  }

   register(email: string, password: string, userDto:UserDto) {
     this.auth.createUserWithEmailAndPassword(email, password)
       .then(success => {
         this.auth.currentUser.updateProfile({
           displayName: userDto.name,
           phoneNumber: userDto.tel
         })
       })
       .catch(err => {console.log("user register failed : " + err)})
  }

  logIn(email, password:string){
    this.auth
      .signInWithEmailAndPassword(email, password)
      .then(success => { console.log('logged in!')})
      .catch(err => { console.log('not logged in: ' + err)})
  }

  logOut(){
    this.auth.signOut();
  }
}
