import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HolidayOffersListComponent} from './holiday-offers-list/holiday-offers-list.component';
import {HolidayOffersRoutingModule} from './holiday-offers-routing.module';
import {SharedModule} from '../shared/shared.module';
import {HolidayPreferencesListComponent} from '../holiday-preferences/holiday-preferences-list/holiday-preferences-list.component';


@NgModule({
    declarations: [
        HolidayOffersListComponent,
        HolidayPreferencesListComponent
    ],
    imports: [
        CommonModule,
        HolidayOffersRoutingModule,
        SharedModule
    ]
})
export class HolidayOffersModule {
}
