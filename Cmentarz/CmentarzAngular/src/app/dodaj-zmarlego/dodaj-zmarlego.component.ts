import { Component } from '@angular/core';
import { Zmarly } from '../models/zmarly';
import { ZmarlyService } from '../service/zmarly.service';


@Component({
  selector: 'app-dodaj-zmarlego',
  templateUrl: './dodaj-zmarlego.component.html',
  styleUrls: ['./dodaj-zmarlego.component.css']
})
export class DodajZmarlegoComponent {
  imie: string = '';
  nazwisko: string = '';
  

  constructor(private zmarlyService: ZmarlyService) { }

  dodajZmarlego(): void {
    const zmarly: Zmarly = {
      imie: this.imie,
      nazwisko: this.nazwisko
    };
    this.zmarlyService.dodajZmarlego(zmarly).subscribe(() => {
      console.log('Zmarły został dodany.');
      // Wkonukinat daj
    }, (error) => {
      console.error('Błąd podczas dodawania zmarłego:', error);
 
    });
  }
}
