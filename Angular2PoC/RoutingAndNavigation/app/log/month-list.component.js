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
    var MonthListComponent;
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
            MonthListComponent = (function () {
                function MonthListComponent(_service, _router, routeParams) {
                    this._service = _service;
                    this._router = _router;
                    this._selectedMonth = +routeParams.get('month');
                    this._selectedYearOfMonth = +routeParams.get('year');
                }
                MonthListComponent.prototype.isSelected = function (monthModel) { return monthModel.year === this._selectedYearOfMonth && monthModel.month === this._selectedMonth; };
                MonthListComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    this._service.getMonths().then(function (months) { return _this.months = months; });
                };
                MonthListComponent.prototype.onSelect = function (monthModel) {
                    this._router.navigate(['Days', { month: monthModel.month, year: monthModel.year }]);
                };
                MonthListComponent = __decorate([
                    core_1.Component({
                        template: "\n        <h2>MONTHS LIST COMPONENT</h2>\n        <p>List your logged months here</p>\n        ",
                        providers: [officehours_service_1.OfficeHoursService]
                    }), 
                    __metadata('design:paramtypes', [officehours_service_1.OfficeHoursService, router_1.Router, router_1.RouteParams])
                ], MonthListComponent);
                return MonthListComponent;
            })();
            exports_1("MonthListComponent", MonthListComponent);
        }
    }
});
//# sourceMappingURL=month-list.component.js.map