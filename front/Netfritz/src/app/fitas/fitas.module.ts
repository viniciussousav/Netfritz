import { NewFitaModalComponent } from './new-fita-modal/new-fita-modal.component';
import { FitasManagementComponent } from './fitas-management/fitas-management.component';
import { FitasRoutingModule } from './fitas-routing.module';
import { SharedModule } from './../shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FitasService } from './fitas.service';



@NgModule({
  declarations: [FitasManagementComponent, NewFitaModalComponent],
  imports: [
    CommonModule,
    SharedModule,
    FitasRoutingModule
  ],
  providers: [FitasService]
})
export class FitasModule { }
