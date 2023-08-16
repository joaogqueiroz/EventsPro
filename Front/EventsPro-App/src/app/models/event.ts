import { BaseEntity } from "./base-entity";
import { Batch } from "./batch";
import { SocialNetwork } from "./social-network";
import { Speaker } from "./speaker";

export interface Event extends BaseEntity {
    place: string;
    eventDate: Date;
    theme: string;
    totalPeople: number;
    urlImage: string;
    phone: string;
    email: string;
    batches: Batch[];
    socialNetworks: SocialNetwork[];
    speakersEvents: Speaker[];
}