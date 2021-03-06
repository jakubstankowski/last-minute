import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {HolidayPreferencesService} from "../holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";
import {IDialogData} from "../../shared/models/dialogData";

@Component({
    selector: 'app-holiday-preferences-dialog',
    templateUrl: './holiday-preferences-dialog.component.html',
    styleUrls: ['./holiday-preferences-dialog.component.css']
})
export class HolidayPreferencesDialogComponent implements OnInit {
    preferenceForm: FormGroup;
    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];

    constructor(
        public dialogRef: MatDialogRef<HolidayPreferencesDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: IDialogData, private route: ActivatedRoute, private router: Router,
        private holidayPreferencesService: HolidayPreferencesService,
        private notificationService: NotificationService,) {
        dialogRef.disableClose = true;
    }

    ngOnInit() {
        this.createForm();
        this.getPreference();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            maxPrice: new FormControl('', Validators.required),
            websites: new FormControl([])
        });
    }

    private getPreference(): any {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(
                preferences => {
                    this.preferenceForm.patchValue({
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

    updateWebsites(website: string): any {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }
        this.selectedWebsites.push(website);
    }

    onCloseCancel(): void {
        this.dialogRef.close();
    }

    onCloseUpdate(): void {
        this.updatePreference();
        this.dialogRef.close(true);
    }


}
