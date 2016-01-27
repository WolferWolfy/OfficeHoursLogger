import {Component, OnInit} from 'angular2/core';
import {EntryModel} from './entry.model';
import {OfficeHoursService} from './officehours.service';
import {Router, RouteParams} from 'angular2/router';

@Component({
    template: `
        <h2>ENTRY LIST COMPONENT</h2>
    <ul>
      <li *ngFor="#entry of entries"
        [class.selected]="isSelected(entry)"
        (click)="onSelect(entry)">
        <span class="badge">{{entry.id}}</span> {{entry.name}}
      </li>
    </ul>
<h3> entries2</h3>
<ul>
      <li *ngFor="#entry of entries2"
        [class.selected]="isSelected(entry)"
        (click)="onSelect(entry)">
        <span class="badge">{{entry.id}}</span> {{entry.name}}
      </li>
    </ul>

        `,
   providers: [OfficeHoursService]
})
export class EntryListComponent implements OnInit {

    entries = [
    new EntryModel(1, "Arrive"),
    new EntryModel(2, "Break start"),
    new EntryModel(3, "Break end"),
    new EntryModel(4, "Depart")
    ];

    entries2: EntryModel[];

    private _selectedEntryId: number;

    constructor(
        private _service: OfficeHoursService,
        private _router: Router,
        routeParams: RouteParams) {
        this._selectedEntryId = 5; //+routeParams.get('id');
    }

    isSelected(entryModel: EntryModel) { return entryModel.id === this._selectedEntryId; }

    ngOnInit() {
        //this._service.getEntries().then(entries => this.entries2 = entries);
       // this.entries2 = this._service.getSimpleEntries;
    }

    onSelect(entryModel: EntryModel) {
        this._router.navigate(['Entry', { id: entryModel.id }]);
    }
}