import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";
import {HTTP_PROVIDERS} from "angular2/http";
import {ArtistsService} from "./ArtistsService";


@Component({
    selector: "performers",
    templateUrl: "/app/components/performers/performersListing.html"

})

export class Performers {
    constructor(private service: ArtistsService) {
        this.artists = this.service.getArtists();
    }
    artists = null;
    someValue = 255;
}

bootstrap(Performers, [
    HTTP_PROVIDERS, ArtistsService
]);