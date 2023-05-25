import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderingRoutingModule } from './ordering-routing.module';
import { OrderingComponent } from './ordering.component';
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    OrderingComponent,
  ],
  imports: [
    CommonModule,
    OrderingRoutingModule,
    FormsModule,
  ]
})
export class OrderingModule { }
