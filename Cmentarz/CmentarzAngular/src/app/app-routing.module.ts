import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';
import { WyszukiwanieGrobowcowComponent } from './grobowiec/wyszukiwanie-grobowcow/wyszukiwanie-grobowcow.component';
import { MainpageComponent } from './mainpage/mainpage.component';

const routes: Routes = [
      { path: '', component: MainpageComponent },
      { path: 'odwiedzajacy', component: OdwiedzajacyComponent },
      { path: 'grobowiec/:id', component: GrobowiecComponent },
      { path: 'wyszukiwanie-grobowcow', component: WyszukiwanieGrobowcowComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
