namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        //Podemos também atribuir referencias de caracteres Unicode
        public char myChar4 = '\u2726';

        //Podemos ainda mesclar caracteres espciais, como, nova linha, tabulação e etc.
        public string textLine = "Esta é uma linha de texto.\n\n\n E esta é outra linha.";

        /*
            \e - Caractere de escape 
            \n - Nova linha
            \r - Retorno
            \t - Tab
            \" - Usadas para exibir aspas duplas dentro da String
            \' - Usadas para exibir aspas simples dentro da String
        */

       
        private int count = 18;
        public string message;
        public DataType()
        {
            // Interpolação de Strings
            // Combinando Strings de diferentes maneiras no C#
            message = "$O contador esta em {count}";

            string username = "Gilmar";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\nO usuário {username} tem {inboxCount}Mensagens.";
            message += $"\nEspaço restante em sua caixa {maxCount - inboxCount}";
        }

    }









}

