import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HolidayPreferencesDialogComponent } from './holiday-preferences-dialog.component';

describe('HolidayPreferencesDialogComponent', () => {
  let component: HolidayPreferencesDialogComponent;
  let fixture: ComponentFixture<HolidayPreferencesDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HolidayPreferencesDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayPreferencesDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
