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
var browser_1 = require("angular2/platform/browser");
var core_1 = require("angular2/core");
var http_1 = require("angular2/http");
var ArtistsService_1 = require("./ArtistsService");
var Performers = (function () {
    function Performers(service) {
        this.service = service;
        this.artists = null;
        this.someValue = 255;
        this.artists = this.service.getArtists();
    }
    Performers = __decorate([
        core_1.Component({
            selector: "performers",
            templateUrl: "/app/components/performers/performersListing.html"
        }), 
        __metadata('design:paramtypes', [ArtistsService_1.ArtistsService])
    ], Performers);
    return Performers;
}());
exports.Performers = Performers;
browser_1.bootstrap(Performers, [
    http_1.HTTP_PROVIDERS, ArtistsService_1.ArtistsService
]);
