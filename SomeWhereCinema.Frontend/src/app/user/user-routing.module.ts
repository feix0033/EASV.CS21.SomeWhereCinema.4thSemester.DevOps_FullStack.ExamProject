import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserRegisterComponent} from "./user-register/user-register.component";
import {UserInfoComponent} from "./user-info/user-info.component";
import {UserLoginComponent} from "./user-login/user-login.component";

const routes: Routes = [
  {path: '', component: UserInfoComponent},
  {path: 'userRegister', component: UserRegisterComponent},
  {path: 'userLogIn', component: UserLoginComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
