import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupGrobowiecComponent } from './kup-grobowiec.component';

describe('KupGrobowiecComponent', () => {
  let component: KupGrobowiecComponent;
  let fixture: ComponentFixture<KupGrobowiecComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [KupGrobowiecComponent]
    });
    fixture = TestBed.createComponent(KupGrobowiecComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
