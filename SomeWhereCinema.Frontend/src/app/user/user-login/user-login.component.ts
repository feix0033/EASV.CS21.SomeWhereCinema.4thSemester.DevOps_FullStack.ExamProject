import { Component } from '@angular/core';
import {FireService} from "../../fire.service";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  email: string = "";
  password = "";


  constructor(public fireService:FireService) {
  }
}
