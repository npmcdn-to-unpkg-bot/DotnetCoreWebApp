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
var router_1 = require('angular2/router');
var ArtistEditComponent = (function () {
    function ArtistEditComponent(_routeParams) {
        this._routeParams = _routeParams;
        this.pageTitle = 'Edit artist';
        /**
    * Get the value of a querystring
    * @param  {String} field The field to get the value of
    * @param  {String} url   The URL to get the value from (optional)
    * @return {String}       The field value
    */
        this.getQueryString = function (field, url) {
            var href = url ? url : window.location.href;
            var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
            var string = reg.exec(href);
            return string ? string[1] : null;
        };
        var artId = this.getQueryString("id", null);
        console.log('ROUTE PARAMS = ' + _routeParams.toString());
    }
    ArtistEditComponent.prototype.ngOnInit = function () {
    };
    ArtistEditComponent = __decorate([
        core_1.Component({
            templateUrl: '/app/components/artists/artist-edit.component.html',
            providers: [router_1.RouteParams]
        }), 
        __metadata('design:paramtypes', [router_1.RouteParams])
    ], ArtistEditComponent);
    return ArtistEditComponent;
}());
exports.ArtistEditComponent = ArtistEditComponent;
