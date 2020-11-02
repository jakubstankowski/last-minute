import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap, Route, Router} from "@angular/router";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HolidayPreferencesService} from "../holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";

@Component({
    selector: 'app-holiday-preferences',
    templateUrl: './holiday-preferences.component.html',
    styleUrls: ['./holiday-preferences.component.css']
})
export class HolidayPreferencesComponent implements OnInit {
    preferenceForm: FormGroup;
    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];
    isCreateMode = false;
    mode: string;

    constructor(private route: ActivatedRoute, private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }

    ngOnInit() {
        this.mode = this.route.snapshot.paramMap.get('mode');
        this.isCreateMode = this.mode === 'create';
        this.createForm();

        if (!this.isCreateMode) {
            this.getPreference();
        }
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    getPreference(): any {
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

    updatePreference(): any {
        const websitesList: Object[] = []

        for (let i = 0; i < this.selectedWebsites.length; i++) {
            websitesList.push({
                website: this.selectedWebsites[i]
            });
        }

        this.preferenceForm.patchValue({
            websites: websitesList,
        });

        if (this.isCreateMode) {
            this.holidayPreferencesService
                .createHolidayPreference(this.preferenceForm.value)
                .subscribe(
                    data => {
                        this.router.navigate(['/holiday-offers']);
                    },
                    error => {
                        this.notificationService.openSnackBar(error.error.message);
                        throw new Error(error);
                    }
                );
        } else {
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
    }

    updateWebsites(website: string): any {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }
        this.selectedWebsites.push(website);
    }

}


