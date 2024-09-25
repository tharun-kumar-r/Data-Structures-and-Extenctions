import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { employee } from '../models/employee.model';
import { EmployeeService } from '../Services/employee.services';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employeelist',
  standalone: true,
  imports: [RouterModule, CommonModule, HttpClient],
  templateUrl: './employeelist.component.html',
  styleUrl: './employeelist.component.css'
})
export class EmployeelistComponent {

employee: employee[] = [];

constructor(private _empser: EmployeeService){}

ngOnInit(): void {
 this.load();  
}

load()
{
  this._empser.GetEmployee().subscribe(data => {
    this.employee = data;
  });
}

}
 