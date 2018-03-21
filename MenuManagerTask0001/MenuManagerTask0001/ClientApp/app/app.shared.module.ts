import { NgModule, APP_INITIALIZER } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SignUpComponent } from './components/signup/signup.component';
import { ConfigService } from './services/config.service';
import { LanguageService, LocalStorageService, LoginService } from './services/';
import { LanguageHolderService } from './services/holders/language.holder.service';

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
            { path: 'home', component: HomeComponent },
            { path: 'signup', component: SignUpComponent },
            { path: '**', redirectTo: 'home' }
        ])
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
        LocalStorageService,
        LoginService
    ]
})
export class AppModuleShared {
}
