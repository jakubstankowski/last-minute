import {Component, OnInit} from '@angular/core';
import {IPreferences} from '../../shared/models/preferences';
import {HolidayPreferencesService} from '../holiday-preferences.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';

@Component({
    selector: 'app-holiday-preferences-edit',
    templateUrl: './holiday-preferences-edit.component.html',
    styleUrls: ['./holiday-preferences-edit.component.css']
})
export class HolidayPreferencesEditComponent implements OnInit {
    preferences: IPreferences;
    preferenceForm: FormGroup;

    constructor(private holidayPreferencesService: HolidayPreferencesService) {
    }

    ngOnInit() {
        this.getPreference();
        this.createForm();
    }

    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                this.preferences = preferences;
            });
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required)
        });
    }

    updatePreference() {
        console.log('form: ', this.preferenceForm.value);
    }


}
