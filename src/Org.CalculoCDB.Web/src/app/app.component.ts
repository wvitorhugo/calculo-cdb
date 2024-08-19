import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InvestimentoCDBService } from './services/investimento-cdb.service'; 
import { FormsModule } from '@angular/forms';   
import { CommonModule } from '@angular/common';  
 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
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
      (complete) => {
        console.log(complete);
        this.resultado =
        `Valor Bruto: R$ ${complete.valorBruto}`+
        ` | Valor Líquido: R$ ${complete.valorLiquido}`+
        ` | Valor Taxa: R$ ${complete.valorTaxa}`
        complete;
      },
      (error) => {
        console.log(error);
        this.resultado = `Erro: ${error.message}`;
      }
    );
  } 
}
