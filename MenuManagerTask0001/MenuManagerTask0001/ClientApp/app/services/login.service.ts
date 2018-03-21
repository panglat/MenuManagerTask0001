import { Injectable } from "@angular/core";
import { BaseService } from "./base.service";
import { Observable } from "rxjs/Observable";
import { Http } from "@angular/http";
import { Language, LanguageTerms, User } from "../models";

@Injectable()
export class LoginService extends BaseService {

    constructor(private http: Http) {
        super();
    }

    public signUp(email: string, password: string): Observable<User> {
        const user: User = new User(email, password);
        return this.http.post(`${this.SERVER_URL}/api/users/`, user)
            .map(response => <User>response.json())
    }
}