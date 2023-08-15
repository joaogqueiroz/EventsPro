import { BaseEntity } from "./base-entity";
import { Batch } from "./batch";
import { SocialNetwork } from "./social-network";
import { SpeakerEvent } from "./speaker-event";

export interface Event extends BaseEntity {
    place: string | null;
    eventDate: Date | null;
    theme: string | null;
    totalPeople: number;
    ticketLot: string | null;
    urlImage: string | null;
    phone: string | null;
    email: string | null;
    batches: Batch[] | null;
    socialNetworks: SocialNetwork[] | null;
    speakersEvents: SpeakerEvent[] | null;
}