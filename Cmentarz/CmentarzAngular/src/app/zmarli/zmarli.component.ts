import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Zmarly } from '../models/zmarly';
import { ZmarlyService } from '../service/zmarly.service';

@Component({
  selector: 'app-zmarli',
  templateUrl: './zmarli.component.html',
  styleUrls: ['./zmarli.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ZmarliComponent implements OnInit {
  zmarli: Zmarly[] = [];

  constructor(private zmarliService: ZmarlyService) { }

  ngOnInit(): void {
    this.pobierzZmarlych();
  }

  pobierzZmarlych(): void {
    this.zmarliService.pobierzWszystkichZmarlych().subscribe(
      (response: Zmarly[]) => {
        this.zmarli = response;
      },
      (error: any) => {
        console.log('Wystąpił błąd podczas pobierania zmarłych.', error);
      }
    );
  }
}
