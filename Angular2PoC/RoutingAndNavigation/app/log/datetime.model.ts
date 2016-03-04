export class DateTimeModel {

    constructor(public year: number, public month: number, public day: number,
        public hour: number, public minute: number, public second: number) { }

        //wont work when read from json.
    getTime() {
        return "11:11"
        //return ("0" + (this.date.getHours())).slice(-2) + ":" + ("0" + (this.date.getMinutes())).slice(-2);//+ ":" + ("0" + (this.date.getSeconds())).slice(-2);
    }
}

