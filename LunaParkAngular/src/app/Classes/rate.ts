import { Time } from "@angular/common";

export class Rate {
    constructor(public RateId:number,
        public AttractionId:number,
        public UserId:number,
        public RateDateTime:Date,
        public RateLevel:number)
    {}
}
