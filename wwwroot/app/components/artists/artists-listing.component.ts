import {bootstrap} from 'angular2/platform/browser';
import {Component, OnInit} from "angular2/core";
import {ArtistsService} from "./artists.service";
import {HTTP_PROVIDERS} from "angular2/http";


@Component({
    selector: "artists",
    templateUrl: "/app/components/artists/artists-listing.component.html",
    providers: [HTTP_PROVIDERS,ArtistsService]
})
export  class ArtistsListingComponent implements OnInit {
    
    artists: any;
    errorMessage: string;

    constructor(private artistsService: ArtistsService) {

    }

    ngOnInit(): void {
        this.artists = this.artistsService.getArtists()
        .subscribe(
            artists => this.artists = artists,
            error => this.errorMessage = <any>error);
    }
}
bootstrap(ArtistsListingComponent, []);

