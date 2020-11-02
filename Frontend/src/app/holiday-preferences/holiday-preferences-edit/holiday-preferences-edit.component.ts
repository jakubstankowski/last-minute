import {Component, OnInit} from '@angular/core';
import {HolidayPreferencesService} from '../holiday-preferences.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {NotificationService} from '../../core/services/notification.service';
import {Router} from '@angular/router';
import {IWebsites} from '../../shared/models/websites';

@Component({
    selector: 'app-holiday-preferences-edit',
    templateUrl: './holiday-preferences-edit.component.html',
    styleUrls: ['./holiday-preferences-edit.component.css']
})
export class HolidayPreferencesEditComponent implements OnInit {
    preferenceForm: FormGroup;

    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];

    constructor(private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }


    ngOnInit() {
        this.getPreference();
        this.createForm();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(
                preferences => {
                    this.preferenceForm.patchValue({
                        minPrice: preferences.minPrice,
                        maxPrice: preferences.maxPrice
                    });

                    for (let i = 0; i < preferences.websites.length; i++) {
                        this.selectedWebsites.push(preferences.websites[i]['website']);
                    }
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                }
            );
    }


    updatePreference() {
        const websitesList: Object[] = []

        for (let i = 0; i < this.selectedWebsites.length; i++) {
            websitesList.push({
                website: this.selectedWebsites[i]
            });
        }

        this.preferenceForm.patchValue({
            websites: websitesList,
        });


        this.holidayPreferencesService
            .updateHolidayPreference(this.preferenceForm.value)
            .subscribe(
                data => {
                    this.router.navigate(['/holiday-offers']);
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                }
            );
    }

    updateWebsites(website: string) {
        if (this.selectedWebsites.includes(website)) {
                return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }

        this.selectedWebsites.push(website);
    }
}
