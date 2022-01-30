import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Queues } from '../Classes/queues';
import { DateTimeParameters } from '../Classes/date-time-parameters';
import { UpdateMaxPeople } from 'src/TempClasses/update-max-people';

@Injectable({
  providedIn: 'root'
})
export class QueuesService {

  BASEURL:string="http://localhost:50610/LunaPark/Queues/"

  QueuesList:Array<Queues>;

  Queue:Queues

  constructor(private http:HttpClient) { }

  GetAllQueues():Observable<Array<Queues>>
  {
    return this.http.get<Array<Queues>>(this.BASEURL+"GetAll");
  }

  GetById(QueueId:number):Observable<Queues>
  {
    return this.http.get<Queues>(this.BASEURL+"GetById/"+QueueId)
  }

  GetQueuesByAttractionId(AttractionId:number):Observable<Array<Queues>>
  {
    return this.http.get<Array<Queues>>(this.BASEURL+"GetQueuesByAttractionId/"+AttractionId)
  }

  UpdateQueues(q:Queues):Observable<Array<Queues>>
  {
    return this.http.put<Array<Queues>>(this.BASEURL+"UpdateQueue/"+q.QueueId,q)
  }

  UpdateMaxPeople(TimeNow:Date,AttractionId:number,AttractionMaxPeople:number):Observable<Array<Queues>>
  {
    let max:UpdateMaxPeople=new UpdateMaxPeople(TimeNow,AttractionId,AttractionMaxPeople)
     return this.http.put<Array<Queues>>(this.BASEURL+"UpdateMaxPeopleFromCurrHour",max)
  }

  ResetQueues(open:Date,close:Date):Observable<Array<Queues>>
  {
    let Times:DateTimeParameters=new DateTimeParameters(open,close);
    return this.http.post<Array<Queues>>(this.BASEURL+"ResetQueues",Times)
  }

  

}
