import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from '@core/services';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authService: AuthService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentAuth = this.authService.currentAuth;
        //check if we have the token and id
        if (currentAuth) {
            // // check if route is restricted by role
            // if (route.data.roles && route.data.roles.indexOf(currentAuth.) === -1) {
            //     // role not authorised so redirect to home page
            //     this.router.navigate(['/']);
            //     return false;
            // }

            // authorised so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}