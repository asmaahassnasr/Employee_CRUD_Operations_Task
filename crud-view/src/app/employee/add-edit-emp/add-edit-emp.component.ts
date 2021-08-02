import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
// import * as internal from 'stream';

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
empBirthDate:string;
empPhoto:string;
imageFile:string;
imageSrc:string;

  ngOnInit(): void {
    this.empId=this.emp.empId;
    this.empName=this.emp.empName;
    this.empTitle=this.emp.empTitle;
    this.empEmail=this.emp.empEmail;
    this.empSalary=this.emp.empSalary;
    this.empBirthDate=this.empBirthDate;
    this.empPhoto=this.empPhoto;
    this.imageFile=this.imageFile;
    this.imageSrc= this.imageSrc;
  }

  addEmployee(){
var val= {
  empId:this.empId,
  empName:this.empName,
  empTitle:this.empTitle,
  empEmail:this.empEmail,
  empSalary:this.empSalary,
  empBirthDate:this.empBirthDate,
  empPhoto:this.empPhoto,
  imageFile:this.imageFile,
  imageSrc:this.imageSrc
};
this.servic.addEmployee(val).subscribe(res => {
  alert("Done");
});
  }
  updateEmployee(){
    var val= {
      empId:this.empId,
      empName:this.empName,
      empTitle:this.empTitle,
      empEmail:this.empEmail,
      empSalary:this.empSalary,
      empBirthDate:this.empBirthDate,
      empPhoto:this.empPhoto,
      imageFile:this.imageFile,
      imageSrc:this.imageSrc
    };
    this.servic.updateEmployee(val).subscribe(res => {
      alert("Done");
    });
  }

  uploadPhoto(event:any){
    var file =event.target.files[0];
    const formData:FormData = new FormData();
    formData.append('uploadedFile',file,file.name);

    this.servic.uploadPhoto(formData).subscribe((data:any) => {
      this.empPhoto=data.toString();
      this.imageSrc=this.servic.photoUrl+this.empPhoto;
    });
  }
}
