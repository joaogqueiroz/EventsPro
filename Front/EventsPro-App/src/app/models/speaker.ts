import { BaseEntity } from "./base-entity";
import { SocialNetwork } from "./social-network";
import { Event } from "./event";

export interface Speaker extends BaseEntity {
    name: string;
    description: string;
    imageURL: string;
    phone: string;
    email: string;
    socialNetworks: SocialNetwork[];
    speakersEvents: Event[];
}