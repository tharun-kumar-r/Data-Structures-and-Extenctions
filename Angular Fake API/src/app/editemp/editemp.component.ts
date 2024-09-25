import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../Services/employee.services';
import { employee } from '../models/employee.model';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-editemp',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './editemp.component.html'
})
export class EditEmpComponent implements OnInit {

  private id!: number;
  employee!: employee;  // Single employee object
  employeeForm!: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private employeeService: EmployeeService, 
    private route: ActivatedRoute
  ) {
    this.id = Number(this.route.snapshot.paramMap.get('id'));  // Get employee id from route params
  }

  ngOnInit(): void {
    this.employeeService.GetEmployeeById(this.id).subscribe(data => {
      this.employee = data;  // Assign the fetched employee

      // Initialize the form after employee data is fetched
      this.employeeForm = this.fb.group({
        Id: [this.employee.Id],
        FName: [this.employee.FName, [Validators.required, Validators.minLength(2)]],
        LName: [this.employee.LName, [Validators.required, Validators.minLength(2)]],
        Age: [this.employee.Age, [Validators.required, Validators.min(18), Validators.max(100)]],
        Salary: [this.employee.Salary, [Validators.required, Validators.min(10000)]],
        Gender: [this.employee.Gender, Validators.required],
        Country: [this.employee.Country, Validators.required]
      });
    });
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const updatedEmployee: employee = this.employeeForm.value;

      // Save the updated employee
      this.employeeService.saveEmployee(updatedEmployee).subscribe(
        response => {
          console.log('Employee saved successfully!', response);
        },
        error => {
          console.error('Error saving employee!', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }
}
