import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  employees = [
    { id: 1, firstName: 'Tharun', lastName: 'kumar', email: 'rajtharunir@gmail.com', contact: '1234567890' },
    { id: 2, firstName: 'Tharun', lastName: 'kumar', email: 'rajtharunir@gmail.com', contact: '1234567890' },
    { id: 3, firstName: 'Tharun', lastName: 'kumar', email: 'rajtharunir@gmail.com', contact: '1234567890' }
  ];

  constructor(private router: Router) {}

  editEmployee(employee: any) {
   
    this.router.navigate(['/edit-employee/edit', employee.id]);
  }
}
