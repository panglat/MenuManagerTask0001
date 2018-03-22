import { Component, OnInit, OnDestroy } from '@angular/core';
import { LanguageService } from '../../services';
import { Subscription } from 'rxjs/Subscription';
import { Language } from '../../models';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit, OnDestroy {
    dropdownTitle = 'loading';
    languageList: Language[] = new Array<Language>();
    selectedLanguage: Language | undefined;

    getLanguageListSubscription: Subscription;
    getAndStoreLanguageTermsSubscription: Subscription;

    constructor(private languageService: LanguageService, private translate: TranslateService) { }

    ngOnInit(): void {
        this.getLanguageListSubscription = this.languageService.getLanguageList()
            .subscribe((languages: Language[]) => {
                this.languageList = languages;
                this.selectedLanguage = languages.find(language => language.languageCode === 'en');
                if (this.selectedLanguage) {
                    this.dropdownTitle = this.selectedLanguage.nativeLanguage;
                }
            });
    }

    ngOnDestroy(): void {
        if (this.getLanguageListSubscription) { this.getLanguageListSubscription.unsubscribe(); }
        if (this.getAndStoreLanguageTermsSubscription) { this.getAndStoreLanguageTermsSubscription.unsubscribe(); }
    }

    changeLanguage(language: Language) {
        this.selectedLanguage = language;
        this.dropdownTitle = language.name;
        this.getAndStoreLanguageTermsSubscription = this.languageService.getAndStoreLanguageTerms(language.languageCode).subscribe();
        this.translate.use(language.languageCode);
    }

}
