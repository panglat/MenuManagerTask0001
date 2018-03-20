import { Injectable } from "@angular/core";
import { LanguageTerms } from "../../models";
import { Language } from "../../models/language";
import { Terms } from "../../models/terms";

@Injectable()
export class LanguageHolderService {
    _languageTerms: LanguageTerms;

    set languageTerms(value: LanguageTerms) {
        this._languageTerms = value;
    }

    get language(): Language | null {
        return this._languageTerms ? this._languageTerms.language : null;
    }

    get terms(): Terms | null {
        return this._languageTerms ? this._languageTerms.terms : null;
    }
}