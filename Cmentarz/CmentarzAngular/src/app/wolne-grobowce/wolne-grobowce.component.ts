import { Component, OnInit } from '@angular/core';
import { TokenService } from '../service/token.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-wolne-grobowce',
  templateUrl: './wolne-grobowce.component.html',
  styleUrls: ['./wolne-grobowce.component.css']
})
export class WolneGrobowceComponent implements OnInit {
  wolneGroby: any[] = [];

  constructor(public http: HttpClient, public tokenService: TokenService) { }

  ngOnInit(): void {
    if (!this.tokenService.hasToken()) {
      console.log('Użytkownik nie jest zalogowany.');
      return;
    }

    this.http.get<any[]>('/api/PobierzWolneGroby').subscribe(
      (response) => {
        this.wolneGroby = response;
      },
      (error) => {
        console.error('Wystąpił błąd podczas pobierania wolnych grobów.', error);
      }
    );
  }
}
