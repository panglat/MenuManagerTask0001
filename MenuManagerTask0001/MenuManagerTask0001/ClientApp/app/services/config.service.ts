import { Injectable, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { LanguageTerms } from '../models/';
import 'rxjs/add/operator/map';
import { LanguageService } from './language.service';
import { LanguageHolderService } from './holders/language.holder.service';

// Code from: https://aclottan.wordpress.com/tag/angular-cli/

@Injectable()
export class ConfigService implements OnDestroy {
    // Variable that holds all the fields in appConfig.json
    private languageTerms: LanguageTerms;

    private getLanguageTermsSubscription: Subscription;

    constructor(private http: Http, private languageService: LanguageService, private languageHolderService: LanguageHolderService) { }

    ngOnDestroy(): void {
        if (this.getLanguageTermsSubscription) {
            this.getLanguageTermsSubscription.unsubscribe();
        }
    }

    /**
     * Function used to get the configuration fields
     * before loading the app
     * @returns {Promise<Configuration>}
     */
    public loadLanguageTerms(): Promise<LanguageTerms> {
        return new Promise((resolve) => {
            this.getLanguageTermsSubscription = this.languageService.getLanguageTerms('en')
                .subscribe((languageTerms: LanguageTerms) => {
                    this.languageHolderService.languageTerms = languageTerms;
                    console.log(languageTerms);
                    resolve();
                });
        });
    }
}
