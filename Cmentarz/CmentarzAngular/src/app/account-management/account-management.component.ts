import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { UzytkownikService } from '../service/uzytkownik.service';

@Component({
  selector: 'app-account-management',
  templateUrl: './account-management.component.html',
  styleUrls: ['./account-management.component.css']
})
export class AccountManagementComponent implements OnInit {
  public showDeleteConfirmation: boolean = false;
  public newPassword: string = '';
  public isLoggedIn: boolean = false;

  constructor(private authService: AuthService, private uzytkownikService: UzytkownikService) { }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.getLoggedIn(); // Sprawdzenie czy użytkownik jest zalogowany
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn; // Aktualizacja statusu zalogowania
    });
  }

  public deleteAccount(): void {
    this.showDeleteConfirmation = true;
  }

  public confirmDeleteAccount(): void {
    if (this.isLoggedIn) {
      const userId = this.authService.getLoggedInUserId(); // Pobierz identyfikator aktualnie zalogowanego użytkownika
      if (userId !== null) { // Sprawdź czy userId nie jest nullem
        this.uzytkownikService.usunUzytkownika(userId).subscribe(
          () => {
            // Pomyślnie usunięto konto, wyloguj użytkownika
            this.authService.logout();
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
      const userId = this.authService.getLoggedInUserId(); // Pobierz identyfikator aktualnie zalogowanego użytkownika
      console.log(userId);
      if (userId !== null) { // Sprawdź czy userId nie jest nullem
        this.uzytkownikService.zmienHaslo(userId, this.newPassword).subscribe(
          () => {
            // Pomyślnie zmieniono hasło
           
            console.log("działa");
          },
          (error) => {
            console.error('Błąd podczas zmiany hasła:', error);
            // Obsłuż błąd zmiany hasła
          }
        );
      }
    }
  }
}
