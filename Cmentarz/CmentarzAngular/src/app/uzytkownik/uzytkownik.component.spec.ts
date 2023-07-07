import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UzytkownikComponent } from './uzytkownik.component';

describe('UzytkownikComponent', () => {
  let component: UzytkownikComponent;
  let fixture: ComponentFixture<UzytkownikComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UzytkownikComponent]
    });
    fixture = TestBed.createComponent(UzytkownikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
