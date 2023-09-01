import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Uzytkownik } from '../models/uzytkownik';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class UzytkownikService {
  private readonly apiUrl = 'https://localhost:7116/api/UzytkownikApi';
  
  constructor(
    private http: HttpClient,
    private tokenService: TokenService
  ) {}

  zaloguj(uzytkownik: Uzytkownik): Observable<any> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post<any>(`${this.apiUrl}/Login`, uzytkownik, { headers });
  }
  public usunUzytkownika(id: number): Observable<any> {
    const headers = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Authorization', `Bearer ${this.tokenService.getToken()}`);
  return this.http.delete<any>(`${this.apiUrl}/UsunUzytkownika/${id}`, { headers });
  }

  public zmienHaslo(id: number, noweHaslo: string): Observable<any> {
    const headers = new HttpHeaders()
    .set('Content-Type', 'application/json')
    .set('Authorization', `Bearer ${this.tokenService.getToken()}`);
  return this.http.put<any>(`${this.apiUrl}/ZmienHaslo/${id}`, `"${noweHaslo}"`, { headers });
  }
  
  usunUzytkownikaWithToken(token: string): Observable<any> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', `Bearer ${token}`);
    return this.http.delete<any>(`${this.apiUrl}/UsunUzytkownikaWithToken`, { headers });
  }

  getUserIdFromToken(token: string): Observable<number | null> {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', `Bearer ${token}`);
    return this.http.get<number | null>(`${this.apiUrl}/GetUserIdFromToken`, { headers });
  }  
}
  
