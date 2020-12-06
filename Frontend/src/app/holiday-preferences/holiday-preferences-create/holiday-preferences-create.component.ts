import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
    selector: 'app-holiday-preferences-create',
    templateUrl: './holiday-preferences-create.component.html',
    styleUrls: ['./holiday-preferences-create.component.css']
})
export class HolidayPreferencesCreateComponent implements OnInit {
    preferenceForm: FormGroup;
    websitesList: string[] = ['itaka.pl', 'tui.pl', 'r.pl', 'wakacje.pl'];
    selectedWebsites: string[] = [];

    constructor() {
    }

    ngOnInit() {
        this.createForm();
        this.setDefaultFormValues();
    }

    private createForm() {
        this.preferenceForm = new FormGroup({
            minPrice: new FormControl('', Validators.required),
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

    updateWebsites(website: string): any {
        if (this.selectedWebsites.includes(website)) {
            return this.selectedWebsites.splice(this.selectedWebsites.indexOf(website), 1);
        }
        this.selectedWebsites.push(website);
    }

}
