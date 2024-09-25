import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { EmployeeService } from '../Services/employee.services';
import { employee } from '../models/employee.model';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-createemp',
  standalone: true,
  imports: [RouterModule, FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './createemp.component.html'
 
})
export class CreateempComponent {
  randomNumber: number | null = null;

  
  
   

  employeeForm!: FormGroup;
  constructor(private fb: FormBuilder, private employeeService: EmployeeService) {

    this.randomNumber = Math.floor(Math.random() * 101);

  }

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      Id:[this.randomNumber],
      FName: ['', [Validators.required, Validators.minLength(2)]],
    
      LName: ['', [Validators.required, Validators.minLength(2)]],
      Age: ['', [Validators.required, Validators.min(18), Validators.max(65)]],
      Salary: ['', [Validators.required, Validators.min(10000)]],
      Gender: ['', Validators.required],
      Country: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      const newEmployee: employee = this.employeeForm.value;

     
      this.employeeService.saveEmployee(newEmployee).subscribe(
        (response) => {
          console.log('Employee saved successfully!', response);
        },
        (error) => {
          console.error('Error saving employee!', error);
        }
      );
    } else {
      console.log('Form is invalid');
    }
  }

}
