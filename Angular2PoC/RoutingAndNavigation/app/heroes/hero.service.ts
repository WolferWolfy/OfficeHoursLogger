import {Injectable} from 'angular2/core';
import {Http}       from 'angular2/http';
import {Observable} from 'rxjs/Observable';

export class Hero {
    constructor(public id: number, public name: string) { }
}

@Injectable()
export class HeroService {
    constructor(private http: Http) { }

    private _heroesUrl = 'app/json/heroes.json';

    getHeroes() {
        return this.http.get(this._heroesUrl)
            .map(res => <Hero[]>res.json().data)
            .catch(this.logAndPassOn);
    }

    private logAndPassOn(error: Error) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error);
    }

    addHero(name: string): Observable<Hero> {
        return this.http.post(this._heroesUrl, JSON.stringify({ name }))
            .map(res => <Hero>res.json().data)
            .catch(this.logAndPassOn)
    }

 /*   getHero(id: number | string) {
        return heroesPromise
            .then(heroes => heroes.filter(h => h.id === +id)[0]);
    }*/
}
