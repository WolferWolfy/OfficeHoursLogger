import {Component, OnInit} from 'angular2/core';
import {NgClass} from 'angular2/common';
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
        <span class= {{getDirection(entry)}} >{{getTime(entry)}}</span> {{entry.name}} - {{entry.direction}}
      </li>
    </ul>
        `,
    providers: [OfficeHoursService],
   directives: [NgClass]
})

// <span class="badge" > {{getTime(entry) }}</span> {{entry.name}} - {{entry.actionDirection}}

export class EntryListComponent implements OnInit {

    entries: EntryModel[];

    isOn = true;
    isDisabled = false;
    private _selectedEntryId: number;

    constructor(
        private _service: OfficeHoursService,
        private _router: Router,
        routeParams: RouteParams) {
        this._selectedEntryId = +routeParams.get('entryId');

    }

    isSelected(entryModel: EntryModel) { return entryModel.logEntryId === this._selectedEntryId; }

    ngOnInit() {
      //based on selectedEntryId we should fetch that day's entries.
        if (this._selectedEntryId) {
           // this._service.getEntriesForDayFromEntryId(this._selectedEntryId).then(entries => this.entries = entries);
            this._service.getEntries().subscribe(
                entries => this.entries = entries,
                error => alert(error));
        }
        else {//fetch default entries
         //   this._service.getEntries().then(entries => this.entries = entries);

            this._service.getEntries().subscribe(
                entries => this.entries = entries,
                error => alert(error));   
        }

        
       // this.entries = this._service.getEntries2();
    }

    getTime(entryVM: EntryModel) {
        return ("0" + (entryVM.time.hour)).slice(-2) + ":" + ("0" + (entryVM.time.minute)).slice(-2) + ":" + ("0" + (entryVM.time.second)).slice(-2);
    }
    
    getDirection(entryVM : EntryModel) {
        return "badge" + ( entryVM.direction ? "Exit" : "Enter");
    }


    onSelect(entryModel: EntryModel) {
        // will crash when data is read from json.
     //   console.debug(this.entries[0].getTime());
        this._router.navigate(['Entry', { id: entryModel.logEntryId }]);
    }
}