import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import { EmployeeModel } from '../models/employee.model';
import { NgModule } from '@angular/core';

import {Input } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  allEmployees: Array<EmployeeModel> = [];
    displayedColumns: string[] = ['select', 'firstName', 'lastName', 'position', 'DOB'];
    user:any;
    event:any;
    model:any={};

    selectedEmployeeId!: any;

    constructor(private dataService: DataService) { }

    ngOnInit(): void {
        this.getAllEmployees();
    }

    getAllEmployees() {
        this.dataService.getAllEmployees().subscribe(employees => {
            this.allEmployees = employees;
            console.log(this.allEmployees);

        });
    }


    deleteEmployee(id:any) {

      this.selectedEmployeeId=id;
        if (window.confirm('Are you sure to delete employee record?')) {
            this.dataService.deleteEmployeeRecord(this.selectedEmployeeId).subscribe(response => {
                console.log(response);
                this.getAllEmployees();
            });
        }
    }

    updateEmployee(employee:EmployeeModel)
    {
      this.user=employee;
      console.log(this.user);




    }

    onSubmit(employee:EmployeeModel,event: { submitter: { name: string; }; })
    {
      if(event.submitter.name=="delete")
      {
        this.deleteEmployee(employee.firstName);
      }
      else if(event.submitter.name=="update")
      {
        console.log(employee);
        this.updateEmployee(employee);

      }
    }

    updateEmployeeRecord(user:EmployeeModel, updateForm:NgForm)
    {
      console.log("before updating");
      console.log(this.model);
      console.log(user);
      user.lastName=this.model.lastname;
      user.position=this.model.position;
      user.address=this.model.Address;
      user.gender=this.model.gender;
      user.DOB=this.model.dob;

      console.log(user);
      this.dataService.updateEmployee(user.firstName,user).subscribe(response => {
        console.log(response);
        this.getAllEmployees();
       // this.router.navigateByUrl('/Employee');
        //this.doneRegister.emit(register);
    });

    }

    /*deleteEmployee(id:any) {

      this.selectedEmployeeId=id;
        if (window.confirm('Are you sure to delete employee record?')) {
            this.dataService.deleteEmployeeRecord(this.selectedEmployeeId).subscribe(response => {
                console.log(response);
                this.getAllEmployees();
            });
        }
    }*/



    onEmployeeSelection(employeeId: string) {
        this.selectedEmployeeId = employeeId;
        console.log(this.selectedEmployeeId);
    }

}

