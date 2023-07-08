import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly isLoggedInKey = 'isLoggedIn';
  private isLoggedIn = new BehaviorSubject<boolean>(false);
  public isLoggedIn$ = this.isLoggedIn.asObservable();

  constructor() {
    this.isLoggedIn.next(this.getLoggedInFromStorage());
  }

  setLoggedIn(value: boolean): void {
    this.isLoggedIn.next(value);
    this.saveLoggedInToStorage(value);
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

  private getLoggedInFromStorage(): boolean {
    const value = localStorage.getItem(this.isLoggedInKey);
    return value === 'true';
  }
}
