import { BaseEntity } from "./base-entity";
import { SocialNetwork } from "./social-network";
import { SpeakerEvent } from "./speaker-event";

export interface Speaker extends BaseEntity {
    name: string;
    description: string;
    imageURL: string;
    phone: string;
    email: string;
    socialNetworks: SocialNetwork[] | null;
    speakersEvents: SpeakerEvent[] | null;
}