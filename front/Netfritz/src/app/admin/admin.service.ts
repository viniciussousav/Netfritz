import { environment } from '../../environments/environment';
import { catchError, map, switchMap } from "rxjs/operators";
import { Observable, of, throwError } from "rxjs";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})


export class AdminService {
  constructor(
    private http: HttpClient,
    private router: Router
    ){}

    addAdmin(admin: any): Observable<any> {
        const url = '/api/admin/cadastrar-admin/';
        return this.http.post<any>(url, admin)
        .pipe(
            catchError(err => {
              console.error(err);
              if(err.status == 500) {
                return of(err.status);
              }
               return throwError(err.error.message);
            }));
      }

    getAdmin(fita: any, idAdmin: any): Observable<any> {
      const url = "/api/admin/" + idAdmin;
      return this.http.post<any>(url, fita)
      .pipe(
          catchError(err => {
            console.error(err);
            if(err.status == 500) {
              return of(err.status);
            }
             return throwError(err.error.message);
        }));
      }
  }