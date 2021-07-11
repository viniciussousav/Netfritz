import { Router } from '@angular/router';
import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from './_helper';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  registrationForm: FormGroup;
  fieldTextType: boolean;
  fieldTextTypeConfirm: boolean;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router

    ) { }

  ngOnInit(): void {
    this.initPassForm();
  }

  initPassForm() {
    this.registrationForm = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      confirmEmail: ["", [Validators.required, Validators.email]],
      cartao: ["", [Validators.required]],
      password: ["", Validators.required],
      confirmPassword: ["", Validators.required],
    },{
      validators: [
        MustMatch('password', 'confirmPassword'),
        MustMatch('email', 'confirmEmail')
      ]
    });
  }

  signUp(){
    let user = {
      'email': this.registrationForm.value.email,
      'cartao': this.registrationForm.value.cartao,
      'password': this.registrationForm.value.password,
    }
    this.authService.addClient(user).subscribe( res => {
      this.router.navigate([''])
    })
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
    this.changeIcon();
  }

  toggleFieldTextTypeConfirm() {
    this.fieldTextTypeConfirm = !this.fieldTextTypeConfirm;
    this.changeIconConfirm();
  }

  changeIcon() {
    if(this.fieldTextType) {
      return "visibility"
    }
    else{
      return "visibility_off"
    }
  }

  changeIconConfirm() {
    if(this.fieldTextTypeConfirm) {
      return "visibility"
    }
    else{
      return "visibility_off"
    }
  }
  
}
