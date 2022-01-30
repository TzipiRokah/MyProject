import { Time } from "@angular/common";

export class AttractionStatus {
    constructor(public AttractionStatusId:number,
        public StatusId:number,
        public AttractionId:number,
        public AttractionStatusDateTime:Date,
        public EmployeeReportId:number)
    {}
}
