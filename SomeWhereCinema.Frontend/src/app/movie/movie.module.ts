import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieRoutingModule } from './movie-routing.module';
import {FormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import { MovieComponent } from './movie.component';
import {OrderingModule} from "../ordering/ordering.module";


@NgModule({
    declarations: [
        MovieComponent
    ],
  imports: [
    CommonModule,
    MovieRoutingModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    OrderingModule
  ],

    exports: [
        MovieComponent
    ]
})
export class MovieModule { }
