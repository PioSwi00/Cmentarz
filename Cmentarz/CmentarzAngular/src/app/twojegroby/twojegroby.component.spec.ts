import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwojegrobyComponent } from './twojegroby.component';

describe('TwojegrobyComponent', () => {
  let component: TwojegrobyComponent;
  let fixture: ComponentFixture<TwojegrobyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TwojegrobyComponent]
    });
    fixture = TestBed.createComponent(TwojegrobyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
