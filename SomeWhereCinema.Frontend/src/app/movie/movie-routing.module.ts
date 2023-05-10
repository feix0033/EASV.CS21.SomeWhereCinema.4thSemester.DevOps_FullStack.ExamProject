import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MovieInfoComponent} from "./movie-info/movie-info.component";

const routes: Routes = [
  {path: '', component: MovieInfoComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieRoutingModule { }
