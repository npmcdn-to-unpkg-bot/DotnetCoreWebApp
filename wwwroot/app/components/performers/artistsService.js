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
var core_1 = require("angular2/core");
var http_1 = require("angular2/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var PerformersListing_1 = require("./PerformersListing");
var Artist_1 = require("../../shared/models/Artist");
var PaginationData_1 = require("../../shared/models/PaginationData");
var ArtistsService = (function () {
    function ArtistsService(http) {
        this.http = http;
    }
    ArtistsService.prototype.getArtists = function () {
        return this.http.get('/api/artists').map(function (responseData) {
            responseData.json();
        }).map(function (artists) {
            var artistsCollection = [];
            var paginationData = new PaginationData_1.PaginationData();
            if (artists) {
                artists.forEach(function (artist) {
                    artistsCollection.push(new Artist_1.Artist(1, "my artist"));
                });
                var result = new PerformersListing_1.PerformersListing(artistsCollection, paginationData);
                return result;
            }
        });
    };
    ArtistsService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ArtistsService);
    return ArtistsService;
}());
exports.ArtistsService = ArtistsService;
