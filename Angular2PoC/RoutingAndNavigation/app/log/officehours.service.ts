import {Injectable} from 'angular2/core';
import {EntryModel} from './entry.model';
import {DayModel} from './day.model';
import {MonthModel} from './month.model';
import {DateTimeModel} from './datetime.model';

import {Http}       from 'angular2/http';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class OfficeHoursService {

    constructor(private http: Http) { }

  //  private _entriesJson = 'app/json/entries.json';
    private _entriesUrl = 'http://localhost:64485/api/test/DayLog';

 //   latestEntries: Observable<EntryModel[]>;
    latestEntries: EntryModel[];


    getMonths() { return monthsPromise; }

    getMonth(year: number | string, month: number | string) {
        return monthsPromise
            .then(months => months.filter(m => m.year === year && m.month === month)[0]);
    }

    getDays() { return daysPromise; }

    getDay(year: number, month: number, day: number) {
        return daysPromise
            .then(days => days.filter(d => d.year === year && d.month === month && d.day === day)[0]);
    }

    getEntries() {
        var entries = this.http.get(this._entriesUrl)
            .map(res => <EntryModel[]>(res.json()["logEntries"]))
            .catch(this.logAndPassOn);

        entries.subscribe(entries => this.latestEntries = entries);

        return entries;
    }



    getEntriesForDate(date: Date) {
        // later query based on date 
        return entriesPromise;
    }

    getEntriesForDayFromEntryId(entryId: number) {
        // later query based on entryId 
        return entriesPromise;
    }


    getEntry(id: number | string) {
        return this.http.get(this._entriesUrl)
            .map(res => ((<EntryModel[]>res.json()["logEntries"]).filter(e => e.logEntryId === +id))[0])
            .catch(this.logAndPassOn);
    }

    /*
    getEntry(id: number | string) {
        
        if (!this.latestEntries) {
            return this.latestEntries.filter(e => e.logEntryId === +id)[0];
        }

       this.getEntries().subscribe(
           entries => this.latestEntries = entries,
           error => alert(error))            ; 

        return this.latestEntries.filter(e => e.logEntryId === +id)[0];
    }

    */
  /*  static nextCrisisId = 100;

    addMonth(year: number, month: number) {
        name = name.trim();
        if (name) {
            let crisis = new Crisis(CrisisService.nextCrisisId++, name);
            crisesPromise.then(crises => crises.push(crisis));
        }
    }*/

    private logAndPassOn(error: Error) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error);
    }
}

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

//new Date(year, month, day, hours, minutes, seconds)
var entries = [
    new EntryModel(1, "Arrive", new DateTimeModel(2016, 2, 1, 8, 55, 0), 0),
    new EntryModel(2, "Break start", new DateTimeModel(2016, 2, 1, 11, 30, 0), 1),
    new EntryModel(3, "Break end", new DateTimeModel(2016, 2, 1, 12, 5, 0), 0),
    new EntryModel(4, "Depart", new DateTimeModel(2016, 2, 1, 17, 30, 0), 1),
];

var entriesPromise = Promise.resolve(entries);

