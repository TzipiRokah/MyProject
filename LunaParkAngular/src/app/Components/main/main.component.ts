import { Component, OnInit } from '@angular/core';
import { AttractionService } from 'src/app/Services/attraction.service';
import { AttractionTicketService } from 'src/app/Services/attraction-ticket.service';
import { Attraction } from 'src/app/Classes/attraction';
import { Time } from '@angular/common';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {

  selectedAtr: Attraction;

  displayDialog: boolean;

  date:any;

  time:Date;

  constructor(private AttractionSer: AttractionService, private AttractionTicketSer:AttractionTicketService) { }

  ngOnInit() {
    this.date=Date.now()
    this.time=new Date()
  }

  SelectedAtr(event: Event, selectedAtr: Attraction) {
    this.selectedAtr = selectedAtr;
    this.displayDialog = true;
    event.preventDefault();
  }

onDialogHide() {
    this.selectedAtr = null;
}

}
