import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Grobowiec } from 'src/app/models/grobowiec';
import { GrobowiecService } from 'src/app/service/grobowiec.service';


@Component({
  selector: 'app-wyszukiwanie-grobowcow',
  templateUrl: './wyszukiwanie-grobowcow.component.html',
  styleUrls: ['./wyszukiwanie-grobowcow.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class WyszukiwanieGrobowcowComponent implements OnInit {
  idGrobu: number | undefined;
  idWlasciciel: number | undefined;
  lokalizacja: string | undefined;
  cena: number | undefined;
  wyniki: Grobowiec[] = [];
 


  constructor(private grobowiecService: GrobowiecService) { }

  ngOnInit() {
  }

  wyszukajGroby(): void {
    const parametry = {
      idGrobu: this.idGrobu,
      idWlasciciel: this.idWlasciciel,
      lokalizacja: this.lokalizacja,
      cena: this.cena
    };

    this.grobowiecService.wyszukajGroby(parametry).subscribe(
      (wyniki: Grobowiec[]) => {
        this.wyniki = wyniki;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}
