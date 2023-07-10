import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly isLoggedInKey = 'isLoggedIn';
  private readonly loggedInUserIdKey = 'loggedInUserId';
  private isLoggedIn = new BehaviorSubject<boolean>(false);
  public isLoggedIn$ = this.isLoggedIn.asObservable();

  constructor() {
    this.isLoggedIn.next(this.getLoggedInFromStorage());
  }

  setLoggedIn(value: boolean, userId?: number): void {
    this.isLoggedIn.next(value);
    this.saveLoggedInToStorage(value);
    if (value && userId !== undefined && userId !== null) {
      this.saveLoggedInUserIdToStorage(userId);
    }
  }

  getLoggedIn(): boolean {
    return this.isLoggedIn.getValue();
  }

  logout(): void {
    this.setLoggedIn(false);
    localStorage.removeItem(this.isLoggedInKey);
  }

  private saveLoggedInToStorage(value: boolean): void {
    localStorage.setItem(this.isLoggedInKey, value.toString());
  }

  getLoggedInUserId(): number | null {
    const userId = localStorage.getItem(this.loggedInUserIdKey);
    console.log('Pobrano identyfikator użytkownika z localStorage:', userId);
    return userId !== null ? parseInt(userId, 10) : null;
  }

  private saveLoggedInUserIdToStorage(userId: number): void {
    console.log('Zapisano identyfikator użytkownika w localStorage:', userId);
    localStorage.setItem(this.loggedInUserIdKey, userId.toString());
  }

  private getLoggedInFromStorage(): boolean {
    const value = localStorage.getItem(this.isLoggedInKey);
    return value === 'true';
  }
}
