import {Component} from '@angular/core';
import {AuthenticationService} from './core/services/auth.service';

@Component({
    selector: 'app-root',
    template: `
        <router-outlet></router-outlet>`
})
export class AppComponent {

    constructor(private authService: AuthenticationService) {
    }

    // tslint:disable-next-line:use-life-cycle-interface
    ngOnInit(): void {
        this.loadCurrentUser();
    }

    loadCurrentUser() {
        const token = localStorage.getItem('token');
        this.authService.loadCurrentUser(token).subscribe(() => {
            console.log('loaded user');
        }, error => {
            console.log(error);
        });
    }
}
