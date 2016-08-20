import {bootstrap} from 'angular2/platform/browser';
import {Component, OnInit} from 'angular2/core';


@Component({
    selector: 'main-app',
    templateUrl: '/app/components/app.component.html'
})
export class AppComponent {
    pageTitle: string = 'My dot net core angular2 application';
}

bootstrap(AppComponent, []);