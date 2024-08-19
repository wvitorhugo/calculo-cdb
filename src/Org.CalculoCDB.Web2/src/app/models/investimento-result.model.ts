export class InvestimentoResult {
    ValorBruto: number;
    ValorLiquido: number;
    ValorTaxa: number;   

    constructor(ValorBruto: number, ValorLiquido: number, ValorTaxa: number) {
        this.ValorBruto = ValorBruto;
        this.ValorLiquido = ValorLiquido;
        this.ValorTaxa = ValorTaxa;
    }
}