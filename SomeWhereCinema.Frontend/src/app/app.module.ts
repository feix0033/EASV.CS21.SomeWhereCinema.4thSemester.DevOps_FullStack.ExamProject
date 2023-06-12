import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSnackBar} from "@angular/material/snack-bar";
import {Overlay} from "@angular/cdk/overlay";
import {NgModule} from "@angular/core";
import { IonicModule } from '@ionic/angular';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
    declarations: [
        AppComponent,
    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    IonicModule.forRoot({mode: "md"}),
    MatToolbarModule,
    MatButtonModule,
  ],
    providers: [MatSnackBar, Overlay],
    exports: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
