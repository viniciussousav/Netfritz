import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
// import { UserService } from '../../../core/services/user.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-new-user-modal',
  templateUrl: './new-user-modal.component.html',
  styleUrls: ['./new-user-modal.component.scss'],
  animations: [
    trigger(
      'animationAlert', 
      [
        transition(
          ':enter', 
          [
            style({ opacity: 0,  top: '-10px'}),
            animate('.2s ease-out', style({ opacity: 1,  top: 0 }))
          ]
        ),
        transition(
          ':leave', 
          [
            style({ opacity: 1,  top: 0 }),
            animate('.2s ease-in', style({ opacity: 0,  top: '-10px'}))
          ]
        )
      ]
    )
  ]
})


export class NewUserModalComponent implements OnInit {

  newUserForm: FormGroup;
  successStep: boolean;
  showAlert: boolean = false;
  submitted: boolean = false;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<NewUserModalComponent>,
    // private userService: UserService,
    public router: Router,
    public location: Location
  ) {
  }

  ngOnInit(): void {
    this.successStep = false;
    this.initPassForm();
  }

  initPassForm() {
    this.newUserForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [
        Validators.required, 
        Validators.email]
      ],
	    updateOn: 'blur'
    });
  }

  newUser(){
    let att = {
      'email_verified':'true',
      'email': this.newUserForm.value.email,
      'custom:role': this.newUserForm.value.func,
      'name': this.newUserForm.value.name
    }
    // this.userService.createAdminUser(att).subscribe( res => {
    //   if(res == 409){
    //     this.newUserForm.controls['email'].setErrors({uniqueEmail: true});
    //     this.showAlert = true;
    //   } else {
    //     this.successStep = true;
    //     this.newUserForm.value.email;
    //   }

    // })
  }

  redirectTo(uri:string){
    this.dialogRef.close();
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() =>
      this.router.navigate([uri])
    );
  }

  onClose() {
    this.dialogRef.close();
  }

  goToAddUser() {
    this.successStep = false;
  }

  closeAlert() {
    this.showAlert = false;
  }


}
