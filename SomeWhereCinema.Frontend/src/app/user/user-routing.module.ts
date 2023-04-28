import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserRegisterComponent} from "./user-register/user-register.component";
import {UserInfoComponent} from "./user-info/user-info.component";

const routes: Routes = [
  {path: '', component: UserRegisterComponent},
  {path: 'userInfo', component: UserInfoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
