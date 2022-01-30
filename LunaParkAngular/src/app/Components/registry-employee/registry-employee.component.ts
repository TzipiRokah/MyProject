import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/Classes/employee';
import { User } from 'src/app/Classes/user';
import { EmployeeService } from 'src/app/Services/employee.service';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-registry-employee',
  templateUrl: './registry-employee.component.html',
  styleUrls: ['./registry-employee.component.css']
})
export class RegistryEmployeeComponent implements OnInit {

  newUser:User=new User();

  AccessLevel:string;

  Details:string;

  check:boolean=false;

  constructor(private UserSer:UserService, private EmployeeSer:EmployeeService) { }

  ngOnInit() {
  }

  Connect()
  {
    if(this.AccessLevel=="מנהל")
    this.newUser.UserAccessLevel=1
    else
    if(this.AccessLevel=="סדרן")
    this.newUser.UserAccessLevel=2
    else
    if(this.AccessLevel=="מפעיל מתקן")
    this.newUser.UserAccessLevel=3
    else
    if(this.AccessLevel=="לקוח")
    this.newUser.UserAccessLevel=4

    if(this.newUser.UserAccessLevel==1 || this.newUser.UserAccessLevel==2 || this.newUser.UserAccessLevel==3)
    {
      let e:Employee=new Employee(1,this.newUser.UserAccessLevel,this.Details);
      this.EmployeeSer.AddEmployee(e).subscribe(myData=>this.EmployeeSer.EmployeeList=myData,myErr=>alert(myErr.message));
    }

    this.UserSer.AddUser(this.newUser).subscribe(myData=>{this.UserSer.UserList=myData; this.check=true},myErr=>alert(myErr.message));
  }
}
