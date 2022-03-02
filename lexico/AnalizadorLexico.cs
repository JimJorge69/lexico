using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lexico
{
    class AnalizadorLexico
    {
        //Se declaran las variables a utilizar
        private LinkedList<Token> Salida;
        private int estado;
        private String auxiliarLexico;
        private int contador;
        private int parentesisD, parentesisI, LlaveD, LlaveI,CorcheteD,CorcheteI,mas,menos,multi,divi,valida;

        public LinkedList<Token> escanear(String entrada)
        {
            //Se declaran las variables que inicien limpias
            Salida = new LinkedList<Token>();
            estado = 0;
            auxiliarLexico = "";
            contador = 0;
            parentesisD = 0; parentesisI = 0; LlaveD = 0; LlaveI = 0; // Variables para identificar validacion
            CorcheteD = 0; CorcheteI = 0; mas = 0; menos = 0; multi = 0; divi = 0; valida = 0;
            Char caracter;
            //Se inicia un siclo para la verificacion de la operacion sea correcta
            for (int i =0; i<entrada.Length;i++)
            {
                
                caracter = entrada.ElementAt(i);
                int variable = (int)Char.GetNumericValue(caracter);// Se cambia a enteros para que valide los errores
                if (caracter == '(')//Parentesis Izquierdo
                {
                    parentesisI += 1;
                    valida = 0;
                }
                else if (caracter == ')')//Parentesis Derecho
                {
                    parentesisD += 1;
                    valida = 0;
                }
                else if (caracter == '{')//LLave Izquierda
                {
                    LlaveI += 1;
                    valida = 0;
                }
                else if (caracter == '}')//LLave Derecha
                {
                    LlaveD += 1;
                    valida = 0;
                }
                else if (caracter == '[')//Corchete izquierdo
                {
                    CorcheteI += 1;
                    valida = 0;
                }
                else if (caracter == ']')//Corchete derecho
                {
                    CorcheteD += 1;
                    valida = 0;
                }
                else if (variable >= 0)//Numeros
                {
                    valida = 0;
                }
                else if (caracter =='+')//Operador mas
                {
                    valida += 1;
                    if (valida >= 1)
                        mas += 1;
                    else
                        valida = 0;
                }
                else if (caracter == '-')//Operador menos
                {
                    valida += 1;
                    if (valida >= 1)
                        menos += 1;
                    else
                        valida = 0;
                }
                else if (caracter == '*')//Operador multiplicacion
                {
                    valida += 1;
                    if (valida >= 1)
                        multi += 1;
                    else
                        valida = 0;
                }
                else if (caracter == '/')//Operador division
                {
                    valida += 1;
                    if (valida >= 1)
                        multi += 1;
                    else
                        valida = 0;
                }
            }
            int sumaTodos = parentesisD + parentesisI + LlaveD + LlaveI + CorcheteD + CorcheteI;//Suma de todas las llaves encontradas y verificar si es correcta 
            if ((sumaTodos % 2) == 0)//Se valide que en la suma numero par para asi verificar que todo este bien
            {
                //Si se valida se empieza a dividir letra por letra oh caracter y enlistar en una tabla que es lo que se introdujo
                for (int i = 0; i < entrada.Length; i++)
                {
                    caracter = entrada.ElementAt(i);

                    switch (estado)
                    {
                        case 0:
                            if (caracter == '(')//Parentesis Izquierdo
                            {
                                auxiliarLexico += caracter;//Se declara el caracter en el auxiliar
                                agregarToken(Token.Tipo.ParentesisIzquierdo);//agrega a la lista de la tabla
                                break;//Cierra el switch
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
                            if (variable >= 0)//Numeros
                            {
                                auxiliarLexico += caracter;
                                agregarToken(Token.Tipo.Numero);
                                break;
                            }
                            else//Default si no se encontro ninguna coincidencia
                            {//Marcar error
                                auxiliarLexico += caracter;
                                agregarToken(Token.Tipo.Error);
                            }
                            break;
                        case 1://algun error
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Error);
                            break;
                        default://rectifiacion si hay error
                            auxiliarLexico += caracter;
                            agregarToken(Token.Tipo.Error);
                            break;
                    }
                }
            }

                return Salida;

        }

        public void agregarToken(Token.Tipo tipo)//Agrego tokens a la lista
        {
            Salida.AddLast(new Token(tipo, auxiliarLexico));
            auxiliarLexico = "";
            estado = 0;
        }
        public void imprimirListaToken(LinkedList<Token> lista)//Se imprime en consola los resultados
        {
            foreach (Token item in lista)
            {
                Console.WriteLine(item.GetTipo() + " <--> " + item.Getval());
            }
        }
    }
}
