import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IPreferences} from '../shared/models/preferences';
import {Observable} from 'rxjs';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class HolidayPreferencesService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getHolidayPreference(): Observable<IPreferences> {
        return this.http.get<IPreferences>(this.baseUrl + 'preferences');
    }

    updateHolidayPreference(form: any): Observable<IPreferences> {
        return this.http.put<IPreferences>(this.baseUrl + 'preferences', form);
    }


}
