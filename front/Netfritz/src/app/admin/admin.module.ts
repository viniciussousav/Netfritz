import { NewUserModalComponent } from './new-user-modal/new-user-modal.component';
import { SharedModule } from './../shared.module';
import { AdminRoutingModule } from './admin-routing.module';
import { UserManagementComponent } from './user-management/user-management.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminService } from './admin.service';



@NgModule({
  declarations: [UserManagementComponent, NewUserModalComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  providers: [AdminService]
})
export class AdminModule { }
