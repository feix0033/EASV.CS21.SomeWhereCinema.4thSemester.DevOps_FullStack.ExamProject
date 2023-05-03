import { Injectable } from '@angular/core';
import {FirebaseAuthService} from "../firebaseService/firebase-auth.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private firebaseAuthService:FirebaseAuthService) {
  }

  getCurrentUser() {
    return this.firebaseAuthService.auth.currentUser;
  }

  getCurrentUserEmail() {
    return this.firebaseAuthService.auth.currentUser.email;
  }

  login(email: string, password: string) {
    this.firebaseAuthService.logIn(email,password);
  }

  register(email: string, password: string) {
    this.firebaseAuthService.register(email,password);
  }

  logOut() {
    this.firebaseAuthService.logOut();
  }
}
