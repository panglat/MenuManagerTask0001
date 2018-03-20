import { Injectable, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { LanguageTerms } from '../models/LanguageTerms';
import 'rxjs/add/operator/map';

// Code from: https://aclottan.wordpress.com/tag/angular-cli/

@Injectable()
export class ConfigService implements OnDestroy {
    // Variable that holds all the fields in appConfig.json
    private languageTerms: LanguageTerms;

    private getConfigurationSubscription: Subscription;

    constructor(private http: Http) { }

    ngOnDestroy(): void {
        if (this.getConfigurationSubscription) {
            this.getConfigurationSubscription.unsubscribe();
        }
    }

    /**
     * Function used to get the configuration fields
     * before loading the app
     * @returns {Promise<Configuration>}
     */
    public loadLanguageTerms(): Promise<LanguageTerms> {
        return new Promise((resolve) => {
            this.getConfigurationSubscription = this.http.get('http://localhost:5000/api/languages/en/terms')
                .map(response => <LanguageTerms> response.json())
                .subscribe((languageTerms: LanguageTerms) => {
                    this.languageTerms = languageTerms;
                    console.log(languageTerms);
                    resolve();
                });
        });
    }
}
