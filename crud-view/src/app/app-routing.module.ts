import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { CountryComponent } from './country/country.component';
const routes: Routes = [
  {path: 'employee' , component:EmployeeComponent},
  {path: 'country' , component:CountryComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
