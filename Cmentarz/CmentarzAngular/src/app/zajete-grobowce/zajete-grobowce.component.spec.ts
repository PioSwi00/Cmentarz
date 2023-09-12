import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZajeteGrobowceComponent } from './zajete-grobowce.component';

describe('ZajeteGrobowceComponent', () => {
  let component: ZajeteGrobowceComponent;
  let fixture: ComponentFixture<ZajeteGrobowceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ZajeteGrobowceComponent]
    });
    fixture = TestBed.createComponent(ZajeteGrobowceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
