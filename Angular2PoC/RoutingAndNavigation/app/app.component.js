System.register(['angular2/core', 'angular2/router', './crisis-center/crisis-center.component', './heroes/hero-list.component', './heroes/hero-detail.component', './dialog.service', './heroes/hero.service', './log/officehours.service', './log/entry-list.component', './log/entry-detail.component', './log/month-list.component', './about.component', 'angular2/http', 'angular2-jwt'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, crisis_center_component_1, hero_list_component_1, hero_detail_component_1, dialog_service_1, hero_service_1, officehours_service_1, entry_list_component_1, entry_detail_component_1, month_list_component_1, about_component_1, http_1, angular2_jwt_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (crisis_center_component_1_1) {
                crisis_center_component_1 = crisis_center_component_1_1;
            },
            function (hero_list_component_1_1) {
                hero_list_component_1 = hero_list_component_1_1;
            },
            function (hero_detail_component_1_1) {
                hero_detail_component_1 = hero_detail_component_1_1;
            },
            function (dialog_service_1_1) {
                dialog_service_1 = dialog_service_1_1;
            },
            function (hero_service_1_1) {
                hero_service_1 = hero_service_1_1;
            },
            function (officehours_service_1_1) {
                officehours_service_1 = officehours_service_1_1;
            },
            function (entry_list_component_1_1) {
                entry_list_component_1 = entry_list_component_1_1;
            },
            function (entry_detail_component_1_1) {
                entry_detail_component_1 = entry_detail_component_1_1;
            },
            function (month_list_component_1_1) {
                month_list_component_1 = month_list_component_1_1;
            },
            function (about_component_1_1) {
                about_component_1 = about_component_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (angular2_jwt_1_1) {
                angular2_jwt_1 = angular2_jwt_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(http, authHttp) {
                    this.http = http;
                    this.authHttp = authHttp;
                    this.lock = new Auth0Lock('eFNIC2E6bz8PPju7fFoMHSD9SnWVgoXM', 'wolfer.eu.auth0.com');
                    this.jwtHelper = new angular2_jwt_1.JwtHelper();
                }
                AppComponent.prototype.login = function () {
                    this.lock.show(function (err, profile, id_token) {
                        if (err) {
                            throw new Error(err);
                        }
                        localStorage.setItem('profile', JSON.stringify(profile));
                        localStorage.setItem('id_token', id_token);
                    });
                };
                AppComponent.prototype.logout = function () {
                    localStorage.removeItem('profile');
                    localStorage.removeItem('id_token');
                };
                AppComponent.prototype.loggedIn = function () {
                    return angular2_jwt_1.tokenNotExpired();
                };
                AppComponent.prototype.getThing = function () {
                    this.http.get('http://localhost:3001/ping')
                        .subscribe(function (data) { return console.log(data.json()); }, function (err) { return console.log(err); }, function () { return console.log('Complete'); });
                };
                AppComponent.prototype.getSecretThing = function () {
                    this.authHttp.get('http://localhost:3001/secured/ping')
                        .subscribe(function (data) { return console.log(data.json()); }, function (err) { return console.log(err); }, function () { return console.log('Complete'); });
                };
                AppComponent.prototype.tokenSubscription = function () {
                    this.authHttp.tokenStream.subscribe(function (data) { return console.log(data); }, function (err) { return console.log(err); }, function () { return console.log('Complete'); });
                };
                AppComponent.prototype.useJwtHelper = function () {
                    var token = localStorage.getItem('id_token');
                    console.log(this.jwtHelper.decodeToken(token), this.jwtHelper.getTokenExpirationDate(token), this.jwtHelper.isTokenExpired(token));
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'my-app',
                        template: "\n        <h1 class=\"title\">Component Router</h1>\n        <nav>\n          <a [routerLink]=\"['CrisisCenter']\">Crisis Center</a>\n          <a [routerLink]=\"['Heroes']\">Heroes</a>\n          <a [routerLink]=\"['Entries']\">Entries</a>\n          <a [routerLink]=\"['Months']\">Months</a>\n          <a [routerLink]=\"['About']\">About</a>\n        </nav>\n        <router-outlet></router-outlet>\n\n        <div>\n            <button *ngIf=\"!loggedIn()\" (click)=\"login()\">Login</button>\n            <button *ngIf=\"loggedIn()\" (click)=\"logout()\">Logout</button>\n   \n        </div>\n        <hr>\n        <button (click)=\"getThing()\">Get Thing</button>\n        <button *ngIf=\"loggedIn()\" (click)=\"tokenSubscription()\">Show Token from Observable</button>\n        <button (click)=\"getSecretThing()\">Get Secret Thing</button>\n        <button *ngIf=\"loggedIn()\" (click)=\"useJwtHelper()\">Use Jwt Helper</button>\n      ",
                        providers: [dialog_service_1.DialogService, hero_service_1.HeroService, officehours_service_1.OfficeHoursService, angular2_jwt_1.JwtHelper, angular2_jwt_1.AuthHttp],
                        //providers: [DialogService, HeroService, OfficeHoursService], // do I need to list those above providers?
                        directives: [router_1.ROUTER_DIRECTIVES],
                    }),
                    router_1.RouteConfig([
                        {
                            path: '/crisis-center/...',
                            name: 'CrisisCenter',
                            component: crisis_center_component_1.CrisisCenterComponent,
                            useAsDefault: true
                        },
                        { path: '/heroes', name: 'Heroes', component: hero_list_component_1.HeroListComponent },
                        { path: '/hero/:id', name: 'HeroDetail', component: hero_detail_component_1.HeroDetailComponent },
                        { path: '/disaster', name: 'Asteroid', redirectTo: ['CrisisCenter', 'CrisisDetail', { id: 3 }] },
                        { path: '/months', component: month_list_component_1.MonthListComponent, name: 'Months' },
                        { path: '/entries', component: entry_list_component_1.EntryListComponent, name: 'Entries' },
                        { path: '/entry/:id', component: entry_detail_component_1.EntryDetailComponent, name: 'Entry' },
                        { path: '/about', component: about_component_1.AboutComponent, name: 'About' }
                    ]), 
                    __metadata('design:paramtypes', [http_1.Http, angular2_jwt_1.AuthHttp])
                ], AppComponent);
                return AppComponent;
            })();
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map