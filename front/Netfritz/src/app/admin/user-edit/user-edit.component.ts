import { Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';
// import { UserService } from '../../../core/services/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.scss'],
})
export class UserEditComponent implements OnInit {
  userEditForm: FormGroup;
  userData;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: unknown,
    public dialogRef: MatDialogRef<UserEditComponent>,
    private fb: FormBuilder,
    // private userService: UserService,
    private router: Router
  ) {
    this.userData = this.data['user'];
  }

  ngOnInit(): void {
    this.initPassForm();
  }

  initPassForm() {
    this.userEditForm = this.fb.group({
      name: [(this.userData.name), Validators.required],
      email: [(this.userData.email), Validators.required],
      cartao: [(this.userData.cartao), Validators.required],
    });
  }

  get name(): AbstractControl{
    return this.userEditForm.get('name');
  }

  get email(): AbstractControl{
    return this.userEditForm.get('email');
  }

  get cartao(): AbstractControl{
    return this.userEditForm.get('cartao');
  }

  onClose() {
    this.dialogRef.close();
  }

  userEdit() {
    // this.userService.updateUserB2g(this.gender.value, this.name.value).subscribe(
    //   (res: any) => {
    //     if (res) {
    //       this.router.navigateByUrl('b2g/dash/user/detail').then(() =>
    //         window.location.reload()
    //       );
    //       this.onClose();
    //     }
    //   }
    // )
  }
}
