import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HolidayOffersListComponent} from './holiday-offers-list/holiday-offers-list.component';
import {HolidayOffersRoutingModule} from './holiday-offers-routing.module';
import {SharedModule} from '../shared/shared.module';


@NgModule({
    declarations: [
        HolidayOffersListComponent
    ],
    imports: [
        CommonModule,
        HolidayOffersRoutingModule,
        SharedModule
    ]
})
export class HolidayOffersModule {
}
