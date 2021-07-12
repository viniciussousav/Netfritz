import { environment } from '../../environments/environment';
import { catchError, map, switchMap } from "rxjs/operators";
import { Observable, of, throwError } from "rxjs";
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})


export class AuthService {
  constructor(
    private http: HttpClient,
    private router: Router
    ){}

    login(email: string, password: string): Observable<any> {
        const url = environment.backend+'/login/';
        return this.http.post<any>(url, {email: email, senha: password})
        .pipe(
            catchError(err => {
              console.error(err);
              if(err.status == 500) {
                return of(err.status);
              }
               return throwError(err.error.message);
            }));
      }


    addClient(cliente: any): Observable<any> {
      const url = environment.backend+'/cliente/cadastrar';
      return this.http.post<any>(url, cliente)
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