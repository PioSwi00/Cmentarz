import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly loggedInUserIdKey = 'loggedInUserId';
  private isLoggedIn = new BehaviorSubject<boolean>(this.hasValidToken()); // Sprawdzanie tokena przy inicjalizacji
  public isLoggedIn$ = this.isLoggedIn.asObservable();

  constructor() {}

  private hasValidToken(): boolean {
    const token = localStorage.getItem('token'); // Sprawdź obecność tokenu
    return token !== null && token !== undefined && token !== '';
  }
}
