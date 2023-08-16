import { BaseEntity } from "./base-entity";
import { Event } from "./event";

export interface Batch extends BaseEntity {
    name: string;
    price: number;
    startDate?: Date;
    finishDate?: Date;
    amount: number;
    eventId: number;
    event: Event;
}