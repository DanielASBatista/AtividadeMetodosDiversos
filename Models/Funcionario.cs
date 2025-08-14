using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes.Models
{
    public class Funcionario
    {
        public int Id { get; set;}
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public TipoFuncionarioEnum TipoFuncionario { get; set; }
    
    
    public void ReajustarSalario(){
        Salario = Salario + (Salario * 10/100);
    }

    public string ExibirPeriodoExperiencia(){
        string PeriodoExperiencia = string.Format("Periodo de experiencia: {0} até {1}",DataAdmissao,DataAdmissao.AddMonths(3));
        return PeriodoExperiencia;
    }
    
    public decimal CalcularDescontoVT(decimal percentual){
        decimal desconto = this.Salario * percentual/100;
        return desconto;
    }
    }
}
