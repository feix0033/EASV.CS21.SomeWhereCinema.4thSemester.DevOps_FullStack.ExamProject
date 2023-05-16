import {Component, OnDestroy} from '@angular/core';
import {FirebaseAuthService} from "./firebaseService/firebase-auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy{
  title = 'SomeWhereCinema.Frontend';


  constructor(private firebaseAuthService:FirebaseAuthService) {
  }

  ngOnDestroy(): void {
    // this.firebaseAuthService.logOut();
  }
}
