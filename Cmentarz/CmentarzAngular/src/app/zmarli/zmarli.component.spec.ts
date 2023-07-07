import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ZmarliComponent } from './zmarli.component';

describe('ZmarliComponent', () => {
  let component: ZmarliComponent;
  let fixture: ComponentFixture<ZmarliComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ZmarliComponent]
    });
    fixture = TestBed.createComponent(ZmarliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
