import { BaseEntity } from "./base-entity";
import { Speaker } from "./speaker";

export interface SocialNetwork extends BaseEntity {
    name: string | null;
    url: string | null;
    eventId: number | null;
    event: Event | null;
    speakerId: number | null;
    speaker: Speaker | null;
}