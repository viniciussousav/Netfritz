import { environment } from './../../environments/environment';
import { catchError, map, switchMap } from "rxjs/operators";
import { Observable, of, throwError } from "rxjs";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})


export class FitasService {
  constructor(
    private http: HttpClient,
    private router: Router
    ){}

    addFita(fita: any): Observable<any> {
        const url = '/api/admin/cadastrar-fita/';
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

    updateFita(fita: any, idFita: any): Observable<any> {
      const url = '/api/admin/atualizar-fita'+ "/"+ idFita;
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

    getFitas(title?: any): Observable<any> {
      const url = environment.backend +"fitas/";
      return this.http.get<any>(url)
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