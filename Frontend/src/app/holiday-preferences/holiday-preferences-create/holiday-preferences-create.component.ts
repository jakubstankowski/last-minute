import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HolidayPreferencesService} from "../holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";
import {Router} from "@angular/router";

@Component({
    selector: 'app-holiday-preferences-create',
    templateUrl: './holiday-preferences-create.component.html',
    styleUrls: ['./holiday-preferences-create.component.css']
})
export class HolidayPreferencesCreateComponent implements OnInit {
    preferenceForm: FormGroup;
    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];

    constructor(private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService, private router: Router) {
    }

    ngOnInit() {
        this.createForm();
        this.setDefaultFormValues();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    private setDefaultFormValues() {
        this.preferenceForm.patchValue({
            maxPrice: 2500
        });
        this.selectedWebsites.push('itaka.pl');
    }

    updateWebsites(website: string) {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }
        this.selectedWebsites.push(website);
    }

    createPreference() {
        const websitesList: Object[] = [];

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
                      this.notificationService.openSnackBar('Great choice, lets see holiday offers');
                      this.router.navigate(['/holiday-offers']);
                  },
                  error => {
                      this.notificationService.openSnackBar(error.error.message);
                      throw new Error(error);
                  }
              );

    }
}
