import { TestBed } from '@angular/core/testing';

import { HolidayOffersService } from './holiday-offers.service';

describe('HolidayOffersService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HolidayOffersService = TestBed.get(HolidayOffersService);
    expect(service).toBeTruthy();
  });
});
