import { Injectable } from "@angular/core";

@Injectable()
export abstract class BaseService {
    SERVER_URL = 'http://localhost:5000/';
}