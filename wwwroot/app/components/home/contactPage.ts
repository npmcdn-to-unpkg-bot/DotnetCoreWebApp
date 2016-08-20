import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";

@Component({
    selector: "contact-page",
    templateUrl : "/app/components/home/contactPage.html"
})
export class ContactPage {
    someValue: number = 300;
}

bootstrap(ContactPage, []);