﻿import {Injectable} from 'angular2/core';
import {EntryModel} from './entry.model';
import {DayModel} from './day.model';
import {MonthModel} from './month.model';

@Injectable()
export class OfficeHoursService {
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

    getEntries() { return entriesPromise; }

    getEntriesForDate(date: Date) {
        // later query based on date 
        return entriesPromise;
    }


    getEntriesForDayFromEntryId(entryId: number) {
        // later query based on entryId 
        return entriesPromise;
    }

    getEntry(id: number | string) {
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
    new EntryModel(1, "Arrive", new Date(2016, 2, 1, 8, 55, 0)),
    new EntryModel(2, "Break start", new Date(2016, 2, 1, 11, 30, 0)),
    new EntryModel(3, "Break end", new Date(2016, 2, 1, 12, 5, 0)),
    new EntryModel(4, "Depart", new Date(2016, 2, 1, 17, 30, 0)),
];

var entriesPromise = Promise.resolve(entries);

