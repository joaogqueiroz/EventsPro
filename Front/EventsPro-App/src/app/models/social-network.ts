import { BaseEntity } from "./base-entity";

export interface SocialNetwork extends BaseEntity {
    name: string;
    url: string;
    eventId: number;
    speakerId: number;
}