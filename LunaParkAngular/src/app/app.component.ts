import { Component } from '@angular/core';
import { Plugins } from 'protractor/built/plugins';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public title : string;

  constructor(){
    this.title = 'Rating stars using Angular';
  }

  public onRating(rating : number): void {
    console.log(rating);
  }
  
}
