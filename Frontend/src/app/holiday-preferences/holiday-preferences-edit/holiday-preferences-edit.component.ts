import {Component, OnInit} from '@angular/core';
import {IPreferences} from '../../shared/models/preferences';
import {HolidayPreferencesService} from '../holiday-preferences.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {NotificationService} from '../../core/services/notification.service';
import {Router} from '@angular/router';

@Component({
    selector: 'app-holiday-preferences-edit',
    templateUrl: './holiday-preferences-edit.component.html',
    styleUrls: ['./holiday-preferences-edit.component.css']
})
export class HolidayPreferencesEditComponent implements OnInit {
    preferences: IPreferences;
    preferenceForm: FormGroup;

    constructor(private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }

    ngOnInit() {
        this.getPreference();
        this.createForm();
    }

    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                this.preferences = preferences;
                this.preferenceForm.setValue(preferences);
            });
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl('', Validators.required)
        });
    }

    updatePreference() {
        this.holidayPreferencesService
            .updateHolidayPreference(this.preferenceForm.value)
            .subscribe(
                data => {
                    this.router.navigate(['/holiday-preferences']);
                },
                error => {
                    console.log('Error: ', error);
                    this.notificationService.openSnackBar(error.error.message);
                }
            );
    }


}
