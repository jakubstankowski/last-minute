import { TestBed } from '@angular/core/testing';

import { HolidayPreferencesService } from './holiday-preferences.service';

describe('HolidayPreferencesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HolidayPreferencesService = TestBed.get(HolidayPreferencesService);
    expect(service).toBeTruthy();
  });
});
