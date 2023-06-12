import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderingRoutingModule } from './ordering-routing.module';
import { OrderingComponent } from './ordering.component';
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    OrderingComponent,
  ],
    imports: [
        CommonModule,
        OrderingRoutingModule,
        FormsModule,
        MatButtonModule,
    ]
})
export class OrderingModule { }
