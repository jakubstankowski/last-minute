import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {FormControl, Validators, FormGroup} from '@angular/forms';
import {Title} from '@angular/platform-browser';
import {EMPTY, of} from 'rxjs';
import 'rxjs/add/operator/delay';

import {AuthenticationService} from '../../core/services/auth.service';
import {NotificationService} from '../../core/services/notification.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginForm: FormGroup;
    loading: boolean;

    constructor(public router: Router,
                private titleService: Title,
                private notificationService: NotificationService,
                private authenticationService: AuthenticationService) {
    }

    ngOnInit() {
        this.titleService.setTitle('Last Minute - Login');
        this.createForm();
    }

    private createForm() {
        this.loginForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required, Validators.minLength(4)])
        });
    }

    login(): void {
        this.loading = true;
        this.authenticationService
            .login(this.loginForm.value)
            .subscribe(
                data => {
                    this.loading = true;
                    this.router.navigate(['/']);
                },
                error => {
                    this.notificationService.openSnackBar('Wrong login, or password, try again!');
                    this.loading = false;
                }
            );
    }
}
