import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OdwiedzajacyComponent } from './odwiedzajacy/odwiedzajacy.component';
import { GrobowiecComponent } from './grobowiec/grobowiec.component';

const routes: Routes = [
      { path: '', component: OdwiedzajacyComponent },
      { path: 'grobowiec/:id', component: GrobowiecComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
