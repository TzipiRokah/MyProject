import { Queues } from "./queues";

export class AttractionTicket {
    constructor(public AttractionId:number, public AttractionName:string,public Hour:Date, public Amount:number,
        public AttractionCost:number, public CostAll:number, public Queue:Queues)
    {}
}
