import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayPreferencesComponent } from './holiday-preferences.component';

describe('HolidayPreferencesComponent', () => {
  let component: HolidayPreferencesComponent;
  let fixture: ComponentFixture<HolidayPreferencesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayPreferencesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayPreferencesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
