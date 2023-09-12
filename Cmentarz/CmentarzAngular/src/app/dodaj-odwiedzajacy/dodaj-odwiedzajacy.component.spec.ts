import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajOdwiedzajacyComponent } from './dodaj-odwiedzajacy.component';

describe('DodajOdwiedzajacyComponent', () => {
  let component: DodajOdwiedzajacyComponent;
  let fixture: ComponentFixture<DodajOdwiedzajacyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DodajOdwiedzajacyComponent]
    });
    fixture = TestBed.createComponent(DodajOdwiedzajacyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
