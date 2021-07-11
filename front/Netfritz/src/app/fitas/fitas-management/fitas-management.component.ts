import { FitasService } from './../fitas.service';
import { NewFitaModalComponent } from '../new-fita-modal/new-fita-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-fitas-management',
  templateUrl: './fitas-management.component.html',
  styleUrls: ['./fitas-management.component.scss']
})
export class FitasManagementComponent implements OnInit {


  searchForm: FormGroup;

  fitas: [any?] = [];
  displayedColumns: string[] = ['title', 'price'];
  dataSource = new MatTableDataSource<any>(this.fitas);

  loading: boolean;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;


  constructor(
    private fitasService: FitasService,
    private fb: FormBuilder,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.dataSource.paginator = this.paginator;
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

  getFitas() {
    this.fitasService.getFitas().subscribe(
      (a) => {
        this.dataSource.data = this.fitas;
      }
    )
  }

  filterUser() {
    let filter = this.searchForm.value.search;
    this.dataSource.filter = filter.toLowerCase()
  }

  openNewFitaModal(): void {
    this.dialog.open(NewFitaModalComponent, {
      panelClass: 'modal-css'
    });
  }

}