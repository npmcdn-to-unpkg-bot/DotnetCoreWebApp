import {Injectable} from "angular2/core";
import {Http, Response} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import {Observable} from "rxjs/Observable";
import {IArtist} from "./artist";
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ArtistsService {

    constructor(private _http: Http) {
    }

    getArtists(): Promise<any> {
        return this._http.get('/api/artists')
            .map((response) => {
                return response.json();
            }).toPromise();
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');

    }
}