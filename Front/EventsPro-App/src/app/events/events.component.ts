import { Component, OnInit, TemplateRef } from '@angular/core';
import {EventService} from './../Services/event.service';
import { Event } from "../models/event";
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

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
  modalRef?: BsModalRef;

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
  constructor(
    private EventService: EventService,
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService,
    ) {}

  public ngOnInit(): void {
    this.spinner.show();
    this.getEvents();

  }

  public showImage(): void {
    this.showImgState = !this.showImgState;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
 
  confirm(): void {
    this.modalRef?.hide();
    this.toastrService.success('Event deleted successfully', 'Deleted')
  }
 
  decline(): void {
    this.modalRef?.hide();
  }

  public getEvents(): void {
    this.EventService.getEvents().subscribe({
      next: (eventsResponse : Event[]) => {
        this.events = eventsResponse;
        console.log(this.events);
        this.filtredEvents = this.events;
      },
      error: (error: any) => {
        console.log(error);
        this.spinner.hide();
        this.toastrService.error('Error loading events','Error');
      },
      complete: () => {
        this.spinner.hide();
      }
    });
  }
}
