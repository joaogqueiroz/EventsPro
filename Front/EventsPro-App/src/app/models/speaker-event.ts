import { BaseEntity } from "./base-entity";
import { Speaker } from "./speaker";

export interface SpeakerEvent extends BaseEntity {
    speakerId: number;
    speaker: Speaker | null;
    eventId: number;
    event: Event | null;
}