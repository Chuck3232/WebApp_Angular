import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getEmployees(employeeName: string, dateAfter: string, dateBefore:string, managerName: string): Observable<Employee[]> {
    let queryParams = new HttpParams();
    queryParams = queryParams.append('employeeName', employeeName)
    queryParams = queryParams.append('dateAfter', dateAfter)
    queryParams = queryParams.append('dateBefore', dateBefore)
    queryParams = queryParams.append('managerName', managerName)
    return this.http.get<Employee[]>(this.baseApiUrl + '/Api/Employee', {params:queryParams})
  }
  getManagers(): Observable<any[]> {    
    return this.http.get<Employee[]>(this.baseApiUrl + '/Api/Employee/PerformanceManager')
  }
}
