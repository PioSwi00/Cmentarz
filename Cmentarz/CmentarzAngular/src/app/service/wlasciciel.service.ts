import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class WlascicielService {
  private readonly apiUrl = 'https://localhost:7116/api/WlascicielApi';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getWlasciciele(): Observable<any[]> {
    if (this.authService.getIsLoggedIn()) {
      return this.http.get<any[]>(`${this.apiUrl}`);
    } else {
      // Obsługa braku zalogowania
      return new Observable<any[]>();
    }
  }

  getWlascicielById(id: number): Observable<any> {
    if (this.authService.getIsLoggedIn()) {
      return this.http.get<any>(`${this.apiUrl}/${id}`);
    } else {
      // Obsługa braku zalogowania
      return new Observable<any>();
    }
  }

  // Inne metody związane z właścicielami
}
