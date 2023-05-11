import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MovieInfoComponent} from "./movie-info/movie-info.component";
import {MovieManageComponent} from "./movie-manage/movie-manage.component";

const routes: Routes = [
  {path: '', component: MovieInfoComponent},
  {path: 'manage', component:MovieManageComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieRoutingModule { }
