import {bootstrap} from 'angular2/platform/browser';
import {Component, OnInit} from "angular2/core";
import {ArtistsService} from "./artists.service";
import {HTTP_PROVIDERS} from "angular2/http";
import {IArtist} from "./artist";

import {IPaginationData} from "../../shared/interfaces/IPaginationData"


@Component({
    selector: "artists",
    templateUrl: "/app/components/artists/artists-listing.component.html",
    providers: [HTTP_PROVIDERS, ArtistsService]
})
export class ArtistsListingComponent implements OnInit {

    artists: IArtist[];
    paginationData: IPaginationData;

    errorMessage: string;
    isLoading: boolean = true;

    constructor(private artistsService: ArtistsService) {

    }

    ngOnInit(): void {
        this.artistsService.getArtists()
            .then(response => {
                this.paginationData = <IPaginationData>response.paginationData;
                this.artists = <IArtist[]>response.performers;
            }
            );
    }
}
bootstrap(ArtistsListingComponent, []);

