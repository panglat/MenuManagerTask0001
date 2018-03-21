import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class LocalStorageService {
    static EMAIL: string = 'EMAIL';

    constructor(@Inject(PLATFORM_ID) private platformId: Object) { }

    public get email(): string | null {
        // The local storage is only available in the client side
        if (isPlatformBrowser(this.platformId)) {
            // Client Side
            return localStorage.getItem(LocalStorageService.EMAIL);
        }
        // Server side, just return null
        return null;
    }

    public set email(value: string | null) {
        // The local storage is only available in the client side
        if (isPlatformBrowser(this.platformId)) {
            // Client Side
            if (value) {
                localStorage.setItem(LocalStorageService.EMAIL, value);
            } else {
                localStorage.removeItem(LocalStorageService.EMAIL)
            }
        }
    }
}
