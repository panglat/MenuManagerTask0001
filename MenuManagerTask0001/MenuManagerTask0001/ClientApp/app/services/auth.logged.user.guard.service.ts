import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class AuthLoggedUserGuardService implements CanActivate {

    constructor(private router: Router, private authService: AuthService, @Inject(PLATFORM_ID) private platformId: Object) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        // Due to it is necessary to check the LocalStorage, the Authentication validation can only be done in the client side
        if (isPlatformBrowser(this.platformId)) {
            // Client Side
            if (this.authService.isUserLogged) {
                // if the user is signed up, allow the route
                return true;
            } else {
                // If the user is not signed up, Navigate to the login page
                this.router.navigate(['/signup']);
                return false;
            }
        } else {
            // Server side, just return OK
            return true;
        }
    }
}
