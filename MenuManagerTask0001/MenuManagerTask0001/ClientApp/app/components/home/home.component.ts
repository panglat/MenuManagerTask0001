import { Component, OnInit } from '@angular/core';
import { Terms } from '../../models';
import { LanguageHolderService } from '../../services/holders/language.holder.service';
import { LocalStorageService } from '../../services/local.storage.service';
import { Router } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    // welcomeMessage = '';
    email = ''

    constructor(private languageHolderService: LanguageHolderService, private localStorageService: LocalStorageService, private router: Router) { }

    ngOnInit(): void {
        if (this.localStorageService.email) {
            this.email = this.localStorageService.email;
        }
    }

    get welcomeMessage(): string | null {
        if (this.languageHolderService.terms) {
            return this.languageHolderService.terms.welcome;
        }
        return null;
    }

    backToSignUpPage() {
        this.router.navigate(['signup']);
    }
}
