import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { LocalStorageService, LoginService } from '../../services';
import { User } from '../../models';

@Component({
    selector: 'signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit, OnDestroy {
    email = '';
    password = '';
    signUpSubscription: Subscription;

    constructor(private router: Router, private localStorageService: LocalStorageService, private loginService: LoginService) { }

    ngOnInit(): void {
        this.localStorageService.email = null;
    }

    ngOnDestroy(): void {
        if (this.signUpSubscription) { this.signUpSubscription.unsubscribe(); }
    }

    signupButtonClicked() {
        if (this.email.length > 0 && this.password.length > 0) {
            this.signUpSubscription = this.loginService.signUp(this.email, this.password)
                .subscribe((user: User) => {
                    this.localStorageService.email = user.email;
                    this.router.navigate(['home']);
                });
        }
    }
}
