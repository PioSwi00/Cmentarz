import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';

@Component({
  selector: 'app-lokalizacja',
  templateUrl: './lokalizacja.component.html',
  styleUrls: ['./lokalizacja.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LokalizacjaComponent {
  cmentarzOrzesze = {
    nazwa: 'Cmentarz Orzesze',
    endpoint: '/orzesze'
  };

  cmentarzSwierklany = {
    nazwa: 'Cmentarz Świerklany',
    endpoint: '/swierklany'
  };

}