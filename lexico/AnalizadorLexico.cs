using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexico
{
    class AnalizadorLexico
    {
        private LinkedList<Token> Salida;
        private int estado;
        private String auxiliarLexico;

        public LinkedList<Token> escanear(String entrada)
        {
            Salida = new LinkedList<Token>();
            estado = 0;
            auxiliarLexico = "";

            Char caracter;
            for (int i = 0; i < entrada.Length; i++)
            {
                caracter = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (caracter == '(')//Parentesis Izquierdo
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.ParentesisIzquierdo);
                        }
                        else if (caracter == ')')//Parentesis Derecho
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.ParentesisDerecho);
                        }
                        else if (caracter == '{')//LLave Izquierda
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveIzquierda);
                        }
                        else if (caracter == '}')//LLave Derecha
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveDerecha);
                        }
                        else if (caracter == '*')//Operador Multiplicacion
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorMultiplicador);
                        }
                        else if (caracter == '/')//Operador Division
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorDivision);
                        }
                        else if (caracter == '+')//Operador Suma
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorSuma);
                        }
                        else if (caracter == '-')//Operador resta
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorResta);
                        }else if (caracter == '[')//Corchete izquierdo
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.CorcheteIzquierdo);
                        }
                        else if (caracter == ']')//Corchete derecho
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.CorcheteDerecho);
                        }
                        else if (caracter >= 0)//Numeros positivos
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Numero);
                        }else if (caracter < 0)//Numeros negativos
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.NumeroNegativo);
                        }
                        break;
                    case 1://algun error
                        if (char.IsDigit(caracter))
                        {
                            estado = 1;
                            auxiliarLexico += caracter;
                        }
                        break;
                    case 2://Numero Foltante
                        if (Char.IsDigit(caracter))
                        {
                            estado = 9;
                            auxiliarLexico += caracter;
                        }
                        else
                        {
                            agregarToken(Token.Tipo.NumeroDecimal);
                            i -= 1;
                        }
                        break;
                }
            }
            return Salida;

        }

        public void agregarToken(Token.Tipo tipo)
        {
            Salida.AddLast(new Token(tipo, auxiliarLexico));
            auxiliarLexico = "";
            estado = 0;
        }
        public void imprimirListaToken(LinkedList<Token> lista)
        {
            foreach (Token item in lista)
            {
                Console.WriteLine(item.GetTipo() + " <--> " + item.Getval());
            }
        }
    }
}
