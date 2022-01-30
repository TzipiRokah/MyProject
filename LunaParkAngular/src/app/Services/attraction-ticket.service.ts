import { Injectable } from '@angular/core';
import { AttractionTicket } from '../Classes/attraction-ticket';

@Injectable({
  providedIn: 'root'
})
export class AttractionTicketService {

  constructor() { }
  TicketsList:Array<AttractionTicket>=[];
  IsBasketNull:boolean=false;

  SumCostTicket:number=0;
  
  UpdateAmount(i:number,cost:number,amount:number)
  {
    this.SumCostTicket-=this.TicketsList[i].CostAll;
    this.TicketsList[i].CostAll=cost*amount;
    this.SumCostTicket+=this.TicketsList[i].CostAll;
    this.TicketsList[i].Amount=amount;
  }

  DeleteTicket(i:number, count:number)
  {
    let x:number;
    for(x=i;x<count;x++)
    {
      this.SumCostTicket-=this.TicketsList[x].CostAll;
    }
    this.TicketsList.splice(i,count);   
  }

}
