export class User {
    constructor(public UserId:number=1,
        public UserEnterance:string="",
        public UserPassword:string="",
        public UserFirstName:string="",
        public UserLastName:string="",
        public UserGmail:string="",
        public UserPhone:string="",
        public UsersCount:number=1, 
        public UserAccessLevel:number=4)
    {

    }
}
