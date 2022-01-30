import { Time } from "@angular/common";

export class Attraction {
    constructor(public AttractionId:number, 
        public AttractionName:string, 
        public AttractionIfActive:number,
        public AttractionMaxPeople:number, 
        public AttractionNowPeople:number, 
        public AttractionCountQueue:number,
        public AttractionTime:number, 
        public AttractionTimeOUt:number, 
        public AttractionLastAction:Time,
        public AttractionCost:number, 
        public TimeWait:number)
    {}
}
