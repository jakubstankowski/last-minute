import { TestBed } from '@angular/core/testing';

import { HolidayOffersService } from './holiday-offers.service';

describe('HolidayOffersService', () => {
  let service: HolidayOffersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HolidayOffersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
