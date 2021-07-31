import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-show-count',
  templateUrl: './show-count.component.html',
  styleUrls: ['./show-count.component.css']
})
export class ShowCountComponent implements OnInit {
 
  constructor(private service:SharedService) { }


  countryList:any=[];

  ModalTtitle:string;
  count:any;
  ActivateAddEditEmpComp:boolean=false;

  ngOnInit(): void {
    this.refreshCountryList();
  }

  refreshCountryList(){
    this.service.getCountryList().subscribe(data => {
      this.countryList=data;
    });
  }
   
  addClick(){
    this.count={
      countryId:0,
      countryName:"",
      countryCode:""
    }
    this.ModalTtitle="Add Country";
    this.ActivateAddEditEmpComp=true;
  }
  
  closeClick(){
    this.ActivateAddEditEmpComp=false;
    // If new Country added we can see it without refreshing the page 
    this.refreshCountryList();
  }
  
  }

