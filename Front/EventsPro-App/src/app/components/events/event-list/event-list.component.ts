import { Component, OnInit, TemplateRef } from '@angular/core';
import {EventService} from '../../../Services/event.service';
import { Event } from "../../../models/event";
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {
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
    private router: Router
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
  
  eventsDetail(id: number): void {
    this.router.navigate([`events/detail/${id}`])
  }

  public getEvents(): void {
    this.EventService.getEvents().subscribe({
      next: (eventsResponse : Event[]) => {
        this.events = eventsResponse;
        this.filtredEvents = this.events;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastrService.error('Error loading events','Error');
      },
      complete: () => {
        this.spinner.hide();
      }
    });
  }
}
