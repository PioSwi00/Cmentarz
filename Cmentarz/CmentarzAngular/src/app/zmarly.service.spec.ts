import { TestBed } from '@angular/core/testing';

import { ZmarlyService } from './service/zmarly.service';

describe('ZmarlyService', () => {
  let service: ZmarlyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ZmarlyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
