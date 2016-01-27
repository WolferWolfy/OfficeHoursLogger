import {Injectable} from 'angular2/core';
import {EntryModel} from './entry.model';
import {DayModel} from './day.model';
import {MonthModel} from './month.model';

@Injectable()
export class OfficeHoursService {
    getMonths() { return monthsPromise; }

    getCrisis(year: number | string, month: number | string) {
        return monthsPromise
            .then(months => months.filter(m => m.year === year && m.month === month)[0]);
    }

    getDays() { return daysPromise; }

    getDay(year: number, month: number, day: number) {
        return daysPromise
            .then(days => days.filter(d => d.year === year && d.month === month && d.day === day)[0]);
    }

    getEntries() { return entriesPromise; }

    getSimpleEntries() {
        return entries;
    }

    getEntry(id: number) {
        return entriesPromise
            .then(entries => entries.filter(e => e.id === id)[0]);
    }


  /*  static nextCrisisId = 100;

    addMonth(year: number, month: number) {
        name = name.trim();
        if (name) {
            let crisis = new Crisis(CrisisService.nextCrisisId++, name);
            crisesPromise.then(crises => crises.push(crisis));
        }
    }*/
}

var monthsPromise = Promise.resolve(months);

var months = [
    new MonthModel(2015, 11),
    new MonthModel(2015, 12),
    new MonthModel(2016, 1),
    new MonthModel(2016, 2),
    new MonthModel(2016, 3)
];

var daysPromise = Promise.resolve(days);

var days = [
    new DayModel(2016, 2, 15),
    new DayModel(2016, 2, 16),
    new DayModel(2016, 2, 17),
    new DayModel(2016, 2, 18),
    new DayModel(2016, 2, 19)
];

var entriesPromise = Promise.resolve(entries);

var entries = [
    new EntryModel(1, "Arrive"),
    new EntryModel(2, "Break start"),
    new EntryModel(3, "Break end"),
    new EntryModel(4, "Depart")
];
