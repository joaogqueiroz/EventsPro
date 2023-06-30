import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any = [];
  public filtredEvents: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImgState: boolean = true;
  private _filterList: string = '';

  public get filterList(): string {
    return this._filterList;
  }
  public set filterList(value: string) {
    this._filterList = value;
    this.filtredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  filterEvents(filterListBy: string): any {
    filterListBy = filterListBy.toLowerCase();
    return this.events.filter(
      (event: { place: any; theme: string }) =>
        event.theme.toLowerCase().indexOf(filterListBy) !== -1 ||
        event.place.toLowerCase().indexOf(filterListBy) !== -1
    );
  }
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEvents();
  }

  showImage() {
    this.showImgState = !this.showImgState;
  }

  public getEvents(): void {
    this.http.get('https://localhost:5001/api/events').subscribe(
      (response) => {
        this.events = response;
        this.filtredEvents = response;
      },
      (error) => console.log(error)
    );
  }
}
