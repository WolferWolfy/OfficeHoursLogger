
export class EntryModel {

    constructor(public id: number, public name: string, public date: Date) { }


    getTime() {
        return ("0" + (this.date.getHours())).slice(-2) + ":" + ("0" + (this.date.getMinutes())).slice(-2);//+ ":" + ("0" + (this.date.getSeconds())).slice(-2);
    }
}

