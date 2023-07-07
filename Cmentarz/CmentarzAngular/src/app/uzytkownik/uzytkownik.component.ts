import { Component, OnInit } from '@angular/core';
import { UzytkownikService } from '../service/uzytkownik.service';

@Component({
  selector: 'app-uzytkownik',
  templateUrl: './uzytkownik.component.html',
  styleUrls: ['./uzytkownik.component.css']
})
export class UzytkownikComponent implements OnInit {
  zalogowany: boolean = false;

  constructor(private uzytkownikService: UzytkownikService) { }

  ngOnInit(): void {
    this.uzytkownikService.zaloguj({ login: '', haslo: '' }).subscribe(
      () => {
        this.zalogowany = true;
      },
      () => {
        this.zalogowany = false;
      }
    );    
  }
}
