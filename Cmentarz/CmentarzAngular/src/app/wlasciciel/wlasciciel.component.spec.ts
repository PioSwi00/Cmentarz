import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WlascicielComponent } from './wlasciciel.component';

describe('WlascicielComponent', () => {
  let component: WlascicielComponent;
  let fixture: ComponentFixture<WlascicielComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WlascicielComponent]
    });
    fixture = TestBed.createComponent(WlascicielComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
