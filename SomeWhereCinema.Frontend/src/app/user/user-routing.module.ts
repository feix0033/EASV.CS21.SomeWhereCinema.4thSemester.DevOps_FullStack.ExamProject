import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserLoginComponent} from "./user-login/user-login.component";
import {UserRegisterComponent} from "./user-register/user-register.component";

const routes: Routes = [
  {path: 'userLogIn', component: UserLoginComponent},
  {path: 'userRegister', component: UserRegisterComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
