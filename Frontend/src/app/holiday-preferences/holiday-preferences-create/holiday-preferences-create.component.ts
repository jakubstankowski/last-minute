import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {HolidayPreferencesService} from "../holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";

@Component({
    selector: 'app-holiday-preferences-create',
    templateUrl: './holiday-preferences-create.component.html',
    styleUrls: ['./holiday-preferences-create.component.css']
})
export class HolidayPreferencesCreateComponent implements OnInit {
    preferenceForm: FormGroup;

    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];


    constructor(private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }

    ngOnInit() {
        this.createForm();
        this.setDefaultPreferencesValues();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    private setDefaultPreferencesValues() {
        this.preferenceForm.patchValue({
            minPrice: 0,
            maxPrice: 2500
        });
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
    }

    updateWebsites(website: string) {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }

        this.selectedWebsites.push(website);
    }

}
