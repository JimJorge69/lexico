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
                            break;
                        }
                        else if (caracter == ')')//Parentesis Derecho
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.ParentesisDerecho);
                            break;
                        }
                        else if (caracter == '{')//LLave Izquierda
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveIzquierda);
                            break;
                        }
                        else if (caracter == '}')//LLave Derecha
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.LlaveDerecha);
                            break;
                        }
                        else if (caracter == '*')//Operador Multiplicacion
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorMultiplicador);
                            break;
                        }
                        else if (caracter == '/')//Operador Division
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorDivision);
                            break;
                        }
                        else if (caracter == '+')//Operador Suma
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorSuma);
                            break;
                        }
                        else if (caracter == '-')//Operador resta
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.OperadorResta);
                            break;
                        }
                        else if (caracter == '[')//Corchete izquierdo
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.CorcheteIzquierdo);
                            break;
                        }
                        else if (caracter == ']')//Corchete derecho
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.CorcheteDerecho);
                            break;
                        }
                        int variable = (int)Char.GetNumericValue(caracter);// Se cambia a enteros para que valide los errores
                        if (variable>=0)//Numeros
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Numero);
                            break;
                        }
                        else
                        {
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Error);
                        }
                        break;
                    case 1://algun error
                         auxiliarLexico += caracter;
                        agregarToken(Token.Tipo.Error);
                        break;
                    default:
                        auxiliarLexico += caracter;
                        agregarToken(Token.Tipo.Error);
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
