import { SignupComponent } from './signup/signup.component';
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from './../shared.module';
import { SigninComponent } from './signin/signin.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth.service';



@NgModule({
  declarations: [SigninComponent, SignupComponent],
  imports: [
    SharedModule,
    AuthRoutingModule
  ],
  providers: [AuthService]
})
export class AuthModule { }
