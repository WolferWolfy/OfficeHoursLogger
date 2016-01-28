System.register(['angular2/core', './entry.model', './day.model', './month.model'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, entry_model_1, day_model_1, month_model_1;
    var OfficeHoursService, months, monthsPromise, days, daysPromise, entries, entriesPromise;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (entry_model_1_1) {
                entry_model_1 = entry_model_1_1;
            },
            function (day_model_1_1) {
                day_model_1 = day_model_1_1;
            },
            function (month_model_1_1) {
                month_model_1 = month_model_1_1;
            }],
        execute: function() {
            OfficeHoursService = (function () {
                function OfficeHoursService() {
                }
                OfficeHoursService.prototype.getMonths = function () { return monthsPromise; };
                OfficeHoursService.prototype.getMonth = function (year, month) {
                    return monthsPromise
                        .then(function (months) { return months.filter(function (m) { return m.year === year && m.month === month; })[0]; });
                };
                OfficeHoursService.prototype.getDays = function () { return daysPromise; };
                OfficeHoursService.prototype.getDay = function (year, month, day) {
                    return daysPromise
                        .then(function (days) { return days.filter(function (d) { return d.year === year && d.month === month && d.day === day; })[0]; });
                };
                OfficeHoursService.prototype.getEntries = function () { return entriesPromise; };
                OfficeHoursService.prototype.getEntriesForDate = function (date) {
                    // later query based on date 
                    return entriesPromise;
                };
                OfficeHoursService.prototype.getEntriesForDayFromEntryId = function (entryId) {
                    // later query based on entryId 
                    return entriesPromise;
                };
                OfficeHoursService.prototype.getEntry = function (id) {
                    return entriesPromise
                        .then(function (entries) { return entries.filter(function (e) { return e.id === +id; })[0]; });
                };
                OfficeHoursService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [])
                ], OfficeHoursService);
                return OfficeHoursService;
            })();
            exports_1("OfficeHoursService", OfficeHoursService);
            months = [
                new month_model_1.MonthModel(2015, 11),
                new month_model_1.MonthModel(2015, 12),
                new month_model_1.MonthModel(2016, 1),
                new month_model_1.MonthModel(2016, 2),
                new month_model_1.MonthModel(2016, 3)
            ];
            monthsPromise = Promise.resolve(months);
            days = [
                new day_model_1.DayModel(2016, 2, 15),
                new day_model_1.DayModel(2016, 2, 16),
                new day_model_1.DayModel(2016, 2, 17),
                new day_model_1.DayModel(2016, 2, 18),
                new day_model_1.DayModel(2016, 2, 19)
            ];
            daysPromise = Promise.resolve(days);
            //new Date(year, month, day, hours, minutes, seconds)
            entries = [
                new entry_model_1.EntryModel(1, "Arrive", new Date(2016, 2, 1, 8, 55, 0)),
                new entry_model_1.EntryModel(2, "Break start", new Date(2016, 2, 1, 11, 30, 0)),
                new entry_model_1.EntryModel(3, "Break end", new Date(2016, 2, 1, 12, 5, 0)),
                new entry_model_1.EntryModel(4, "Depart", new Date(2016, 2, 1, 17, 30, 0)),
            ];
            entriesPromise = Promise.resolve(entries);
        }
    }
});
//# sourceMappingURL=officehours.service.js.map