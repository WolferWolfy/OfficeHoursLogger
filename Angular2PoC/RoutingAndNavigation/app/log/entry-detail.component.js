System.register(['angular2/core', './officehours.service', 'angular2/router'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, officehours_service_1, router_1;
    var EntryDetailComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (officehours_service_1_1) {
                officehours_service_1 = officehours_service_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            }],
        execute: function() {
            EntryDetailComponent = (function () {
                function EntryDetailComponent(_router, _routeParams, _service) {
                    this._router = _router;
                    this._routeParams = _routeParams;
                    this._service = _service;
                }
                EntryDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id = this._routeParams.get('id');
                    this._service.getEntry(id).then(function (hero) { return _this.entry = hero; });
                };
                EntryDetailComponent.prototype.gotoEntries = function () {
                    var entryId = this.entry ? this.entry.id : null;
                    // Pass along the hero id if available
                    // so that the HeroList component can select that hero.
                    // Add a totally useless `foo` parameter for kicks.
                    this._router.navigate(['Entries', { id: entryId }]); //, day: this.entry.date }]);
                };
                EntryDetailComponent = __decorate([
                    core_1.Component({
                        template: "\n  <h2>ENTRY</h2>\n  <div *ngIf=\"entry\">\n    <h3>\"{{entry.name}}\"</h3>\n    <div>\n      <label>Id: </label>{{entry.id}}</div>\n    <div>\n      <label>Name: </label>\n      <input [(ngModel)]=\"entry.name\" placeholder=\"name\"/>\n    </div>\n    <button (click)=\"gotoEntries()\">Back - day id needed</button>\n  </div>\n  ",
                    }), 
                    __metadata('design:paramtypes', [router_1.Router, router_1.RouteParams, officehours_service_1.OfficeHoursService])
                ], EntryDetailComponent);
                return EntryDetailComponent;
            })();
            exports_1("EntryDetailComponent", EntryDetailComponent);
        }
    }
});
/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/ 
//# sourceMappingURL=entry-detail.component.js.map