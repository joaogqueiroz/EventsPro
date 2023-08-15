import { BaseEntity } from "./base-entity";
import { Event } from "./event";

export interface Batch extends BaseEntity {
    name: string | null;
    price: number;
    startDate: Date | null;
    finishDate: Date | null;
    amount: number;
    eventId: number;
    event: Event | null;
}