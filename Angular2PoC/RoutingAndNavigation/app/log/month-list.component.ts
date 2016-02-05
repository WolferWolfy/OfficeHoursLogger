import {Component, OnInit} from 'angular2/core';
import {MonthModel} from './month.model';
import {OfficeHoursService} from './officehours.service';
import {Router, RouteParams} from 'angular2/router';
import {NgClass} from 'angular2/common';
import {DateTimeModel} from './datetime.model';

@Component({
    template: `
        <h2>MONTHS LIST COMPONENT</h2>
<span>     Month  Avg. In - Avg. Out  </span>
    <ul>
      <li *ngFor="#month of months"
        [class.selected]="isSelected(month)"
        (click)="onSelect(month)">
        <span>{{month.month.year}}.{{month.month.month}}</span> {{month.averageIn}} - {{month.averageOut}}
      </li>
    </ul>
        `,
    providers: [OfficeHoursService],
    directives: [NgClass]
})
export class MonthListComponent implements OnInit {
    months: MonthModel[];

    private _selectedMonth: DateTimeModel;

    constructor(
        private _service: OfficeHoursService,
        private _router: Router,
        routeParams: RouteParams) {
        this._selectedMonth = new DateTimeModel(0, 0, 0, 0, 0, 0);
        this._selectedMonth.month = +routeParams.get('month');
        this._selectedMonth.year = +routeParams.get('year');
    }

   // isSelected(monthModel: MonthModel) { return false };

    isSelected(monthModel: MonthModel) { return monthModel.month.year === this._selectedMonth.year && monthModel.month.month === this._selectedMonth.month ; }

    ngOnInit() {
       // this._service.getMonths().then(months => this.months = months);
        this._service.getMonths().subscribe(
            months => this.months = months,
            error => alert(error)); 
    }

    onSelect(monthModel: MonthModel) {
        this._router.navigate(['Days', {month: monthModel.month.month, year: monthModel.month.year}]);
    }
}