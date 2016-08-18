import {Injectable} from "angular2/core";
import {Http} from "angular2/http";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ArtistsService {
    constructor(private http: Http) {
    }
    getArtists() {
        return this.http.get('/api/artists').map(res => res.json());
    }


}