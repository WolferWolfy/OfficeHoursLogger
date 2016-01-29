import {Component, OnInit}  from 'angular2/core';
import {OfficeHoursService}   from './officehours.service';
import {EntryModel} from './entry.model';
import {RouteParams, Router} from 'angular2/router';

@Component({
    template: `
  <h2>ENTRY</h2>
  <div *ngIf="entry">
    <h3>"{{entry.name}}"</h3>
    <div>
      <label>Id: </label>{{entry.id}}</div>
    <div>
      <label>Name: </label>
      <input [(ngModel)]="entry.name" placeholder="name"/>
    </div>
    <button (click)="gotoEntries()">Back - day id needed</button>
  </div>
  `,
})
export class EntryDetailComponent implements OnInit {
    entry: EntryModel;

    constructor(
        private _router: Router,
        private _routeParams: RouteParams,
        private _service: OfficeHoursService) { }

    ngOnInit() {
        let id = this._routeParams.get('id');
        this._service.getEntry(id).then(hero => this.entry = hero);
    }

    gotoEntries() {
        let entryId = this.entry ? this.entry.id : null;
        // Pass along the hero id if available
        // so that the HeroList component can select that hero.
        // Add a totally useless `foo` parameter for kicks.
        this._router.navigate(['Entries', { id: entryId }]);//, day: this.entry.date }]);
    }
}


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/