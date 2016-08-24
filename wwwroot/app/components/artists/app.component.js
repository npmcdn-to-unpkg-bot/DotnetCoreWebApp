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
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
require('rxjs/Rx'); // Load all features
var router_1 = require('angular2/router');
var artists_listing_component_1 = require('./artists-listing.component');
var artists_service_1 = require("./artists.service");
var artist_edit_component_1 = require('./artist-edit.component');
var AppComponent = (function () {
    function AppComponent() {
        this.pageTitle = 'My Artists Application';
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'artists-app',
            templateUrl: '/app/components/artists/app.component.html',
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [artists_service_1.ArtistsService,
                http_1.HTTP_PROVIDERS,
                router_1.ROUTER_PROVIDERS]
        }),
        router_1.RouteConfig([
            { path: '/artists-list', name: 'ArtiststList', component: artists_listing_component_1.ArtistsListingComponent, useAsDefault: true },
            { path: '/artist-edit/:id', name: 'ArtistEdit', component: artist_edit_component_1.ArtistEditComponent }
        ]), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
