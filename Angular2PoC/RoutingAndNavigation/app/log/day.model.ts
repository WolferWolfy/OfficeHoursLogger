import {DateTimeModel} from './datetime.model';
import {EntryModel} from './entry.model';

export class DayModel {
    constructor(
        public day: DateTimeModel,
        public arrive: DateTimeModel,
        public leave: DateTimeModel,
        public inOffice: string,
        public outOfOffice: string,
        public logEntries: EntryModel[]) { }
}
