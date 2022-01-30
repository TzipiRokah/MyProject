export class Message {
    constructor(public MessageId:number,
        public MessageDateTime:Date,
        public MessageDetails:string,
        public EmployeeId:number,
        public AttractionId:number,
        public UserId:number,
        public AccessLevelId:number)
    {}
}
