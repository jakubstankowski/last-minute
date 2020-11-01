import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {HolidayPreferencesListComponent} from './holiday-preferences-list/holiday-preferences-list.component';
import {HolidayPreferencesRoutingModule} from './holiday-preferences-routing.module';
import {SharedModule} from '../shared/shared.module';
import { HolidayPreferencesEditComponent } from './holiday-preferences-edit/holiday-preferences-edit.component';
import { HolidayPreferencesCreateComponent } from './holiday-preferences-create/holiday-preferences-create.component';


@NgModule({
    declarations: [
        HolidayPreferencesListComponent,
        HolidayPreferencesEditComponent,
        HolidayPreferencesCreateComponent
    ],
    imports: [
        CommonModule,
        HolidayPreferencesRoutingModule,
        SharedModule
    ]
})
export class HolidayPreferencesModule {}

