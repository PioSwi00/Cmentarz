import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { HttpClientModule } from '@angular/common/http';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';
import { WyszukiwanieGrobowcowComponent } from './grobowiec/wyszukiwanie-grobowcow/wyszukiwanie-grobowcow.component';
import { FormsModule } from '@angular/forms';
import { MainpageComponent } from './mainpage/mainpage.component';
import { ZmarliComponent } from './zmarli/zmarli.component';
import { LokalizacjaComponent } from './lokalizacja/lokalizacja.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    OdwiedzajacyComponent,
    GrobowiecComponent,
    WyszukiwanieGrobowcowComponent,
    MainpageComponent,
    ZmarliComponent,
    LokalizacjaComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatTooltipModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
