import { Component, OnInit } from '@angular/core';
import {EventService} from './../Services/event.service';
import { Event } from "../models/event";

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: Event[] = [];
  public filtredEvents: Event[] = [];
  widthImg = 150;
  marginImg = 2;
  showImgState = true;
  private filteredList: string = '';

  public get filterList(): string {
    return this.filteredList;
  }
  public set filterList(value: string) {
    this.filteredList = value;
    this.filtredEvents = this.filterList
      ? this.filterEvents(this.filterList)
      : this.events;
  }

  public filterEvents(filterListBy: string): Event[] {
    filterListBy = filterListBy.toLowerCase();
    return this.events.filter(
      event =>
        event.theme?.toLowerCase().indexOf(filterListBy) !== -1 ||
        event.place?.toLowerCase().indexOf(filterListBy) !== -1
    );
  }
  constructor(private EventService: EventService) {}

  public ngOnInit(): void {
    this.getEvents();
  }

  public showImage(): void {
    this.showImgState = !this.showImgState;
  }

  public getEvents(): void {
    this.EventService.getEvents().subscribe(
      (eventsResponse : Event[]) => {
        this.events = eventsResponse;
        console.log(this.events);
        this.filtredEvents = this.events;
      },
      (error) => console.log(error)
    );
  }
}
