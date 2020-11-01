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
        this.getPreference();
    }

    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                this.preferences = preferences;
                console.log('preferences: ', preferences);
            });
    }
}
