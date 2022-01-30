import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { Attraction } from 'src/app/Classes/attraction';
import { AttractionTicket } from 'src/app/Classes/attraction-ticket';
import { AttractionTicketService } from 'src/app/Services/attraction-ticket.service';
import { UserService } from 'src/app/Services/user.service';
import { QueuesService } from 'src/app/Services/queues.service';
import { Queues } from 'src/app/Classes/queues';
import { QueuePerUserService } from 'src/app/Services/queue-per-user.service';
import { CorrectQueue } from 'src/app/Classes/correct-queue';


@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})
export class TicketsComponent implements OnInit {

  selectedAtr: Attraction;

  displayDialog: boolean;

  NoUser:boolean=false

  AttractionName:string
  Time:Date
  CountTickets:number
  IsView:boolean

  constructor(private AttractionSer:AttractionService,private AttractionTicketSer:AttractionTicketService,
              private UserSer:UserService, private QueuesSer:QueuesService, private QueuePerUserSer:QueuePerUserService) { }


  ngOnInit() {
    this.IsView=null
  }

  SelectedAtr(event: Event, selectedAtr: Attraction) {
    if(this.UserSer.u==null)
    this.NoUser=true;
    else
    {
    this.selectedAtr = selectedAtr;
    this.displayDialog = true;
    event.preventDefault();
    this.GetQueuesPerAttraction(selectedAtr.AttractionId)
    }
  }

  onDialogHide() {
    this.selectedAtr = null;
  }

  GetQueuesPerAttraction(id:number)
  {
    this.QueuesSer.GetQueuesByAttractionId(id).subscribe(myData=>{this.QueuesSer.QueuesList=myData},myErr=>alert(myErr.message()))
  }

  ViewAttractionInModal(a:Attraction)
  {
    this.AttractionName=a.AttractionName
    
    this.CountTickets=1
  }

  AddToBasket(q:Queues)
  {
    debugger
    this.Time=q.Hour
    let a:Attraction=this.AttractionSer.Attractions.find(x=>x.AttractionId==q.AttractionId);
    let queue:CorrectQueue=new CorrectQueue(this.UserSer.u.UserId,a.AttractionId,q.Hour);
    this.QueuePerUserSer.GetCorrectQueue(queue).subscribe(
      myData=>{this.AttractionSer.a=myData; 
      if(this.AttractionSer.a!=null) 
      {
        this.IsView=true
        this.ChangeQueue(this.AttractionSer.a); 
      }
      else 
      {
        this.IsView=false
        this.ViewAttractionInModal(a);
      }},
      myErr=>alert(myErr.message));
    let ticket:AttractionTicket=new AttractionTicket(a.AttractionId,a.AttractionName,q.Hour,1,a.AttractionCost,a.AttractionCost,q);
    let x:number;
    // for(x=0;x<this.AttractionTicketSer.TicketsList.length && this.AttractionTicketSer.TicketsList[x].AttractionId!=q.AttractionId;x++);
    // if(this.AttractionTicketSer.TicketsList.length==x)
    // {
      this.AttractionTicketSer.TicketsList.push(ticket);
      this.AttractionTicketSer.SumCostTicket+=ticket.CostAll;
    // }
  }

  ChangeQueue(a:Attraction)
  {
    this.ViewAttractionInModal(a)
  }
}
