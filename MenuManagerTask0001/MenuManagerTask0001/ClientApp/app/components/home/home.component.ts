import { Component, OnInit } from '@angular/core';
import { Terms } from '../../models';
import { LanguageHolderService } from '../../services/holders/language.holder.service';
import { LocalStorageService } from '../../services/local.storage.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    welcomeMessage = '';
    email = ''

    constructor(private languageHolderService: LanguageHolderService, private localStorageService: LocalStorageService) { }

    ngOnInit(): void {
        if (this.languageHolderService.terms) {
            this.welcomeMessage = this.languageHolderService.terms.welcome;
        }
        if (this.localStorageService.email) {
            this.email = this.localStorageService.email;
        }
    }
}
