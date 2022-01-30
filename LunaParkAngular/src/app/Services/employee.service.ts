import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Classes/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  BASEURL:string="http://localhost:50610/LunaPark/Employee/"

  EmployeeList:Array<Employee>

  constructor(private http:HttpClient) { }

  GetAllQueues():Observable<Array<Employee>>
  {
    return this.http.get<Array<Employee>>(this.BASEURL+"GetAll");
  }

  AddEmployee(e:Employee):Observable<Array<Employee>>
  {
    debugger
    return this.http.post<Array<Employee>>(this.BASEURL+"AddEmployee",e);
  }
}
