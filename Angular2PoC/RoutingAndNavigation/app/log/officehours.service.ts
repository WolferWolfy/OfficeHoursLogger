import {Injectable} from 'angular2/core';
import {EntryModel} from './entry.model';
import {DayModel} from './day.model';
import {MonthModel} from './month.model';
import {DateTimeModel} from './datetime.model';

import {Http, Headers}       from 'angular2/http';
import {Observable} from 'rxjs/Observable';
import {AuthHttp, AuthConfig, tokenNotExpired, JwtHelper} from 'angular2-jwt';

@Injectable()
export class OfficeHoursService {

    constructor(private http: Http, private authHttp: AuthHttp) { }

    //  private _entriesJson = 'app/json/entries.json';
    private _entriesUrl = 'http://localhost:64485/api/test/DayLog';

    private serviceBaseUrl = 'http://localhost:64485/api/logentry/';

    private dayLogUrl = 'daylog';
    private monthLogUrl = 'monthlog';
    private completeLogUrl = 'completelog';
    private logEntryUrl = 'entrylog';
    private addLogEntryUrl = 'addlogentry';
    private updateLogEntryUrl = 'updatelogentry';
    private deleteLogEntryUrl = 'deletelogentry';
   

    //   latestEntries: Observable<EntryModel[]>;
    latestEntries: EntryModel[];
    latestDays: DayModel[];
    latestMonths: MonthModel[];

    lastRequestedDateTime: DateTimeModel;
    lastRequestedId: number;


    getMonths() {
        var months = this.authHttp.post(this.serviceBaseUrl + this.completeLogUrl, null)
            .map(res => <MonthModel[]>(res.json()))
            .catch(this.logAndPassOn);

        months.subscribe(months => this.latestMonths = months);

        return months;
    }

    getDays() {

        var days = this.authHttp.post(this.serviceBaseUrl + this.monthLogUrl, "" + this.lastRequestedDateTime)
            .map(res => <DayModel[]>(res.json()))
            .catch(this.logAndPassOn);

        days.subscribe(days => this.latestDays = days);

        return days;
    }


    getDaysForMonth(date: DateTimeModel) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.lastRequestedDateTime = date;
        var days = this.authHttp.post(this.serviceBaseUrl + this.monthLogUrl, JSON.stringify(date), {
            headers: headers
        })
            .map(res => <DayModel[]>(res.json()["days"]))
            .catch(this.logAndPassOn);

        days.subscribe(days => this.latestDays = days);

        return days;
    }

    getEntries() {
        var entries = this.http.get(this._entriesUrl)
            .map(res => <EntryModel[]>(res.json()["logEntries"]))
            .catch(this.logAndPassOn);

        entries.subscribe(entries => this.latestEntries = entries);

        return entries;
    }

    getEntriesForDate(date: DateTimeModel) {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.lastRequestedDateTime = date;
        var logEntries = this.authHttp.post(this.serviceBaseUrl + this.dayLogUrl, JSON.stringify(date), {
            headers: headers
        })
            .map(res => <EntryModel[]>(res.json()["logEntries"]))
            .catch(this.logAndPassOn);

        logEntries.subscribe(logEntries => this.latestEntries = logEntries);

        return logEntries;
    }

    getEntriesForDayFromEntryId(entryId: number) {
        // later query based on entryId 
        return entriesPromise;
    }


    getEntry(id: number | string) {

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.lastRequestedId = +id;
        var logEntry = this.authHttp.post(this.serviceBaseUrl + this.logEntryUrl, JSON.stringify(+id), {
            headers: headers
        })
            .map(res => <EntryModel>(res.json()))
            .catch(this.logAndPassOn);

        return logEntry;
    }

    getSecretThing() {
        this.authHttp.get('http://localhost:64485/api/test/securedping')
            .subscribe(
            data => console.log(data.json()),
            err => console.log(err),
            () => console.log('Complete')
            );
    }

    private logAndPassOn(error: Error) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error);
    }
}

/*
var months = [
    new MonthModel(2015, 11),
    new MonthModel(2015, 12),
    new MonthModel(2016, 1),
    new MonthModel(2016, 2),
    new MonthModel(2016, 3)
];

var monthsPromise = Promise.resolve(months);

var days = [
    new DayModel(2016, 2, 15),
    new DayModel(2016, 2, 16),
    new DayModel(2016, 2, 17),
    new DayModel(2016, 2, 18),
    new DayModel(2016, 2, 19)
];

var daysPromise = Promise.resolve(days);
*/

//new Date(year, month, day, hours, minutes, seconds)
var entries = [
    new EntryModel(1, "Arrive", new DateTimeModel(2016, 2, 1, 8, 55, 0), 0),
    new EntryModel(2, "Break start", new DateTimeModel(2016, 2, 1, 11, 30, 0), 1),
    new EntryModel(3, "Break end", new DateTimeModel(2016, 2, 1, 12, 5, 0), 0),
    new EntryModel(4, "Depart", new DateTimeModel(2016, 2, 1, 17, 30, 0), 1),
];

var entriesPromise = Promise.resolve(entries);

