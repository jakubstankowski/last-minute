import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayPreferencesListComponent } from './holiday-preferences-list.component';

describe('HolidayPreferencesListComponent', () => {
  let component: HolidayPreferencesListComponent;
  let fixture: ComponentFixture<HolidayPreferencesListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayPreferencesListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayPreferencesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
