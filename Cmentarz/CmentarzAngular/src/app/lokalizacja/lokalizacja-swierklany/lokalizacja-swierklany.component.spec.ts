import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LokalizacjaSwierklanyComponent } from './lokalizacja-swierklany.component';

describe('LokalizacjaSwierklanyComponent', () => {
  let component: LokalizacjaSwierklanyComponent;
  let fixture: ComponentFixture<LokalizacjaSwierklanyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LokalizacjaSwierklanyComponent]
    });
    fixture = TestBed.createComponent(LokalizacjaSwierklanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
