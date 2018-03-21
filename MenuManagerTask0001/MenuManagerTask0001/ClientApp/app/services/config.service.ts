import { Injectable, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import 'rxjs/add/operator/map';
import { LanguageTerms } from '../models/';
import { LanguageService } from './language.service';

// Code from: https://aclottan.wordpress.com/tag/angular-cli/

@Injectable()
export class ConfigService implements OnDestroy {
    // Variable that holds all the fields in appConfig.json
    languageTerms: LanguageTerms;

    getAndStoreLanguageTermsSubscription: Subscription;

    constructor(private http: Http, private languageService: LanguageService) { }

    ngOnDestroy(): void {
        if (this.getAndStoreLanguageTermsSubscription) {
            this.getAndStoreLanguageTermsSubscription.unsubscribe();
        }
    }

    /**
     * Function used to get the configuration fields
     * before loading the app
     * @returns {Promise<Configuration>}
     */
    public loadLanguageTerms(): Promise<LanguageTerms> {
        return new Promise((resolve) => {
            this.getAndStoreLanguageTermsSubscription = this.languageService.getAndStoreLanguageTerms('en')
                .subscribe((languageTerms: LanguageTerms) => {
                    resolve();
                });
        });
    }
}
