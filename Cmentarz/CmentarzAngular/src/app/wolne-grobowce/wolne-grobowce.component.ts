import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { TokenService } from '../service/token.service';
import { HttpClient } from '@angular/common/http';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';

@Component({
  selector: 'app-wolne-grobowce',
  templateUrl: './wolne-grobowce.component.html',
  styleUrls: ['./wolne-grobowce.component.css'],
  encapsulation: ViewEncapsulation.None,
  
})
export class WolneGrobowceComponent implements OnInit {
  wolneGroby: Grobowiec[] = [];

  constructor(private grobowiecService: GrobowiecService) { }

  ngOnInit(): void {
    this.pobierzWolneGroby();
  }

  pobierzWolneGroby() {
    this.grobowiecService.pobierzWolneGroby().subscribe(
      (response) => {
        this.wolneGroby = response;
      },
      (error) => {
        console.error('Wystąpił błąd podczas pobierania wolnych grobów.', error);
      }
    );
  }
}





