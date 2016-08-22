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
require("rxjs/add/operator/do");
//import {ArtistsListingComponent} from "./artists-listing.component"
var Observable_1 = require("rxjs/Observable");
//import {IPaginationData} from "../../shared/interfaces/IPaginationData"
var ArtistsService = (function () {
    function ArtistsService(http) {
        this.http = http;
    }
    ArtistsService.prototype.getArtists = function () {
        return this.http.get('/api/artists')
            .map(function (response) { return response.json().performers; })
            .catch(this.handleError);
    };
    ArtistsService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    ArtistsService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], ArtistsService);
    return ArtistsService;
}());
exports.ArtistsService = ArtistsService;
