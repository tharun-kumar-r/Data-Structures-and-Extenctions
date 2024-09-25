import { Injectable } from "@angular/core";
import { employee } from "../models/employee.model";
import { map, Observable, of } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";


@Injectable({
    providedIn: 'root',
    
})

export class EmployeeService
{


    private url = "http://localhost:3000/employees";

    constructor(private _hhtp: HttpClient){}

    /* private employee: employee[] = [
        {Id:1, FName: "Tharun", LName: "Kumar", Age:24, Country:"India", Gender:"Male", Salary:100000},
        {Id:2, FName: "Amulya", LName: "M", Age:21, Country:"USA", Gender:"Female", Salary:20000},
        {Id:3, FName: "Suman", LName: "Raj", Age:23, Country:"China", Gender:"Male", Salary:30000}
    ] */ 


    GetEmployee(): Observable<employee[]>{
        return this._hhtp.get<employee[]>(this.url);
    }



      GetEmployeeById(id: number): Observable<employee | any> {
        return this.GetEmployee().pipe(
          map(employees => employees.find(e => e.Id === id)) 
        )};

    saveEmployee(employeeData: employee): Observable<employee> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this._hhtp.post<employee>(this.url, employeeData, { headers });
      }

}
