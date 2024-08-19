import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InvestimentoCDBService } from './services/investimento-cdb.service';
import { InvestimentoCDB } from './models/investimento-cdb.model'; 
import { InvestimentoResult } from  './models/investimento-result.model';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';  



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HttpClientModule,  
    CommonModule,
    FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Org.CalculoCDB.Web';
 
    
  constructor(private investimentoCdbService: InvestimentoCDBService){ 
  }
  Valor!: number;
  PrazoEmMeses!: number; 
  resultado!: any; 
 
  onSubmit() {
    if (!this.Valor || !this.PrazoEmMeses)
      return;

    this.investimentoCdbService.calcular({
       Valor: this.Valor,
       PrazoEmMeses: this.PrazoEmMeses
    }).subscribe(
      (resposta) => {
        console.log(resposta);
        this.resultado =
        `Valor Bruto: R$ ${resposta.valorBruto}`+
        ` | Valor Líquido: R$ ${resposta.valorLiquido}`+
        ` | Valor Taxa: R$ ${resposta.valorTaxa}`
        resposta;
      },
      (erro) => {
        console.log(erro);
        this.resultado = `Erro: ${erro.error.message}`;
      }
    );
  } 
}
