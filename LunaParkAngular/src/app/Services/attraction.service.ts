import { Injectable } from '@angular/core';
import { Attraction } from '../Classes/attraction';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { formatDate } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class AttractionService {

  BASEURL:string="http://localhost:50610/LunaPark/Attraction/"
  
  ClosingdHour:number=19;
  a:Attraction=null;
  Attractions:Array<Attraction>;
  Route:Array<Attraction>=[];
  
  constructor(private http:HttpClient) { }

  GetAllAttraction():Observable<Array<Attraction>>
  {
    return this.http.get<Array<Attraction>>(this.BASEURL+"GetAll");
  }

  GetAttractionById(id:number):Observable<Attraction>
  {
    return this.http.get<Attraction>(this.BASEURL+"GetById/"+id);
  }
  
  UpdateAttraction(id:number,a:Attraction):Observable<Array<Attraction>>
  {
    debugger
    return this.http.put<Array<Attraction>>(this.BASEURL+"UpdateAttraction/"+id,a);
  }

  //פונקציה המקבלת אטרקציה ומחזירה זמן משוער להמתנה
  GetWaitTimePerAttraction(a:Attraction)
  {
      let time:number= a.AttractionCountQueue / a.AttractionMaxPeople * (a.AttractionTime + a.AttractionTimeOUt);
      return time; 
  }

  //פונקציה המקבלת רשימת אטרקציות ומחזירה את הרשימה ממוינת על פי הדרוג
  GetQuickWayByRate()
  {
    debugger
    let t=formatDate(Date.now(), 'hh','en-US');
    let b=formatDate(Date.now(), 'mm ','en-US');
    let s=formatDate(Date.now(), 'a', 'en-US');
    let a
    if(s=="PM")
    a=(parseInt(t)+12)*60+parseInt(b)
    else
    a=parseInt(t)*60+parseInt(b)
      let i:number, sumTime:number = 0;
      for (i = 0; i < this.Route.length; i++)
      {
        this.Route[i].TimeWait = this.GetWaitTimePerAttraction(this.Route[i]);
        if (this.ClosingdHour*60-a > sumTime+this.Route[i].TimeWait)
            sumTime += this.Route[i].TimeWait;
        else
            this.Route.splice(i);
      }      
  }
}
