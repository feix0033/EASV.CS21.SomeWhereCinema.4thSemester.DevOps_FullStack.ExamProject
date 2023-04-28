import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import {UserLoginComponent} from "./user-login/user-login.component";
import {UserLogoutComponent} from "./user-logout/user-logout.component";
import {UserRegisterComponent} from "./user-register/user-register.component";
import {FormsModule} from "@angular/forms";
import {UserInfoComponent} from "./user-info/user-info.component";


@NgModule({
  declarations: [
    UserLoginComponent,
    UserLogoutComponent,
    UserRegisterComponent,
    UserInfoComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
  ]
})
export class UserModule { }
