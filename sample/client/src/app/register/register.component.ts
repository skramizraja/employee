import { Component, Input, OnInit, Output } from '@angular/core';
import {EventEmitter} from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { EmployeeModel } from '../models/employee.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  newEmployee: EmployeeModel=new EmployeeModel();

  @Input() usersFromHomeComponent:any;
  @Output() doneRegister=new EventEmitter();
  model:any={};
  constructor(private dataService: DataService,
    private router: Router) {  }

  ngOnInit(): void {
  }

  createEmployeeRecord(registerForm:NgForm){
    console.log(this.model)
    let register:boolean;
    if(registerForm.invalid)
    {
      register=false;
      return;
    }

    register=true;
    this.dataService.createEmployeeRecord(this.model).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('/Employee');
      this.doneRegister.emit(register);
  });


    }
  }


