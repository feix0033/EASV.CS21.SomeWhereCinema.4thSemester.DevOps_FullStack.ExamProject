import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import {UserLoginComponent} from "./user-login/user-login.component";
import {UserRegisterComponent} from "./user-register/user-register.component";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {UserInfoComponent} from "./user-info/user-info.component";


@NgModule({
  declarations: [
    UserLoginComponent,
    UserRegisterComponent,
    UserInfoComponent
  ],
    imports: [
        CommonModule,
        UserRoutingModule,
        FormsModule,
        ReactiveFormsModule,
    ]
})
export class UserModule { }
