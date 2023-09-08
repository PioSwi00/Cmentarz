import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LokalizacjaOrzeszeComponent } from './lokalizacja-orzesze.component';

describe('LokalizacjaOrzeszeComponent', () => {
  let component: LokalizacjaOrzeszeComponent;
  let fixture: ComponentFixture<LokalizacjaOrzeszeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LokalizacjaOrzeszeComponent]
    });
    fixture = TestBed.createComponent(LokalizacjaOrzeszeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
