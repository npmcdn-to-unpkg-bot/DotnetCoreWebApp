import { Component } from 'angular2/core';
import { HTTP_PROVIDERS } from 'angular2/http';
import 'rxjs/Rx';   // Load all features
import { ROUTER_PROVIDERS, RouteConfig, ROUTER_DIRECTIVES } from 'angular2/router';

import { ArtistsListingComponent } from './artists-listing.component';
import {ArtistsService} from "./artists.service";
import { ArtistEditComponent } from './artist-edit.component';

@Component({
    selector: 'artists-app',
    templateUrl: '/app/components/artists/app.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [ArtistsService,
        HTTP_PROVIDERS,
        ROUTER_PROVIDERS]
})
@RouteConfig([
    { path: '/artists-list', name: 'ArtiststList', component: ArtistsListingComponent, useAsDefault: true },
    { path: '/artist-edit/:id', name: 'ArtistEdit', component: ArtistEditComponent }
])
export class AppComponent {
    pageTitle: string = 'My Artists Application';
}

