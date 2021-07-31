import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import * as internal from 'stream';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private servic: SharedService) { }
  
@Input() emp:any;
empId:string;
empName:string;
empTitle:string;
empEmail:string;
empSalary:number;
  ngOnInit(): void {
    this.empId=this.emp.empId;
    this.empName=this.emp.empName;
    this.empTitle=this.emp.empTitle;
    this.empEmail=this.emp.empEmail;
    this.empSalary=this.emp.empSalary;
  }

  addEmployee(){
var val= {
  empId:this.empId,
  empName:this.empName,
  empTitle:this.empTitle,
  empEmail:this.empEmail,
  empSalary:this.empSalary
};
this.servic.addEmployee(val).subscribe(res => {
  alert(res.toString());
});
  }
  updateEmployee(){
    var val= {
      empId:this.empId,
      empName:this.empName,
      empTitle:this.empTitle,
      empEmail:this.empEmail,
      empSalary:this.empSalary
    };
    this.servic.updateEmployee(val).subscribe(res => {
      alert(res.toString());
    });
  }
}
