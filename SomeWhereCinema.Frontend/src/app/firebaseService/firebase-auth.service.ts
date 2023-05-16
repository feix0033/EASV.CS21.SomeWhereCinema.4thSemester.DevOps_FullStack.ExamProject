import { Injectable } from '@angular/core';
import {FirebaseService} from "./firebase.service";
import 'firebase/compat/auth';
import {FormBuilder, FormGroup} from "@angular/forms";

@Injectable({
  providedIn: 'root'
})

export class FirebaseAuthService {
  auth: any;
  userForm = this.formBuilder.group({
    firstName: "",
    secondName: "",
    email: "",
    password: "",
    telephoneNumber: 0,
  });

  constructor(public firebaseService:FirebaseService, public formBuilder:FormBuilder) {
    this.auth = firebaseService.firebaseApplication.auth();
    this.auth.useEmulator('http://localhost:9099')

  }
  register(userForm){
    this.auth.createUserWithEmailAndPassword(userForm.email, userForm.password);
  }
  logIn(email:string, password:string){
    this.auth.signInWithEmailAndPassword(email, password)
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
