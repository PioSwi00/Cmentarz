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
import { UzytkownikComponent } from './uzytkownik/uzytkownik.component';
import { UzytkownikLoginComponent } from './uzytkownik/uzytkownik-login/uzytkownik-login.component';


@NgModule({
  declarations: [
    AppComponent,
    OdwiedzajacyComponent,
    GrobowiecComponent,
    WyszukiwanieGrobowcowComponent,
    MainpageComponent,
    UzytkownikComponent,
    UzytkownikLoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
