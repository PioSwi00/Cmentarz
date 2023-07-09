import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajZmarlegoComponent } from './dodaj-zmarlego.component';

describe('DodajZmarlegoComponent', () => {
  let component: DodajZmarlegoComponent;
  let fixture: ComponentFixture<DodajZmarlegoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DodajZmarlegoComponent]
    });
    fixture = TestBed.createComponent(DodajZmarlegoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
