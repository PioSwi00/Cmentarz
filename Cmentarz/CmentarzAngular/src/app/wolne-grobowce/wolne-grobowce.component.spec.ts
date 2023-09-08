import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WolneGrobowceComponent } from './wolne-grobowce.component';

describe('WolneGrobowceComponent', () => {
  let component: WolneGrobowceComponent;
  let fixture: ComponentFixture<WolneGrobowceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WolneGrobowceComponent]
    });
    fixture = TestBed.createComponent(WolneGrobowceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
