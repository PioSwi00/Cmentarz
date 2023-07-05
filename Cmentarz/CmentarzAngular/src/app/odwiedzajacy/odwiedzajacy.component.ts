import { Component } from '@angular/core';
import { WyszukajOsobyResponse } from 'src/models/wyszukajosoby-response';
import { OdwiedzajacyService } from '../odwiedzajacy.service';

@Component({
  selector: 'app-odwiedzajacy',
  templateUrl: './odwiedzajacy.component.html',
  styleUrls: ['./odwiedzajacy.component.css']
})
export class OdwiedzajacyComponent {
  wyszukani: WyszukajOsobyResponse[] = [];

  wyszukajOdwiedzajacych(){
  }

  constructor(private odwiedzajacyService: OdwiedzajacyService){
    odwiedzajacyService.get().subscribe({
      next: (res) => {
        this.wyszukani = res;
      }
    })
  }
}
