import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";

@Component({
    selector: "contact-page",
    templateUrl : "/app/components/home/contact-page.component.html"
})
export class ContactPage {
    someValue: number = 300;
}

bootstrap(ContactPage, []);