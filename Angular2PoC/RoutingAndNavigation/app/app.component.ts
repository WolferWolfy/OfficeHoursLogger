import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';
import {CrisisCenterComponent} from './crisis-center/crisis-center.component';
import {HeroListComponent}     from './heroes/hero-list.component';
import {HeroDetailComponent}   from './heroes/hero-detail.component';
import {DialogService}         from './dialog.service';
import {HeroService}           from './heroes/hero.service';

import {OfficeHoursService}     from './log/officehours.service';
import {EntryListComponent}     from './log/entry-list.component';
import {EntryDetailComponent}   from './log/entry-detail.component';
import {MonthListComponent}     from './log/month-list.component';
import {AboutComponent}         from './about.component';



import {HTTP_PROVIDERS, Http} from 'angular2/http';
import {AuthHttp, AuthConfig, tokenNotExpired, JwtHelper} from 'angular2-jwt';

declare var Auth0Lock;

@Component({
    selector: 'my-app',
    template: `
        <h1 class="title">Component Router</h1>
        <nav>
          <a [routerLink]="['CrisisCenter']">Crisis Center</a>
          <a [routerLink]="['Heroes']">Heroes</a>
          <a [routerLink]="['Entries']">Entries</a>
          <a [routerLink]="['Months']">Months</a>
          <a [routerLink]="['About']">About</a>
          <button *ngIf="loggedIn()" (click)="logout()">Logout</button>
        </nav>
        <router-outlet></router-outlet>

<hr>
        <div>
            <button *ngIf="!loggedIn()" (click)="login()">Login</button>
            <button *ngIf="loggedIn()" (click)="logout()">Logout</button>
   
        <button (click)="getThing()">Get Thing</button>
        <button *ngIf="loggedIn()" (click)="tokenSubscription()">Show Token from Observable</button>
        <button (click)="getSecretThing()">Get Secret Thing</button>
        <button *ngIf="loggedIn()" (click)="useJwtHelper()">Use Jwt Helper</button>
</div>
      `,
    providers: [DialogService, HeroService, OfficeHoursService, JwtHelper, AuthHttp],
    //providers: [DialogService, HeroService, OfficeHoursService], // do I need to list those above providers?
    directives: [ROUTER_DIRECTIVES],
    // directives: [ROUTER_DIRECTIVES, EntryListComponent, EntryDetailComponent, MonthListComponent, AboutComponent],

})
@RouteConfig([
    { // Crisis Center child route
        path: '/crisis-center/...',
        name: 'CrisisCenter',
        component: CrisisCenterComponent,
        useAsDefault: true
    },
    { path: '/heroes', name: 'Heroes', component: HeroListComponent },
    { path: '/hero/:id', name: 'HeroDetail', component: HeroDetailComponent },
    { path: '/disaster', name: 'Asteroid', redirectTo: ['CrisisCenter', 'CrisisDetail', { id: 3 }] },
    { path: '/months', component: MonthListComponent, name: 'Months' },
    { path: '/entries', component: EntryListComponent, name: 'Entries' },
    { path: '/entry/:id', component: EntryDetailComponent, name: 'Entry' },
    { path: '/about', component: AboutComponent, name: 'About' }
])

export class AppComponent {

    lock = new Auth0Lock('eFNIC2E6bz8PPju7fFoMHSD9SnWVgoXM', 'wolfer.eu.auth0.com');
    jwtHelper: JwtHelper = new JwtHelper();

    constructor(public http: Http, public authHttp: AuthHttp) { }


    login() {
        this.lock.show((err: string, profile: string, id_token: string) => {

            if (err) {
                throw new Error(err);
            }

            localStorage.setItem('profile', JSON.stringify(profile));
            localStorage.setItem('id_token', id_token);

        });
    }

    logout() {
        localStorage.removeItem('profile');
        localStorage.removeItem('id_token');
    }

    loggedIn() {
        return tokenNotExpired();
    }

    getThing() {
        this.http.get('http://localhost:3001/ping')
            .subscribe(
            data => console.log(data.json()),
            err => console.log(err),
            () => console.log('Complete')
            );
    }

    getSecretThing() {
        this.authHttp.get('http://localhost:3001/secured/ping')
            .subscribe(
            data => console.log(data.json()),
            err => console.log(err),
            () => console.log('Complete')
            );
    }

    tokenSubscription() {
        this.authHttp.tokenStream.subscribe(
            data => console.log(data),
            err => console.log(err),
            () => console.log('Complete')
        );
    }

    useJwtHelper() {
        var token = localStorage.getItem('id_token');

        console.log(
            this.jwtHelper.decodeToken(token),
            this.jwtHelper.getTokenExpirationDate(token),
            this.jwtHelper.isTokenExpired(token)
        );
    }

}
