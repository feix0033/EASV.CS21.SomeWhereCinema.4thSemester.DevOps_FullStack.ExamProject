import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";

const routes: Routes = [
  {path: 'home',component: AppComponent},
  {path: 'user', loadChildren: () => import('./user/user.module').then(l => l.UserModule)},
  {path: 'movie', loadChildren: () => import('./movie/movie.module').then(l => l.MovieModule)},
  {path: 'ordering', loadChildren: () => import('./ordering/ordering.module').then(l => l.OrderingModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
