import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { HttpClientModule } from '@angular/common/http';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';

@NgModule({
  declarations: [
    AppComponent,
    OdwiedzajacyComponent,
    GrobowiecComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
