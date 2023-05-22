import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {OrderingComponent} from "./ordering.component";

const routes: Routes = [
  {path:'', component:OrderingComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrderingRoutingModule { }
