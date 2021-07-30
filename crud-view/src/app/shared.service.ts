import { Injectable } from '@angular/core';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {Observable, observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44364/api";
  // readonly photoUrl= "https://localhost:44364/photos";

  constructor(private http:HttpClient) { }

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
      return this.http.post(this.APIUrl+'/employees',val);
  }
  deleteEmployee(val:any)
  {
      return this.http.post(this.APIUrl+'/employees',val);
  }

  // uploadPhoto(val:any)
  // {
  //     return this.http.post(this.APIUrl+'/employees/saveFile',val);
  // }

}
