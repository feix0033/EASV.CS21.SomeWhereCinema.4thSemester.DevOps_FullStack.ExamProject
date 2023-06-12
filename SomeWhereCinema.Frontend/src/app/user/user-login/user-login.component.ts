import { Component } from '@angular/core';
import {FirebaseAuthService} from "../../shard/services/firebaseService/firebase-auth.service";
import {Router} from "@angular/router";
import {UserDto} from "../../shard/interfaces/user-dto";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
   user:UserDto = {
    name:'',
    email:'',
    tel:0,
  };
  password: string = "";
  auth: any;

  constructor(public firebaseAuthService:FirebaseAuthService, private router:Router,) {
    this.auth  = firebaseAuthService.auth;
  }

  userLogin(user,password) {
    try {
      this.firebaseAuthService.logIn(user.email, this.password)
    } catch (err) {
      console.log(err);
    }
    this.router.navigateByUrl("/");
  }
}

