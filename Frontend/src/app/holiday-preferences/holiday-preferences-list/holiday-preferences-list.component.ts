import {Component, OnInit} from '@angular/core';

@Component({
    selector: 'app-holiday-preferences-list',
    templateUrl: './holiday-preferences-list.component.html',
    styleUrls: ['./holiday-preferences-list.component.css']
})
export class HolidayPreferencesListComponent implements OnInit {

    constructor() {
    }

    ngOnInit() {
        alert('preferences!');
    }

}
