import {Injectable, OnInit} from "angular2/core";
import {Http} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import {HTTP_PROVIDERS} from "angular2/http";
import {PerformersListing} from "./PerformersListing"
import {Observable} from "rxjs/Observable"
import {IArtist} from "../../shared/interfaces/IArtist"
import {IPaginationData} from "../../shared/interfaces/IPaginationData"

@Injectable()
export class ArtistsService implements onInit {
    artists: IArtist[];
    constructor(private http: Http) {
    }
    getArtists(): IArtist[] {
        let result = null;
        return this.http.get('/api/artists').map(responseData => {
            responseData.json();
        }).map((artists: any) => {
            let artistsCollection: IArtist[];
            let paginationData = null();
            
            if (artists) {
                artists.forEach((artist) => {
                    //artistsCollection.push(new IArtist(1, "my artist"));
                });
                result = new PerformersListing(artistsCollection, paginationData)                
            }
            return result;
        })
    }

    ngOnInit(): void {
        this.artists = this.getArtists();
    }


}