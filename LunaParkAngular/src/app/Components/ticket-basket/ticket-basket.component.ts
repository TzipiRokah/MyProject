import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { AttractionTicketService } from 'src/app/Services/attraction-ticket.service';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';
import { QueuesService } from 'src/app/Services/queues.service';
import { QueuePerUser } from 'src/app/Classes/queue-per-user';
import { QueuePerUserService } from 'src/app/Services/queue-per-user.service';
import { Attraction } from 'src/app/Classes/attraction';
import { AttractionTicket } from 'src/app/Classes/attraction-ticket';

@Component({
  selector: 'app-ticket-basket',
  templateUrl: './ticket-basket.component.html',
  styleUrls: ['./ticket-basket.component.css']
})
export class TicketBasketComponent implements OnInit {

  amount:number=1;
  constructor(private AttractionSer:AttractionService, private AttractionTicketSer:AttractionTicketService,
              private router:Router, private UserSer:UserService, private QueuesSer:QueuesService, private QueuePerUserSer:QueuePerUserService) { }

  ngOnInit() {
    this.UserSer.IfUserIsNull();
  }

  UpdateAmount(index:number,cost:number,amount:number)
  {
    this.AttractionTicketSer.UpdateAmount(index,cost,amount);
  }
  DeleteItem(index:number,count:number)
  {
    this.AttractionTicketSer.DeleteTicket(index,count);
    if(this.AttractionTicketSer.TicketsList.length==0)
    this.router.navigate(['/']);
  }

  BuyTickets()
  {
    let i:number
    for(i=0;i<this.AttractionTicketSer.TicketsList.length;i++)
    {//עדכון מספר הכרטיסים הנותרים לשעה הזו
      this.AttractionTicketSer.TicketsList[i].Queue.MaxPeopleInAttraction-=this.AttractionTicketSer.TicketsList[i].Amount;
      this.QueuesSer.UpdateQueues(this.AttractionTicketSer.TicketsList[i].Queue).subscribe(myData=>this.QueuesSer.QueuesList=myData,myErr=>alert(myErr.mwssage));
      //יצירת אובייקט QueuePerUser
      let q:QueuePerUser=new QueuePerUser
      (1,this.AttractionTicketSer.TicketsList[i].Queue.QueueId,this.UserSer.u.UserId,this.AttractionTicketSer.TicketsList[i].Amount)
      //הוספת QueuePerUser למסד הנתונים
      this.QueuePerUserSer.AddQueuePerUser(q).subscribe(myData=>this.QueuePerUserSer.QueuePerUserList=myData,myErr=>alert(myErr.message))
    }
    //מחיקת הכרטיס מהסל
    this.DeleteItem(0,i);
  }
}
