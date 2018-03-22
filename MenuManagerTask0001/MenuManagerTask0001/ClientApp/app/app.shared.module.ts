import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule, Http } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SignUpComponent } from './components/signup/signup.component';
import { ConfigService } from './services/config.service';
import { LanguageService, AuthService, AuthLoggedUserGuardService, LocalStorageService } from './services/';
import { LanguageHolderService } from './services/holders/language.holder.service';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function ConfigLoader(configService: ConfigService) {
    // Note: this factory need to return a function (that return a promise)
    return () => configService.loadLanguageTerms();
}

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        SignUpComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent, canActivate: [AuthLoggedUserGuardService]},
            { path: 'signup', component: SignUpComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        TranslateModule.forRoot()
    ],
    providers: [
        ConfigService, {
            provide: APP_INITIALIZER,
            useFactory: ConfigLoader,
            deps: [ConfigService],
            multi: true
        },
        LanguageService,
        LanguageHolderService,
        AuthService,
        AuthLoggedUserGuardService,
        LocalStorageService
    ],
    exports: [
        TranslateModule
    ]
})
export class AppModuleShared {
}
