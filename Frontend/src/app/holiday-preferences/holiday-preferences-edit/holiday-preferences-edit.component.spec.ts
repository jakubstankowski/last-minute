import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayPreferencesEditComponent } from './holiday-preferences-edit.component';

describe('HolidayPreferencesEditComponent', () => {
  let component: HolidayPreferencesEditComponent;
  let fixture: ComponentFixture<HolidayPreferencesEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayPreferencesEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayPreferencesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
