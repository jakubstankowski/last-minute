import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayOffersComponent } from './holiday-offers.component';

describe('HolidayOffersComponent', () => {
  let component: HolidayOffersComponent;
  let fixture: ComponentFixture<HolidayOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HolidayOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
