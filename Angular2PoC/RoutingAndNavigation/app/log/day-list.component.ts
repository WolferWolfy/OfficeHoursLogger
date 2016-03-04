import {Component, OnInit} from 'angular2/core';
//import {MonthModel} from './month.model';
import {DayModel} from './day.model';
import {OfficeHoursService} from './officehours.service';
import {Router, RouteParams} from 'angular2/router';
import {NgClass} from 'angular2/common';
import {DateTimeModel} from './datetime.model';

@Component({
templateUrl: 'app/html/day-list.component.html',
    providers: [OfficeHoursService],
    directives: [NgClass]
})
export class DayListComponent implements OnInit {
    days: DayModel[];

    private _selectedDay: DateTimeModel;

    constructor(
        private _service: OfficeHoursService,
        private _router: Router,
        routeParams: RouteParams) {
        this._selectedDay = new DateTimeModel(0, 0, 0, 0, 0, 0);
        this._selectedDay.day = +routeParams.get('day');
        this._selectedDay.month = +routeParams.get('month');
        if (this._selectedDay.month == null) {
            this._selectedDay.month = 1;
        }

        this._selectedDay.year = +routeParams.get('year');
    }

    // isSelected(monthModel: MonthModel) { return false };

    isSelected(dayModel: DayModel) { return dayModel.day.year === this._selectedDay.year && dayModel.day.month === this._selectedDay.month && dayModel.day.day === this._selectedDay.day; }

    ngOnInit() {
        // this._service.getMonths().then(months => this.months = months);
   /*     this._service.getDays().subscribe(
            days => this.days = days,
            error => alert(error));
*/
        this._service.getDaysForMonth(this._selectedDay).subscribe(
            days => this.days = days,
            error => alert(error));
    }

    onSelect(dayModel: DayModel) {
        this._router.navigate(['Entries', { day: dayModel.day.day, month: dayModel.day.month, year: dayModel.day.year }]);
    }
}