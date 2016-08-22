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
var artists_service_1 = require("./artists.service");
var http_1 = require("angular2/http");
var ArtistsListingComponent = (function () {
    function ArtistsListingComponent(artistsService) {
        this.artistsService = artistsService;
    }
    ArtistsListingComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.artistsService.getArtists()
            .subscribe(function (artists) { return _this.artists = artists; }, function (error) { return _this.errorMessage = error; });
    };
    ArtistsListingComponent = __decorate([
        core_1.Component({
            selector: "artists",
            templateUrl: "/app/components/artists/artists-listing.component.html",
            providers: [http_1.HTTP_PROVIDERS, artists_service_1.ArtistsService]
        }), 
        __metadata('design:paramtypes', [artists_service_1.ArtistsService])
    ], ArtistsListingComponent);
    return ArtistsListingComponent;
}());
exports.ArtistsListingComponent = ArtistsListingComponent;
browser_1.bootstrap(ArtistsListingComponent, []);
