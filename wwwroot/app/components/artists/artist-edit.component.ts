import {Component, OnInit} from 'angular2/core';
import {RouteParams} from 'angular2/router';

@Component({
    templateUrl: '/app/components/artists/artist-edit.component.html',
    providers: [RouteParams]
})

export class ArtistEditComponent implements OnInit {
    private articleId: number;
    private pageTitle: string = 'Edit artist';

    constructor(private _routeParams: RouteParams) {
        let artId: string = this.getQueryString("id", null);
        console.log('ROUTE PARAMS = ' + _routeParams.toString());
    }

    ngOnInit(): void {

    }

    /**
* Get the value of a querystring
* @param  {String} field The field to get the value of
* @param  {String} url   The URL to get the value from (optional)
* @return {String}       The field value
*/
    getQueryString = function (field, url) {
        var href = url ? url : window.location.href;
        var reg = new RegExp('[?&]' + field + '=([^&#]*)', 'i');
        var string = reg.exec(href);
        return string ? string[1] : null;
    };

}