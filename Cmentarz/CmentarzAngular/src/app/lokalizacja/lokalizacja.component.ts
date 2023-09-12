import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lokalizacja',
  templateUrl: './lokalizacja.component.html',
  styleUrls: ['./lokalizacja.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LokalizacjaComponent {
  constructor(private router: Router){}
  
  cmentarzOrzesze = {
    nazwa: 'Cmentarz Orzesze',
    endpoint: '/orzesze'
  };

  cmentarzSwierklany = {
    nazwa: 'Cmentarz Świerklany',
    endpoint: '/swierklany'
  };

  odwiedzGrob() : void{
  }
}