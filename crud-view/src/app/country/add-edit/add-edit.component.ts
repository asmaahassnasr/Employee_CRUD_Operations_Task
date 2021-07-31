import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {


  constructor(private servic:SharedService) { }

  @Input() count:any;
  CountryId:string;
  CountryName:string;
  CountryCode:string;
  ngOnInit(): void {
    this.CountryId=this.count.CountryId;
    this.CountryName=this.count.CountryName;
    this.CountryCode=this.count.CountryCode;
  }

addCountry(){ 
var val= {
  CountryId:this.CountryId,
  CountryName:this.CountryName,
  CountryCode:this.CountryCode

};
this.servic.addCountry(val).subscribe(res => {
  alert(res.toString());
});
}
 
}
