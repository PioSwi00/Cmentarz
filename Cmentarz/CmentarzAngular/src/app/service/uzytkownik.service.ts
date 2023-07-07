import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Uzytkownik } from '../models/uzytkownik';

@Injectable({
  providedIn: 'root'
})
export class UzytkownikService {
  private readonly apiUrl = 'https://localhost:7116/api/UzytkownikApi';

  constructor(private http: HttpClient) { }

  zaloguj(uzytkownik: Uzytkownik): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Login`, uzytkownik);
  }
}
