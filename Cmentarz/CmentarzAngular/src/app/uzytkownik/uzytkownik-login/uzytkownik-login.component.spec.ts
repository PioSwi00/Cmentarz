import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UzytkownikLoginComponent } from './uzytkownik-login.component';

describe('UzytkownikLoginComponent', () => {
  let component: UzytkownikLoginComponent;
  let fixture: ComponentFixture<UzytkownikLoginComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UzytkownikLoginComponent]
    });
    fixture = TestBed.createComponent(UzytkownikLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
