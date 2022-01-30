import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UpdateMaxPeople } from 'src/TempClasses/update-max-people';
import { Attraction } from '../Classes/attraction';
import { CorrectQueue } from '../Classes/correct-queue';
import { QueuePerUser } from '../Classes/queue-per-user';

@Injectable({
  providedIn: 'root'
})
export class QueuePerUserService {

  BASEURL:string="http://localhost:50610/LunaPark/QueuePerUser/"

  QueuePerUserList:Array<QueuePerUser>

  constructor(private http:HttpClient) { }

  GetByUserId(UserId:number):Observable<Array<QueuePerUser>>
  {
    return this.http.get<Array<QueuePerUser>>(this.BASEURL+"GetByUserId/"+UserId);
  }

  GetCorrectQueue(queue:CorrectQueue):Observable<Attraction>
  {
    return this.http.put<Attraction>(this.BASEURL+"GetCorrectQueue",queue);
  }

  AddQueuePerUser(queuePerUser:QueuePerUser):Observable<Array<QueuePerUser>>
  {
    return this.http.post<Array<QueuePerUser>>(this.BASEURL+"AddQueuePerUser",queuePerUser);
  }

  DelayQueue(u:UpdateMaxPeople):Observable<Array<QueuePerUser>>
  {
    return this.http.put<Array<QueuePerUser>>(this.BASEURL+"DelayQueue",u);
  }

  MalfunctionQueues(u:UpdateMaxPeople):Observable<Array<QueuePerUser>>
  {
    return this.http.put<Array<QueuePerUser>>(this.BASEURL+"MalfunctionQueues",u);
  }
}
