import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(translate: TranslateService) {
        // this language will be used as a fallback when a translation isn't found in the current language
        translate.setDefaultLang('en');

        // the lang to use, if the lang isn't available, it will use the current loader to get them
        translate.use('en');

        translate.setTranslation('en', {
            EMAIL: 'Email',
            PASSWORD: 'Password',
            SIGNUP: 'Sign up', 
            E_USER_EXISTS: 'The user already exists',
            E_CON_ERROR: 'There was a problem connecting to the server'
        });

        translate.setTranslation('pt', {
            EMAIL: 'O email',
            PASSWORD: 'Senha',
            SIGNUP: 'Inscrever-se',
            E_USER_EXISTS: 'O usu&aacute;rio j&aacute; existe',
            E_CON_ERROR: 'Houve um problema ao se conectar ao servidor'
        });
    }
}
