import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employeeName: string = '';
  dateIn!: Date;
  dateOut!: Date;
  employees: Employee[] = [];
  managersList: any[] = [];
  managerName: string = '';
  constructor(private employeesServices: EmployeesService) { }

  ngOnInit(): void {
    this.employeesServices.getEmployees('','','','')
    .subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error: (response) => {
        console.log(response);
      }
      
    })
    this.employeesServices.getManagers()
    .subscribe({
      next: (managersList) => {
        this.managersList = managersList;
      },
      error: (response) => {
        console.log(response);
      }

    })

  }
  findWithParams()
  {
    let dateInQuery = '';
    let dateOutQuery = '';
    if(this.managerName === '--select--')
      this.managerName=''
    if(this.dateIn)
      dateInQuery = this.dateIn.toString() 
    
    if(this.dateOut)
      dateOutQuery = this.dateOut.toString() 
    
    this.employeesServices.getEmployees(this.employeeName, dateInQuery, dateOutQuery, this.managerName)
    .subscribe({
      next: (employees) => {
        this.employees = employees;
      },
      error: (response) => {
        console.log(response);
      }
      
    })
  }

}
