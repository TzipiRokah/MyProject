import { Time } from "@angular/common";

export class Queues {
    constructor(public QueueId:number, 
        public AttractionId:number, 
        public Hour:Date,
        public MaxPeopleInAttraction:number)
    {

    }
}
