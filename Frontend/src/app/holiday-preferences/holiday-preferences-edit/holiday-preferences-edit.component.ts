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
    loading: boolean = true;

    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];

    constructor(private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }


    ngOnInit() {
        this.getPreference();
        this.createForm();
        // this.toppings.setValue([{topping: 'test'}]);
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl('', Validators.required)
        });
    }

    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                this.preferenceForm.setValue(preferences);
                for (let i = 0; i < preferences.websites.length; i++) {
                    this.selectedWebsites.push(preferences.websites[i]['website']);
                }
            });
    }


    updatePreference() {
        console.log('form value : ', this.preferenceForm.value);
        /* this.holidayPreferencesService
             .updateHolidayPreference(this.preferenceForm.value)
             .subscribe(
                 data => {
                     this.router.navigate(['/holiday-preferences']);
                 },
                 error => {
                     console.log('Error: ', error);
                     this.notificationService.openSnackBar(error.error.message);
                 }
             );*/
    }

    updateWebsites(website: string) {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }
        this.selectedWebsites.push(website);
    }
}
