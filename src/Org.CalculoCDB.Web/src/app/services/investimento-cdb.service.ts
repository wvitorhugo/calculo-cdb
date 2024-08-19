import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { InvestimentoCDB } from '../models/investimento-cdb.model'; 
import { InvestimentoResult } from '../models/investimento-result.model';  

const baseUrl = `${environment.api}/InvestimentoCDB`;

@Injectable({
  providedIn: 'root',
})

export class InvestimentoCDBService {
  constructor(private http: HttpClient) {} 

  calcular(investimentoCDB: InvestimentoCDB): Observable<any> { 
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    }); 
     
    return this.http.post<any>(baseUrl, {
      'Valor': investimentoCDB.Valor,
      'PrazoEmMeses':investimentoCDB.PrazoEmMeses
    },{ headers });
  } 

}