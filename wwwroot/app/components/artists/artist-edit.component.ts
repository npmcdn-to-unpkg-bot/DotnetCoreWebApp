import {Component, OnInit} from 'angular2/core';
import {RouteParams, Router} from 'angular2/router';

@Component({
    templateUrl: '/app/components/artists/artist-edit.component.html'
})

export class ArtistEditComponent implements OnInit {
    private articleId: number;
    private pageTitle: string = 'Edit artist with ID ';

    constructor(private _routeParams: RouteParams,
        private _router: Router) {

        let id = +this._routeParams.get('id');
        this.pageTitle += ` ${id}`;
    }

    ngOnInit(): void {

    }

    onBack(): void {
        this._router.navigate(['ArtiststList']);
    }


}