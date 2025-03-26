namespace NumeroExtenso.Models
{
    //Classe que define a Conversão de Int para String
    public class NumberConversion
    {
        //Variável que armazena número digitado por usuário
        public int Number { get; set; }

        //Método de conversão para uma string extenso
        public string ToExtenso()
        {
            //"0" é zero por extenso
            if (Number == 0)
                return "zero";

            //Arrays que armazenam unidades, dezenas, centenas, milhares e especiais
            var unidades = new[] { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            var dezenas = new[] { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            var especiais = new[] { "", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            var centenas = new[] { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            var milhares = new[] { "", "mil", "milhão", "milhões" };

            //String vazia para armazenar número que usuário irá digitar
            string resultado = "";

            //Definindo resto de milhar para facilitar conversão e leitura de unidades
            int milhar = Number / 1000;
            int resto = Number % 1000;

            //Condicional para definir leitura de milhares, especialmente o inteiro "um mil"
            if (milhar > 0)
            {
                if (milhar == 1)
                    resultado += " um mil";
                else
                    resultado += ConvertCentenas(milhar) + " mil";

                if (resto > 0)
                    resultado += " e ";
            }

            //Condicional para definir leitura do resto de casas de uma centena
            if (resto > 0)
            {
                resultado += ConvertCentenas(resto);
            }

            //Remover espaços em branco de uma string, tanto a direita quanto esquerda
            return resultado.Trim();
        }

        //Método para facilitar e corrijir possíveis erros na leitura de centenas
        private string ConvertCentenas(int numero)
        {
            //Definindo Arrays de unidades, dezenas, centenas e especiais, já que milhares já foi revisado anteriormente
            var unidades = new[] { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
            var dezenas = new[] { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            var especiais = new[] { "", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            var centenas = new[] { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

            //Condicional para definir leitura de centenas, especialmente "cem"
            if (numero == 100)
                return "cem";

            //Módulos e divisões para definir a escrita 
            int centena = numero / 100;
            int dezena = (numero % 100) / 10;
            int unidade = numero % 10;

            string resultado = "";

            //Condicionais para definir o retorno por extenso
            if (centena > 0)
                resultado += centenas[centena];

            if (dezena > 1)
            {
                resultado += " " + dezenas[dezena];
                if (unidade > 0)
                    resultado += " e " + unidades[unidade];
            }
            else if (dezena == 1 || unidade > 0)
            {
                if (dezena == 1)
                    resultado += " " + especiais[unidade];
                else
                    resultado += " " + unidades[unidade];
            }

            return resultado.Trim();
        }
    }
}