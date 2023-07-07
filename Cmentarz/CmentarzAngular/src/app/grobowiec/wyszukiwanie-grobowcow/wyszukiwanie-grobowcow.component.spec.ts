import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WyszukiwanieGrobowcowComponent } from './wyszukiwanie-grobowcow.component';

describe('WyszukiwanieGrobowcowComponent', () => {
  let component: WyszukiwanieGrobowcowComponent;
  let fixture: ComponentFixture<WyszukiwanieGrobowcowComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WyszukiwanieGrobowcowComponent]
    });
    fixture = TestBed.createComponent(WyszukiwanieGrobowcowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
