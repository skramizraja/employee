import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'StudentData';
  users: any;
  model:any={}

   constructor() {}
       
      ngOnInit()
      {
        //this.getUsers();
      }
   

   /* getUsers() {
      this.http.get("https://localhost:44354/api/Employee").subscribe(response=>{
        this.users=response;
      }, error=>{
        console.log(error);
      })

    }*/

    register()
    {
      console.log(this.model);
    }
  }

