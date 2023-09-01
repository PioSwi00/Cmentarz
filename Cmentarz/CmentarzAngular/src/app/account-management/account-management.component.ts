import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { UzytkownikService } from '../service/uzytkownik.service';
import { TokenService } from '../service/token.service';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-account-management',
  templateUrl: './account-management.component.html',
  styleUrls: ['./account-management.component.css']
})
export class AccountManagementComponent implements OnInit {
  public showDeleteConfirmation: boolean = false;
  public newPassword: string = '';
  public isLoggedIn: boolean = false;
  public userId: number | null = null;
  
  constructor(private uzytkownikService: UzytkownikService, private tokenService: TokenService) { }
  
  ngOnInit(): void {
    this.isLoggedIn = this.tokenService.hasToken();
    
    if (this.isLoggedIn) {
      const token = this.tokenService.getToken();
      if (token) {
        // Dodaj token do nagłówka Authorization
        const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
        
        // Pobierz identyfikator użytkownika na podstawie tokenu
        this.uzytkownikService.getUserIdFromToken(token).subscribe(
          (userId) => {
            this.userId = userId;
          },
          (error) => {
            console.error('Błąd podczas pobierania identyfikatora użytkownika z tokenu:', error);
            // Obsłuż błąd pobierania identyfikatora użytkownika
          }
        );
      }
    }
  }
  

  public deleteAccount(): void {
    this.showDeleteConfirmation = true;
  }

  public confirmDeleteAccount(): void {
    if (this.isLoggedIn) {
      const token = this.tokenService.getToken(); // Pobierz token
      if (token) {
        this.uzytkownikService.usunUzytkownikaWithToken(token).subscribe(
          () => {
            // Pomyślnie usunięto konto, wyloguj użytkownika
            this.tokenService.removeToken(); // Usuń token po usunięciu konta
            this.isLoggedIn = false; // Ustaw stan zalogowania na false
          },
          (error) => {
            console.error('Błąd podczas usuwania konta:', error);
            // Obsłuż błąd usuwania konta
          }
        );
      }
    }
  }

  public cancelDeleteAccount(): void {
    this.showDeleteConfirmation = false;
  }

  public changePassword(): void {
    if (this.isLoggedIn) {
      const token = this.tokenService.getToken();
      if (token) {
        //console.log(token)
        this.uzytkownikService.getUserIdFromToken(token).subscribe(
          (userId) => {
            if (userId !== null) {
              this.uzytkownikService.zmienHaslo(userId, this.newPassword).subscribe(
                () => {
                  // Pomyślnie zmieniono hasło
                  console.log('Zmieniono hasło.');
                },
                (error) => {
                  console.error('Błąd podczas zmiany hasła:', error);
                  // Obsłuż błąd zmiany hasła
                }
              );
            }
          },
          (error) => {
            console.error('Błąd podczas pobierania identyfikatora użytkownika z tokenu:', error);
            // Obsłuż błąd pobierania identyfikatora użytkownika
          }
        );
      }
    }
  }
  
}
