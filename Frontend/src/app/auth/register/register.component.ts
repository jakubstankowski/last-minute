import {Component, OnInit} from '@angular/core';
import {Title} from '@angular/platform-browser';
import {NotificationService} from '../../core/services/notification.service';
import {AuthenticationService} from '../../core/services/auth.service';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading: boolean;

    constructor(public router: Router, private titleService: Title,
                private notificationService: NotificationService,
                private authenticationService: AuthenticationService) {
    }

    ngOnInit() {
        this.titleService.setTitle('Last Minute - Register');
        this.createForm();
    }

    private createForm() {
        this.registerForm = new FormGroup({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required, Validators.minLength(6)])
        });
    }

    register(): void {
        this.loading = true;
        this.authenticationService
            .register(this.registerForm.value)
            .subscribe(
                data => {
                    this.loading = true;
                    this.router.navigate(['/']);
                },
                error => {
                    console.log('Error: ', error);
                    this.notificationService.openSnackBar('Something went wrong, try again with different credentials');
                    this.loading = false;
                }
            );
    }

}
