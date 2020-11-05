import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SharedModule} from '../shared/shared.module';
import {MatSliderModule} from '@angular/material/slider';
import { HolidayPreferencesDialogComponent } from './holiday-preferences-dialog/holiday-preferences-dialog.component';


@NgModule({
    declarations: [
        HolidayPreferencesDialogComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        MatSliderModule
    ],
    entryComponents: [
        HolidayPreferencesDialogComponent
    ],
})
export class HolidayPreferencesModule {}

