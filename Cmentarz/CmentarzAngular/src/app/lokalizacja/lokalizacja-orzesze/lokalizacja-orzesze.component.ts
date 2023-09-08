import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Grobowiec } from 'src/app/models/grobowiec';
import { GrobowiecService } from 'src/app/service/grobowiec.service';

@Component({
  selector: 'app-lokalizacja-orzesze',
  templateUrl: './lokalizacja-orzesze.component.html',
  styleUrls: ['./lokalizacja-orzesze.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class LokalizacjaOrzeszeComponent implements OnInit {
  sektorA: Grobowiec[] = [];
  sektorB: Grobowiec[] = [];
  sektorC: Grobowiec[] = [];
  sektorD: Grobowiec[] = [];
  sektorE: Grobowiec[] = [];

  selectedGraves: Grobowiec[] = [];
  tooltipMessage: string = '';

  constructor(private grobowiecService: GrobowiecService) { }

  ngOnInit() {
    this.wyszukajGrobowce();
  }

  wyszukajGrobowce(): void {
    this.grobowiecService.wyszukajGroby({}).subscribe(
      (wyniki: Grobowiec[]) => {
        this.sektorA = wyniki.filter(g => g.sektor=="A" &&g.lokalizacja=="Orzesze" );
        this.sektorB = wyniki.filter(g => g.sektor=="B" &&g.lokalizacja=="Orzesze");
        this.sektorC = wyniki.filter(g => g.sektor=="C" &&g.lokalizacja=="Orzesze");
        this.sektorD = wyniki.filter(g => g.sektor=="D" &&g.lokalizacja=="Orzesze");
        this.sektorE = wyniki.filter(g => g.sektor=="E" &&g.lokalizacja=="Orzesze");
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  showGraves(sektor: Grobowiec[]): void {
    this.selectedGraves = sektor;
    this.tooltipMessage = this.getTooltipMessage(sektor);
  }

  hideGraves(): void {
    this.selectedGraves = [];
    this.tooltipMessage = '';
  }

  private getTooltipMessage(sektor: Grobowiec[]): string {
    if (sektor.length === 0) {
      return 'Brak grobów';
    } else if (sektor.length === 1) {
      return '1 grob';
    } else {
      return `${sektor.length} grobów`;
    }
  }
}
