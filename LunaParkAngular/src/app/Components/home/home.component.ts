import { Component, OnInit } from '@angular/core';
import { Attraction } from 'src/app/Classes/attraction';
import { AttractionService } from 'src/app/Services/attraction.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { Time, getLocaleTimeFormat, formatDate } from '@angular/common';
import { timeEnd } from 'console';
import { TIMEOUT } from 'dns';
import { DatePipe } from '@angular/common';
import { AttractionTicketService } from 'src/app/Services/attraction-ticket.service';
import { UserService } from 'src/app/Services/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

IsBasketNull:boolean=true;

selectedAtr: Attraction;

displayDialog: boolean;

constructor(private AttractionSer: AttractionService, private AttractionTicketSer:AttractionTicketService,
    private UserSer:UserService, private router:Router) { }

ngOnInit() {
this.AttractionSer.GetAllAttraction().subscribe(myData=>{this.AttractionSer.Attractions=myData;},myErr=>alert(myErr.message));
//  this.date = formatDate(new Date(), 'HH:MM',);

}


myFunction() {
  var popup = document.getElementById("myPopup");
  popup.classList.toggle("show");
}

BasketNull()
{
if(this.AttractionTicketSer.TicketsList.length==0)
this.IsBasketNull=!this.IsBasketNull
else
this.router.navigate(['/TicketsBasket']);
}

IsRate()
{
if(this.UserSer.u!=null)
this.router.navigate(['/Rate']);
}

}
