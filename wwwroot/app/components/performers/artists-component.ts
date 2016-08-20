import {bootstrap} from "angular2/platform/browser";
import {Component} from "angular2/core";
import {ArtistsService} from "./ArtistsService";
import {PaginatePipe, PaginationControlsCmp, PaginationService} from 'ng2-pagination';
import {IArtist} from "../../shared/interfaces/IArtist"


@Component({
    selector: "performers",
    templateUrl: "/app/components/performers/performersListing.html",
    providers:[ArtistsService]

})

export class Performers {
    constructor(private _artistsService: ArtistsService) {
    }
    artists: IArtist[] = null;
    someValue: number = 255;
}

bootstrap(Performers, []);