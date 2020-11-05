import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {HolidayPreferencesRoutingModule} from './holiday-preferences-routing.module';
import {SharedModule} from '../shared/shared.module';
import { HolidayPreferencesComponent } from './holiday-preferences/holiday-preferences.component';
import {MatSliderModule} from '@angular/material/slider';
import { HolidayPreferencesDialogComponent } from './holiday-preferences-dialog/holiday-preferences-dialog.component';


@NgModule({
    declarations: [
        HolidayPreferencesComponent,
        HolidayPreferencesDialogComponent
    ],
    imports: [
        CommonModule,
        HolidayPreferencesRoutingModule,
        SharedModule,
        MatSliderModule
    ],
    entryComponents: [
        HolidayPreferencesDialogComponent
    ],
})
export class HolidayPreferencesModule {}

