import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HolidayOffersListComponent} from './holiday-offers-list/holiday-offers-list.component';
import {HolidayOffersRoutingModule} from './holiday-offers-routing.module';
import {SharedModule} from '../shared/shared.module';
import {HolidayPreferencesDialogComponent} from "../holiday-preferences/holiday-preferences-dialog/holiday-preferences-dialog.component";


@NgModule({
    declarations: [
        HolidayOffersListComponent
    ],
    imports: [
        CommonModule,
        HolidayOffersRoutingModule,
        SharedModule
    ],
    entryComponents: [
    ]
})
export class HolidayOffersModule {
}
