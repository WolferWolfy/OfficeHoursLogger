import {DateTimeModel} from './datetime.model';
//import {ActionDirection} from './actiondirection.model.ts';

export class EntryModel {

    constructor(public id: number, public name: string, public datetime: DateTimeModel, public actionDirection: number) { }


    getTime() {
    return "11:11"
        //return ("0" + (this.date.getHours())).slice(-2) + ":" + ("0" + (this.date.getMinutes())).slice(-2);//+ ":" + ("0" + (this.date.getSeconds())).slice(-2);
    }
}

