import { Language } from "./language";
import { Terms } from "./terms";

export class LanguageTerms {
    constructor(
        public language: Language,
        public terms: Terms
    ) { }
}
