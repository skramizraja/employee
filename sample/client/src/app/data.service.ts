import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiRoutes } from './api.routes';
import { Observable } from 'rxjs';
import { EmployeeModel } from './models/employee.model';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(private httpClient: HttpClient) { }

    getAllEmployees(): Observable<Array<EmployeeModel>> {
        return this.httpClient.get<Array<EmployeeModel>>(ApiRoutes.GetAllEmployees);
    }





   createEmployeeRecord(newEmployeeRecord: EmployeeModel) {
        //return this.httpClient.post(ApiRoutes.CreateEmployeeRecord, newEmployeeRecord);
        const body=newEmployeeRecord;
        //console.log(body)
    return this.httpClient.post(ApiRoutes.CreateEmployeeRecord, body)
    }



    deleteEmployeeRecord(employeeId: string) {
        const url = ApiRoutes.DeleteEmployee.replace(`{Name}`, employeeId);
        return this.httpClient.delete(url);
    }

    getEmployeeByName(name:string):Observable<EmployeeModel>
    {
      const url= ApiRoutes.GetEmployeeByName.replace('{Name}', name );
      return this.httpClient.get<EmployeeModel>(url);
    }

    updateEmployee(name:any, employee:EmployeeModel)
    {
      const url = ApiRoutes.UpdateEmployee.replace(`{Name}`, name);
        return this.httpClient.put(url,employee);
    }

}
