import { environment } from '../environments/environment';
import { EmployeeModel } from './models/employee.model';

export const ApiRoutes = {
    GetAllEmployees: 'https://localhost:44354/api/Employee',
    DeleteEmployee:  'https://localhost:44354/api/Employee/{Name}',
    CreateEmployeeRecord: 'https://localhost:44354/api/Employee',
    GetEmployeeByName: 'https://localhost:44354/api/Employee/FirstName?name={Name}',
    UpdateEmployee: 'https://localhost:44354/api/Employee/{Name}',
};
