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
    var EntryListComponent;
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
            EntryListComponent = (function () {
                function EntryListComponent(_service, _router, routeParams) {
                    this._service = _service;
                    this._router = _router;
                    this._selectedEntryId = +routeParams.get('id');
                }
                EntryListComponent.prototype.isSelected = function (entryModel) { return entryModel.id === this._selectedEntryId; };
                EntryListComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this._service.getEntries().then(function (entries) { return _this.entries = entries; });
                };
                EntryListComponent.prototype.onSelect = function (entryModel) {
                    this._router.navigate(['Entry', { id: entryModel.id }]);
                };
                EntryListComponent = __decorate([
                    core_1.Component({
                        template: "\n        <h2>ENTRY LIST COMPONENT</h2>\n    <ul>\n      <li *ngFor=\"#entry of entries\"\n        [class.selected]=\"isSelected(entry)\"\n        (click)=\"onSelect(entry)\">\n        <span class=\"badge\">{{entry.getTime()}}</span> {{entry.name}}\n      </li>\n    </ul>\n        ",
                        providers: [officehours_service_1.OfficeHoursService]
                    }), 
                    __metadata('design:paramtypes', [officehours_service_1.OfficeHoursService, router_1.Router, router_1.RouteParams])
                ], EntryListComponent);
                return EntryListComponent;
            })();
            exports_1("EntryListComponent", EntryListComponent);
        }
    }
});
//# sourceMappingURL=entry-list.component.js.map