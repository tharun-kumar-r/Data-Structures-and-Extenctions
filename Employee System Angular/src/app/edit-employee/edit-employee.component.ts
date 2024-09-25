import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../employee.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html'
})
export class EditEmployeeComponent implements OnInit {
  employeeId: number = 0;
  employee: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    middleName: '',
    contact: '',
    email: '',
    dateOfBirth: '',
    address: '',
    gender: '',
    password: '',
    department: '',
    profilePicture: '',
    termsAccepted: false
  };

  employees: Employee[] = [
    { id: 1, firstName: 'Tharun', lastName: 'Kumar', contact: '1234567890', email: 'tharun@gmail.com', dateOfBirth: '1990-01-01', address: '123 Main St', gender: 'Male', password: 'password123', department: 'IT', profilePicture: '', termsAccepted: true },
    { id: 2, firstName: 'Jane', lastName: 'Smith', contact: '0987654321', email: 'jane@example.com', dateOfBirth: '1992-02-02', address: '456 Elm St', gender: 'Female', password: 'password123', department: 'HR', profilePicture: '', termsAccepted: false }
  ];

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.employeeId = +params['id'];
      this.loadEmployee();
    });
  }

  loadEmployee() {
    const foundEmployee = this.employees.find(emp => emp.id === this.employeeId);
    if (foundEmployee) {
      this.employee = { ...foundEmployee }; // Spread operator to create a copy
    } else {
      console.error('Employee not found, redirecting...');
      this.router.navigate(['/']);
    }
  }

  updateEmployee(form: any) {
    if (form.valid) {
      console.log('Updated Employee:', this.employee);
    }
  }
}
