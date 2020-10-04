import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayOffersListComponent } from './holiday-offers-list.component';

describe('HolidayOffersListComponent', () => {
  let component: HolidayOffersListComponent;
  let fixture: ComponentFixture<HolidayOffersListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayOffersListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayOffersListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
