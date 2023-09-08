import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';
import { WyszukiwanieGrobowcowComponent } from './grobowiec/wyszukiwanie-grobowcow/wyszukiwanie-grobowcow.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { ZmarliComponent } from './zmarli/zmarli.component';
import { LokalizacjaComponent } from './lokalizacja/lokalizacja.component';
import { UzytkownikLoginComponent } from './uzytkownik/uzytkownik-login/uzytkownik-login.component';
import { UzytkownikComponent } from './uzytkownik/uzytkownik.component';
import { WlascicielComponent } from './wlasciciel/wlasciciel.component';
import { RegisterComponent } from './uzytkownik/register/register.component';
import { DodajZmarlegoComponent } from './dodaj-zmarlego/dodaj-zmarlego.component';
import { AccountManagementComponent } from './account-management/account-management.component';
import { KupGrobowiecComponent } from './grobowiec/kup-grobowiec/kup-grobowiec.component';
import { HistoriaComponent } from './historia/historia.component';
import { DodajWlascicielaComponent } from './dodaj-wlasciciela/dodaj-wlasciciela.component';
import { LokalizacjaOrzeszeComponent } from './lokalizacja/lokalizacja-orzesze/lokalizacja-orzesze.component';
import { LokalizacjaSwierklanyComponent } from './lokalizacja/lokalizacja-swierklany/lokalizacja-swierklany.component';



const routes: Routes = [
      { path: '', component: MainpageComponent },
      { path: 'odwiedzajacy', component: OdwiedzajacyComponent },
      { path: 'grobowiec/:id', component: GrobowiecComponent },
      { path: 'wyszukiwanie-grobowcow', component: WyszukiwanieGrobowcowComponent },
      { path: 'zmarli', component:ZmarliComponent },
      { path: 'login', component:UzytkownikLoginComponent },
      { path: 'wlasciciele', component:WlascicielComponent },
      { path: 'lokalizacja', component:LokalizacjaComponent },
      { path: 'panel', component: UzytkownikComponent },
      { path: 'wlasciciele', component: WlascicielComponent }, 
      { path: 'login', component: UzytkownikLoginComponent },
      {path:'register',component: RegisterComponent },
      {path:'dodajzmarly',component: DodajZmarlegoComponent },
      {path: 'dodajWlasciciela', component: DodajWlascicielaComponent},
      {path: 'konto',component:AccountManagementComponent},
      {path: 'kupgrobowiec', component:KupGrobowiecComponent},
      {path:'historia',component:HistoriaComponent},
      { path:'orzesze',component:LokalizacjaOrzeszeComponent},
      { path:'swierklany',component:LokalizacjaSwierklanyComponent},
    
     
     
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
