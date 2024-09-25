import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';

const routes: Routes = [
  { path: 'employees', component: EmployeeListComponent },
  { path: 'edit-employee/edit/:id', component: EditEmployeeComponent },
  { path: '', redirectTo: '/employees', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
