import { Component } from '@angular/core';
import {UserService} from "../user.service";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  email: any;
  password: any;
  constructor(public userService: UserService) {
  }
}

