import {Component} from '@angular/core';
import {FirebaseAuthService} from "./shard/services/firebaseService/firebase-auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  auth: any;

  constructor(private firebaseAuthService:FirebaseAuthService, private router:Router) {
    this.auth = firebaseAuthService.auth;
  }

  logout() {
    this.firebaseAuthService.auth.signOut();
  }


  routeToUserInfo() {
    this.router.navigateByUrl('/user')
  }
}
