import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';
import { WyszukiwanieGrobowcowComponent } from './grobowiec/wyszukiwanie-grobowcow/wyszukiwanie-grobowcow.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { ZmarliComponent } from './zmarli/zmarli.component';
import { UzytkownikLoginComponent } from './uzytkownik/uzytkownik-login/uzytkownik-login.component';
import { UzytkownikComponent } from './uzytkownik/uzytkownik.component';

const routes: Routes = [
      { path: '', component: MainpageComponent },
      { path: 'odwiedzajacy', component: OdwiedzajacyComponent },
      { path: 'grobowiec/:id', component: GrobowiecComponent },
      { path: 'wyszukiwanie-grobowcow', component: WyszukiwanieGrobowcowComponent },
      { path: 'zmarli', component:ZmarliComponent },
      { path: 'login', component: UzytkownikLoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
