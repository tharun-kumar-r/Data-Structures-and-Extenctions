import { Routes } from '@angular/router';
import { AppComponent } from './app.component';

import { EmployeelistComponent } from './employeelist/employeelist.component';
import { CreateempComponent } from './createemp/createemp.component';
import { EditEmpComponent } from './editemp/editemp.component';

export const routes: Routes = [

  
  { path: '', redirectTo: '/employee', pathMatch: 'full' },
  { path: "create", component: CreateempComponent },
  { path: "emp/:id", component: EditEmpComponent },
  { path: "employee", component: EmployeelistComponent }

  
];


