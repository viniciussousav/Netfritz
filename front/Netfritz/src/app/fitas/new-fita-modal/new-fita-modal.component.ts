import { FitasService } from './../fitas.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
// import { UserService } from '../../../core/services/user.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { animate, state, style, transition, trigger } from '@angular/animations';

@Component({
  selector: 'app-new-fita-modal',
  templateUrl: './new-fita-modal.component.html',
  styleUrls: ['./new-fita-modal.component.scss'],
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


export class NewFitaModalComponent implements OnInit {

  newFitaForm: FormGroup;
  successStep: boolean;
  showAlert: boolean = false;
  submitted: boolean = false;
  public imagePath;
  imgURL: any;
  public message: string;

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<NewFitaModalComponent>,
    private fitasService: FitasService,
    public router: Router,
    public location: Location
  ) {
  }

  ngOnInit(): void {
    this.successStep = false;
    this.initPassForm();
  }

  initPassForm() {
    this.newFitaForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      img: ['', Validators.required],
	    updateOn: 'blur'
    });
  }

  preview(files) {
    if (files.length === 0)
      return;
    let mimeType = files[0].type;

    if (mimeType.match(/image\/*/) == null) {
      this.message = "Só suportamos imagens";
      return;
    }

    let reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]);

    reader.onload = (_event) => {
      this.imgURL = reader.result;
    }
  }

  newFita(){
    let fita = {
      'title': this.newFitaForm.value.email,
      'description': this.newFitaForm.value.func,
      'price': this.newFitaForm.value.name,
      'img': this.imgURL,
    }
    this.fitasService.addFita(fita).subscribe( res => {
        this.successStep = true;
    })
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

  goToAddFita() {
    this.successStep = false;
  }

  closeAlert() {
    this.showAlert = false;
  }


}
