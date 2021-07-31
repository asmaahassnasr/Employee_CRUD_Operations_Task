import { Injectable } from '@angular/core';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {Observable, observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44364/api";
   readonly photoUrl= "https://localhost:44364/Images";

  constructor(private http:HttpClient) { }

  getCountryList() : Observable<any []>
  {
      return this.http.get<any>(this.APIUrl+'/countries');
  }

  addCountry(val:any)
  {
      return this.http.post(this.APIUrl+'/countries',val);
  }
  
  // getAllCountriesNames() : Observable<any []>
  // {
  //   return this.http.get<any>(this.APIUrl+'/countries/GetAllCountriesNames');
  // }


  getEmployeeList() : Observable<any []>
  {
      return this.http.get<any>(this.APIUrl+'/employees');
  }

  addEmployee(val:any)
  {
      return this.http.post(this.APIUrl+'/employees',val);
  }
  updateEmployee(val:any)
  {
      return this.http.put(this.APIUrl+'/employees',val);
  }
  deleteEmployee(val:any)
  {
      return this.http.delete(this.APIUrl+'/employees/',val);
  }

  // uploadPhoto(val:any)
  // {
  //     return this.http.post(this.APIUrl+'/employees/SaveImage',val);
  // }

}
