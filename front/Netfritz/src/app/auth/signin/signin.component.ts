import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sigin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  
  loginForm: FormGroup;
  fieldTextType: boolean;

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
  }


  initPassForm() {
    this.loginForm = this.fb.group({
      password: ["", Validators.required],
      email: ['', [
        Validators.required, 
        Validators.email]
      ],
	    updateOn: 'blur'
    });
  }

  signIn(){

  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
    this.changeIcon();
  }

  changeIcon() {
    if(this.fieldTextType) {
      return "visibility"
    }
    else{
      return "visibility_off"
    }
  }
}

