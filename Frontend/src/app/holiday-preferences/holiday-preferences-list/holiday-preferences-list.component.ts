import {Component, OnInit} from '@angular/core';
import {IPreferences} from '../../shared/models/preferences';
import {HolidayPreferencesService} from '../holiday-preferences.service';

@Component({
    selector: 'app-holiday-preferences-list',
    templateUrl: './holiday-preferences-list.component.html',
    styleUrls: ['./holiday-preferences-list.component.css']
})
export class HolidayPreferencesListComponent implements OnInit {
    preferences: IPreferences;

    constructor(private holidayPreferencesService: HolidayPreferencesService) {
    }

    ngOnInit() {
        this.getPreferences();
    }

    getPreferences() {
        this.holidayPreferencesService.getHolidayPreferences()
            .subscribe(preferences => this.preferences = preferences);
    }
}
