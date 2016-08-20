import {Injectable} from "angular2/core";
import {Http, Response} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import {HTTP_PROVIDERS} from "angular2/http";
import {ArtistsListingComponent} from "./artists-listing.component"
import {Observable} from "rxjs/Observable"
import {IArtist} from "../../shared/interfaces/IArtist"
import {IPaginationData} from "../../shared/interfaces/IPaginationData"

@Injectable()
export  class ArtistsService {
    
    
    constructor(private http: Http) {
    }
    getArtists(): Observable<IArtist[]>  {
        
        return this.http.get('/api/artists').map((response : Response) => <IArtist[]> response.json().data())//response.json.data? 
        .do(data => console.log('All: ' + JSON.stringify(data)))
        .catch(this.handleError); 
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
        
    }
}