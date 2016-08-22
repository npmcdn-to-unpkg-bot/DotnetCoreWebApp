import {Injectable} from "angular2/core";
import {Http, Response} from "angular2/http";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/operator/do";
import {HTTP_PROVIDERS} from "angular2/http";
import {Observable} from "rxjs/Observable"
import {IArtist} from "../../shared/interfaces/IArtist"
import {IPaginationData} from "../../shared/interfaces/IPaginationData"

@Injectable()
export  class ArtistsService {    
    private paginationData: IPaginationData;
    
    constructor(private http: Http) {
    }

    getArtists(): Observable<any>  {        
        return this.http.get('/api/artists')
        .map( (response) => {
           // this.paginationData =  <IPaginationData>response.json().paginationData;
      return response.json();
    })

      //  .map((response : Response) =>  <IArtist[]> response.json().performers) 
       // .do(data => console.log('All: ' + JSON.stringify(data)))
        .catch(this.handleError); 
    }

    getPaginationData(): IPaginationData {
        return this.paginationData;
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
        
    }
}