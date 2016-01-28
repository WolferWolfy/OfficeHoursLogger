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
        </nav>
        <router-outlet></router-outlet>
      `,
    providers: [DialogService, HeroService, OfficeHoursService],
    directives: [ROUTER_DIRECTIVES]
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
export class AppComponent { }
