import { Injectable } from "@angular/core";

@Injectable()
export class LocalStorageService {
    static EMAIL: string = 'EMAIL';

    public get email(): string | null {
        return localStorage.getItem(LocalStorageService.EMAIL);
    }

    public set email(value: string | null) {
        if (value) {
            localStorage.setItem(LocalStorageService.EMAIL, value);
        } else {
            localStorage.removeItem(LocalStorageService.EMAIL);
        }
    }
}