import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovieRoutingModule } from './movie-routing.module';
import { MovieInfoComponent } from './movie-info/movie-info.component';
import {FormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Overlay} from "@angular/cdk/overlay";


@NgModule({
  declarations: [
    MovieInfoComponent
  ],
  imports: [
    CommonModule,
    MovieRoutingModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ],

})
export class MovieModule { }
