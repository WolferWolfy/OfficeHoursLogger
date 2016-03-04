import {Component, OnInit} from 'angular2/core';
import {MonthModel} from './month.model';
import {OfficeHoursService} from './officehours.service';
import {Router, RouteParams} from 'angular2/router';

@Component({
    template: `
        <h2>MONTHS LIST COMPONENT</h2>
        <p>List your logged months here</p>
        `,
    providers: [OfficeHoursService]
})
export class MonthListComponent implements OnInit {
    months: MonthModel[];

    private _selectedMonth: number;
    private _selectedYearOfMonth: number;

    constructor(
        private _service: OfficeHoursService,
        private _router: Router,
        routeParams: RouteParams) {
        this._selectedMonth = +routeParams.get('month');
        this._selectedYearOfMonth = +routeParams.get('year');
    }

    isSelected(monthModel: MonthModel) { return monthModel.year === this._selectedYearOfMonth && monthModel.month === this._selectedMonth ; }

    ngOnInit() {
        this._service.getMonths().then(months => this.months = months);
    }

    onSelect(monthModel: MonthModel) {
        this._router.navigate(['Days', {month: monthModel.month, year: monthModel.year}]);
    }
}