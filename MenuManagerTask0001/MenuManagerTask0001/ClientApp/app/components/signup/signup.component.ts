import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { LocalStorageService, AuthService } from '../../services';
import { User } from '../../models';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit, OnDestroy {
    email = '';
    password = '';
    error = '';
    signUpSubscription: Subscription;

    constructor(private router: Router, private authService: AuthService, private localStorageService: LocalStorageService, private translate: TranslateService) { }

    ngOnInit(): void {
        this.localStorageService.email = null;
    }

    ngOnDestroy(): void {
        if (this.signUpSubscription) { this.signUpSubscription.unsubscribe(); }
    }

    signupButtonClicked() {
        if (this.email.length > 0 && this.password.length > 0) {
            this.signUpSubscription = this.authService.signUp(this.email, this.password)
                .subscribe((user: User) => {
                    this.localStorageService.email = user.email;
                    this.router.navigate(['home']);
                }, error => {
                    console.log(error);
                    if (error && error.status === 401) {
                        this.error = "E_USER_EXISTS";
                    } else {
                        this.error = "E_CON_ERROR";
                    }
                });
        }
    }
}
