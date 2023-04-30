import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";
import {UserRegisterComponent} from "./user/user-register/user-register.component";
import {UserLoginComponent} from "./user/user-login/user-login.component";
import {HomepageComponent} from "./homepage/homepage.component";

const routes: Routes = [
  {path: '',component: HomepageComponent},
  {path: 'user', loadChildren: () => import('./user/user.module').then(l => l.UserModule)},
  {path: 'movie', loadChildren: () => import('./movie/movie.module').then(l => l.MovieModule)},
  {path: 'ordering', loadChildren: () => import('./ordering/ordering.module').then(l => l.OrderingModule)},
  {path: 'userRegister', component: UserRegisterComponent},
  {path: 'userLogin', component:UserLoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
