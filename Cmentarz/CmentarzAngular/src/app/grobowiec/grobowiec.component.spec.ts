import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GrobowiecComponent } from './grobowiec.component';

describe('GrobowiecComponent', () => {
  let component: GrobowiecComponent;
  let fixture: ComponentFixture<GrobowiecComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GrobowiecComponent]
    });
    fixture = TestBed.createComponent(GrobowiecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
