import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Observable } from "rxjs/Observable";
import { Http } from "@angular/http";
import { Language, LanguageTerms } from "../models";
import { LanguageHolderService } from "./holders/language.holder.service";

@Injectable()
export class LanguageService extends BaseService {

    constructor(private http: Http, private languageHolderService: LanguageHolderService) {
        super();
    }

    public getLanguageList(): Observable<Language[]> {
        return this.http.get(`${this.SERVER_URL}/api/languages/`)
            .map(response => <Language[]>response.json())
    }

    public getLanguageTerms(languageCode: string): Observable<LanguageTerms> {
        return this.http.get(`${this.SERVER_URL}api/languages/${languageCode}/terms`)
            .map(response => <LanguageTerms>response.json())
    }

    public getAndStoreLanguageTerms(languageCode: string): Observable<LanguageTerms> {
        return this.getLanguageTerms(languageCode)
            .map((languageTerms: LanguageTerms) => {
                this.languageHolderService.languageTerms = languageTerms;
                return languageTerms;
            })
    }
}