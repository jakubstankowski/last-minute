import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HolidayPreferencesListComponent} from './holiday-preferences-list/holiday-preferences-list.component';
import {HolidayPreferencesRoutingModule} from './holiday-preferences-routing.module';
import {SharedModule} from '../shared/shared.module';


@NgModule({
    declarations: [
        HolidayPreferencesListComponent
    ],
    imports: [
        CommonModule,
        HolidayPreferencesRoutingModule,
        SharedModule
    ]
})
export class HolidayPreferencesModule {}

