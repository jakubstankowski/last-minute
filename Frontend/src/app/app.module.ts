import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {AppComponent} from './app.component';
import {CoreModule} from './core/core.module';
import {SharedModule} from './shared/shared.module';
import {CustomMaterialModule} from './custom-material/custom-material.module';
import {AppRoutingModule} from './app-routing.module';
import {LoggerModule} from 'ngx-logger';
import {environment} from '../environments/environment';
import {HttpClientModule} from '@angular/common/http';
import {HolidayPreferencesDialogComponent} from "./holiday-preferences/holiday-preferences-dialog/holiday-preferences-dialog.component";
import {MatSliderModule} from "@angular/material/slider";
import { HolidayPreferencesCreateComponent } from './holiday-preferences/holiday-preferences-create/holiday-preferences-create.component';
import { ServiceWorkerModule } from '@angular/service-worker';


@NgModule({
    declarations: [
        AppComponent,
        HolidayPreferencesDialogComponent,
        HolidayPreferencesCreateComponent
    ],
    imports: [
        HttpClientModule,
        BrowserModule,
        BrowserAnimationsModule,
        CoreModule,
        SharedModule,
        CustomMaterialModule.forRoot(),
        AppRoutingModule,
        LoggerModule.forRoot({
            serverLoggingUrl: `http://my-api/logs`,
            level: environment.logLevel,
            serverLogLevel: environment.serverLogLevel
        }),
        MatSliderModule,
        ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
    ],
    entryComponents: [
        HolidayPreferencesDialogComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
