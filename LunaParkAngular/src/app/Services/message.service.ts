import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from '../Classes/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  MessageCountMan:number=1;

  BASEURL:string="http://localhost:50610/LunaPark/Message/"

  MessageList:Array<Message>;

  constructor(private http:HttpClient) { }

  GetAllMessages():Observable<Array<Message>>
  {
    return this.http.get<Array<Message>>(this.BASEURL+"GetAll");
  }

  AddMessage(m:Message):Observable<Array<Message>>
  {
    return this.http.post<Array<Message>>(this.BASEURL+"AddMessage",m);
  }

}
