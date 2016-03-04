import {DateTimeModel} from './datetime.model';
import {DayModel} from './day.model';
export class MonthModel {
    constructor(public id: number,
        public month: DateTimeModel,
        public averageIn: string,
        public averageOut: string,
        public days: DayModel[]) { }
}

