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

  ModalTtitle:string="";
  emp:any;
  ActivateAddEditEmpComp:boolean=false;

  ngOnInit(): void {
    this.refreshDbList();
  }
  refreshDbList(){
    this.service.getEmployeeList().subscribe(data => {
      this.empList=data;
    });
  }

  addClick(){
    this.emp={
      empId:0,
      empName:"",
      empTitle:"",
      empEmail:"",
      countryId:1
    }
    this.ModalTtitle="Add Department";
    this.ActivateAddEditEmpComp=true;
  }

}
