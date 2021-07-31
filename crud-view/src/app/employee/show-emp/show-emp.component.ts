import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css']
})
export class ShowEmpComponent implements OnInit {

  constructor(private service:SharedService) { }
 
  empList:any=[];

  ModalTtitle:string;
  emp:any;
  ActivateAddEditEmpComp:boolean=false;
EmpNameFilter:string="";
EmpTitleFilter:string="";
EmpSalaryFilter:number;
EmpCountryFilter:string="";
EmpListtWithoutFilteration:any=[];

  ngOnInit(): void {
    this.refreshDbList();
  }
  refreshDbList(){
    this.service.getEmployeeList().subscribe(data => {
      this.empList=data;
      this.EmpListtWithoutFilteration=data;
    });
  }

  addClick(){
    this.emp={
      empId:0,
      empName:"",
      empTitle:"",
      empEmail:"",
      empSalary:0
    } 
    this.ModalTtitle="Add Employee";
    this.ActivateAddEditEmpComp=true;
  }


editClick(item:any){
  this.emp=item;
  this.ModalTtitle="Edit Employee";
  this.ActivateAddEditEmpComp=true;
}

deleteClick(item:any){
  if(confirm("Are you sure ??")){
    this.service.deleteEmployee(item.empId).subscribe(data => {
      this.refreshDbList();
    });
  }
}
 
  closeClick(){
    this.ActivateAddEditEmpComp=false;
    this.refreshDbList();
  }

filterFun(){
 var EmpSalaryFilter= this.EmpSalaryFilter;
 var EmpTitleFilter= this.EmpTitleFilter;
 var EmpNameFilter= this.EmpNameFilter;
 var EmpCountryFilter= this.EmpCountryFilter;
 var EmpListtWithoutFilteration=  this.EmpListtWithoutFilteration.filter(function(el:any){
   return (el.empName.toString().toLowerCase().includes(EmpNameFilter.toString().trim().toLowerCase()) 
   ) &&
   ( el.empTitle.toString().toLowerCase().includes( EmpTitleFilter.toString().trim().toLowerCase())
   ) &&
   ( el.empSalary.toString().toLowerCase().includes( EmpSalaryFilter.toString().trim().toLowerCase())
   ) &&
   ( el.countryId.toString().toLowerCase().includes( EmpCountryFilter.toString().trim().toLowerCase())
   )
 });
}

}
