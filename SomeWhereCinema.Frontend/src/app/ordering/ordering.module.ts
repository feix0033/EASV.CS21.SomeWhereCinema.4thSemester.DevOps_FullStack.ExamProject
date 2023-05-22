import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderingRoutingModule } from './ordering-routing.module';
import { OrderingComponent } from './ordering.component';


@NgModule({
  declarations: [
    OrderingComponent
  ],
  exports: [
    OrderingComponent
  ],
  imports: [
    CommonModule,
    OrderingRoutingModule
  ]
})
export class OrderingModule { }
