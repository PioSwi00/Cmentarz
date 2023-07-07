import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LokalizacjaComponent } from './lokalizacja.component';

describe('LokalizacjaComponent', () => {
  let component: LokalizacjaComponent;
  let fixture: ComponentFixture<LokalizacjaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LokalizacjaComponent]
    });
    fixture = TestBed.createComponent(LokalizacjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
