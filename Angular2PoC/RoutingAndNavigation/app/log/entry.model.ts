import {DateTimeModel} from './datetime.model';
//import {ActionDirection} from './actiondirection.model.ts';

export class EntryModel {

    constructor(public logEntryId: number, public name: string, public time: DateTimeModel, public direction: number) { }

    

    getTime() {
        return "11:11"
        //return ("0" + (this.date.getHours())).slice(-2) + ":" + ("0" + (this.date.getMinutes())).slice(-2);//+ ":" + ("0" + (this.date.getSeconds())).slice(-2);
    }
}




