import {bootstrap} from 'angular2/platform/browser';
import {Component, OnInit} from "angular2/core";
import {HTTP_PROVIDERS} from "angular2/http";
import {ArtistsService} from "./artists.service";
import {IArtist} from "./artist";
import {IPaginationData} from "../../shared/interfaces/IPaginationData"


@Component({
    selector: "artists",
    templateUrl: "/app/components/artists/artists-listing.component.html",
    providers: [ArtistsService, HTTP_PROVIDERS]
})
export class ArtistsListingComponent implements OnInit {

    pageNumber: number = 1;
    pageSize: number = 20;
    searchTerms: string = '';
    sortColumn: string = 'Name';
    sortDirection: string = 'ASC';

    artists: IArtist[];
    paginationData: IPaginationData;
    pagesArray: number[];

    errorMessage: string;
    isLoading: boolean = true;

  

    constructor(private artistsService: ArtistsService) {

    }

    ngOnInit(): void {
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    }

    pageData(pageNumber: number, pageSize: number, searchTerms: string,
        sortColumn: string, sortDirection: string): void {
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.searchTerms = (searchTerms == null ? '' : searchTerms);
        this.sortColumn = sortColumn;
        this.sortDirection = sortDirection;

        this.artistsService.getArtists(
            this.pageNumber,
            this.pageSize,
            this.searchTerms,
            this.sortColumn,
            this.sortDirection)
            .then(response => {
                this.paginationData = <IPaginationData>response.paginationData;
                this.initPagesArray();
                this.artists = <IArtist[]>response.performers;
            }
            );
    }

    initPagesArray(): void {
        if (!this.paginationData) return;
        this.pagesArray = [];
        for (var i = 1; i <= this.paginationData.totalNumberOfPages; i++) {
            this.pagesArray.push(i);
        }
    }

    clearSearch(): void {
        this.searchTerms = '';
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    }
}
bootstrap(ArtistsListingComponent, []);

