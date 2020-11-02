import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {HolidayPreferencesRoutingModule} from './holiday-preferences-routing.module';
import {SharedModule} from '../shared/shared.module';
import { HolidayPreferencesComponent } from './holiday-preferences/holiday-preferences.component';


@NgModule({
    declarations: [
        HolidayPreferencesComponent
    ],
    imports: [
        CommonModule,
        HolidayPreferencesRoutingModule,
        SharedModule
    ]
})
export class HolidayPreferencesModule {}

