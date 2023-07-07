import { Component, OnInit } from '@angular/core';
import { UzytkownikService } from '../service/uzytkownik.service';
import { WlascicielService } from '../service/wlasciciel.service';

@Component({
  selector: 'app-uzytkownik',
  templateUrl: './uzytkownik.component.html',
  styleUrls: ['./uzytkownik.component.css']
})
export class UzytkownikComponent implements OnInit {
  zalogowany: boolean = false;

  constructor(private uzytkownikService: UzytkownikService, private wlascicielService: WlascicielService) { }

  ngOnInit(): void {
    this.uzytkownikService.zaloguj({ login: '', haslo: '' }).subscribe(
      () => {
        this.zalogowany = true;
        this.wlascicielService.getWlasciciele().subscribe(
          (response) => {
            console.log(response); // Sprawdź odpowiedź z danymi właścicieli w konsoli
          },
          (error) => {
            console.log('Błąd pobierania właścicieli:', error);
          }
        );
      },
      () => {
        this.zalogowany = false;
      }
    );
  }
}
