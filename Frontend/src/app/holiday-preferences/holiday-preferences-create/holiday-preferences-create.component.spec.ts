import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayPreferencesCreateComponent } from './holiday-preferences-create.component';

describe('HolidayPreferencesCreateComponent', () => {
  let component: HolidayPreferencesCreateComponent;
  let fixture: ComponentFixture<HolidayPreferencesCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayPreferencesCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayPreferencesCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
