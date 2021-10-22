import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { EmployeeModel } from '../models/employee.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 registerMode=false;
 users: any;
 firstname:any;
 name : any;
  constructor(private http:HttpClient,private dataService:DataService) { }

  ngOnInit(): void {
   // this.getUsers();
  }

  registerToggle()
  {
    this.registerMode=!this.registerMode;
  }

//  getUsers(){
//    this.http.get('https://localhost:44354/api/Employee').subscribe(users=>this.users=users);
//  }

 searchEmployee(firstname:any)
 {
   let searched: boolean;
   searched=false;
   //this.name=firstname;
   console.log(firstname);
   this.dataService.getEmployeeByName(firstname).subscribe(employees=>
    {
      this.users=employees;
      console.log(this.users);
      console.log(this.users._id.pid);
      if(this.users!=null)
        searched=true;
    })
 }

 /*getAllEmployees() {
  this.dataService.getAllEmployees().subscribe(employees => {
      this.allEmployees = employees;
      console.log(this.allEmployees);

  });
}*/




  cancelRegisterMode(event:boolean){
    this.registerMode=event;
  }
}
