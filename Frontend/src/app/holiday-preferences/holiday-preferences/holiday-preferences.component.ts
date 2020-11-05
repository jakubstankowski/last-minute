import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, ParamMap, Route, Router} from '@angular/router';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {HolidayPreferencesService} from '../holiday-preferences.service';
import {NotificationService} from '../../core/services/notification.service';
import {MatDialog} from "@angular/material/dialog";
import {HolidayPreferencesDialogComponent} from "../holiday-preferences-dialog/holiday-preferences-dialog.component";

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
    title = 'app';
    animal: string;
    name: string;


    constructor(private route: ActivatedRoute, private router: Router,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService, public dialog: MatDialog) {
    }

    ngOnInit() {
       /* const dialogRef = this.dialog.open(HolidayPreferencesDialogComponent, {
            data: {name: this.name, animal: this.animal}
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
            if ((result != null) && (result.animal != null)) {
                this.animal = result.animal;
            }
        });
*/

        this.mode = this.route.snapshot.paramMap.get('mode');
        this.isCreateMode = this.mode === 'create';
        this.createForm();

        if (this.isCreateMode) {
            this.preferenceForm.patchValue({
                minPrice: 0,
                maxPrice: 2500
            });
            return this.selectedWebsites.push('itaka.pl');
        }

        this.getPreference();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    private getPreference(): any {
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
        const websitesList: Object[] = [];

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


