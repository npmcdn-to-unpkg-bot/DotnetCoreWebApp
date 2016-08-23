"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var browser_1 = require('angular2/platform/browser');
var core_1 = require("angular2/core");
var http_1 = require("angular2/http");
var artists_service_1 = require("./artists.service");
var ArtistsListingComponent = (function () {
    function ArtistsListingComponent(artistsService) {
        this.artistsService = artistsService;
        this.pageNumber = 1;
        this.pageSize = 20;
        this.searchTerms = '';
        this.sortColumn = 'Name';
        this.sortDirection = 'ASC';
        this.isLoading = true;
    }
    ArtistsListingComponent.prototype.ngOnInit = function () {
        this.pageData(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection);
    };
    ArtistsListingComponent.prototype.pageData = function (pageNumber, pageSize, searchTerms, sortColumn, sortDirection) {
        var _this = this;
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
        this.searchTerms = (searchTerms == null ? '' : searchTerms);
        this.sortColumn = sortColumn;
        this.sortDirection = sortDirection;
        this.artistsService.getArtists(this.pageNumber, this.pageSize, this.searchTerms, this.sortColumn, this.sortDirection)
            .then(function (response) {
            _this.paginationData = response.paginationData;
            _this.initPagesArray();
            _this.artists = response.performers;
        });
    };
    ArtistsListingComponent.prototype.initPagesArray = function () {
        if (!this.paginationData)
            return;
        this.pagesArray = [];
        for (var i = 1; i <= this.paginationData.totalNumberOfPages; i++) {
            this.pagesArray.push(i);
        }
    };
    ArtistsListingComponent = __decorate([
        core_1.Component({
            selector: "artists",
            templateUrl: "/app/components/artists/artists-listing.component.html",
            providers: [artists_service_1.ArtistsService, http_1.HTTP_PROVIDERS]
        }), 
        __metadata('design:paramtypes', [artists_service_1.ArtistsService])
    ], ArtistsListingComponent);
    return ArtistsListingComponent;
}());
exports.ArtistsListingComponent = ArtistsListingComponent;
browser_1.bootstrap(ArtistsListingComponent, []);
