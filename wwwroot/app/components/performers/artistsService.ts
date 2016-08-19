import {Injectable} from "angular2/core";
import {Http} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import {PerformersListing} from "./PerformersListing"
import {Observable} from "rxjs/Observable"
import {Artist} from "../../shared/models/Artist"
import {PaginationData} from "../../shared/models/PaginationData"

@Injectable()
export class ArtistsService {
    artists: Array<Artist>;
    constructor(private http: Http) {
    }
    getArtists() {
        let result = null;
        return this.http.get('/api/artists').map(responseData => {
            responseData.json();
        }).map((artists: any) => {
            let artistsCollection: Array<Artist> = [];
            let paginationData = new PaginationData();
            
            if (artists) {
                artists.forEach((artist) => {
                    artistsCollection.push(new Artist(1, "my artist"));
                });
                result = new PerformersListing(artistsCollection, paginationData)                
            }
            return result;
        })
    }


}