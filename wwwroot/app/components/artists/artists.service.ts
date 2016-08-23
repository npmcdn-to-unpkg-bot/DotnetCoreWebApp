import {Injectable} from "angular2/core";
import {Http, Response} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import "rxjs/add/observable/throw";
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
            })
            .toPromise()
            .then(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
       return res;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}