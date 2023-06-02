import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MovieComponent} from "./movie.component";
import {OrderingComponent} from "../ordering/ordering.component";

const routes: Routes = [
  {path: '', component: MovieComponent},
  {path:'ordering/:id', component:OrderingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovieRoutingModule { }
