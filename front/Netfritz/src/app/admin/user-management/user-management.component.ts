import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
// import { UserService } from '../../../core/services/user.service';
import { NewUserModalComponent } from './../new-user-modal/new-user-modal.component';

export interface userManagement {
  'custom:organization': string,
  'custom:role': string,
  'email': string,
  'email_verified': string,
  'locale': string,
  'name': string,
  'sub': string
}

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements OnInit {

  searchForm: FormGroup;

  users: [any?] = [];
  displayedColumns: string[] = ['name', 'email', 'actions'];
  dataSource = new MatTableDataSource<any>(this.users);

  loading: boolean;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;


  constructor(
    // private userSevice: UserService,
    private fb: FormBuilder,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
    this.getUsers();
    this.initPassForm();
    this.loading = true;
    setTimeout(() => {
      this.loading = false;
    }, 2000)
  }

  initPassForm() {
    this.searchForm = this.fb.group({
      search: [""]
    });
  }

  getUsers(){
    // this.userSevice.getUserOp().subscribe(
    //   (list) => {
    //     list.Users.forEach((user: userManagement) => {
    //       let init = ""
    //       if(user.name){
    //         init = this.initials(user.name)
    //       }
    //       let newUser = {name: user.name, role: user["custom:role"], email:user.email, initial: init}
    //       this.users.push(newUser);
    //     })
    //     this.dataSource.data = this.users;
    //   }
    // )
  }

  filterUser() {
    let filter = this.searchForm.value.search;
    this.dataSource.filter = filter.toLowerCase()
  }

  openNewUserModal(): void {
    this.dialog.open(NewUserModalComponent, {
      panelClass: 'modal-css'
    });
  }

}


