import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {UserRegisterComponent} from "./user/user-register/user-register.component";
import {UserLoginComponent} from "./user/user-login/user-login.component";

const routes: Routes = [
  {path: '', loadChildren: () => import('./movie/movie.module').then(l => l.MovieModule)},
  {path: 'user', loadChildren: () => import('./user/user.module').then(l => l.UserModule)},
  {path: 'ordering', loadChildren: () => import('./ordering/ordering.module').then((l => l.OrderingModule))},
  {path: 'userRegister', component: UserRegisterComponent},
  {path: 'userLogin', component:UserLoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
