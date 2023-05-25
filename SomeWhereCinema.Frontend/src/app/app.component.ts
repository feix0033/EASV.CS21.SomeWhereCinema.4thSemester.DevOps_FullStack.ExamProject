import {Component} from '@angular/core';
import {FirebaseAuthService} from "./shard/services/firebaseService/firebase-auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'SomeWhereCinema.Frontend';
  public auth;
  constructor(private firebaseAuthService:FirebaseAuthService) {
    this.auth = this.firebaseAuthService.auth;
  }
  logout() {
    this.auth.signOut();
  }
}
