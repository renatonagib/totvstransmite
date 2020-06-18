import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NFe } from './NFe.model';

@Injectable()
export class AppServiceService{

  constructor(private http: HttpClient) { }

  NFes(): Observable<NFe[]>{
    return this.http.get<NFe[]>('http://localhost:8081/api/NFes');
  }
}
