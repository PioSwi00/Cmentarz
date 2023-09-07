import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajWlascicielaComponent } from './dodaj-wlasciciela.component';

describe('DodajWlascicielaComponent', () => {
  let component: DodajWlascicielaComponent;
  let fixture: ComponentFixture<DodajWlascicielaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DodajWlascicielaComponent]
    });
    fixture = TestBed.createComponent(DodajWlascicielaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
