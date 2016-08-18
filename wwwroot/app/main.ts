import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";


@Component({
    selector: "performers",
    templateUrl : "/app/components/performers/performersListing.html"
})
export class Performers {
    someValue = 255;
}

bootstrap(Performers, []);