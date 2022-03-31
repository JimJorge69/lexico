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
        private int parentesisD, parentesisI, LlaveD, LlaveI, CorcheteD, CorcheteI, mas, menos, multi, divi, valida, errorInicial;

        public LinkedList<Token> escanear(String entrada)
        {
            //Se declaran las variables que inicien limpias
            parentesisD = 0; parentesisI = 0; LlaveD = 0; LlaveI = 0; // Variables para identificar validacion
            CorcheteD = 0; CorcheteI = 0; mas = 0; menos = 0; multi = 0; divi = 0; valida = 0;errorInicial = 0;
            Char caracter;
            //Se inicia un siclo para la verificacion de la operacion sea correcta
            for (int i = 0; i < entrada.Length; i++)
            {

                caracter = entrada.ElementAt(i);
                int variable = (int)Char.GetNumericValue(caracter);// Se cambia a enteros para que valide los errores
                if (i == 0 && caracter == ')' || i == 0 && caracter == '}' || i == 0 && caracter == ']')
                {
                    errorInicial = 1;
                }
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
                else if (caracter == '+')//Operador mas
                {
                    if (valida >= 1)
                        mas += 1;
                    else
                        valida += 1;
                }
                else if (caracter == '-')//Operador menos
                {
                    if (valida >= 1)
                        menos += 1;
                    else
                        valida += 1;
                }
                else if (caracter == '*')//Operador multiplicacion
                {
                    if (valida >= 1)
                        multi += 1;
                    else
                        valida += 1;
                }
                else if (caracter == '/')//Operador division
                {
                    if (valida >= 1)
                        multi += 1;
                    else
                        valida += 1;
                }
            }
            //Suma de todas las llaves encontradas y verificar si es correcta 
            int sumaTodos = parentesisD + parentesisI + LlaveD + LlaveI + CorcheteD + CorcheteI;
            if (mas >= 1 || menos >= 1 || multi >= 1 || divi >= 1 || errorInicial == 1)//Valida que no alla mas de dos signos de operacion seguidos
            {
                MessageBox.Show("Operacion Mal", "¡UPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Valida que los parentisis coincidan 
                if ((parentesisD % 2) == 0 && (parentesisI % 2) == 0 || (LlaveD % 2) == 0 && (LlaveI % 2) == 0 || (CorcheteD % 2) == 0 && (CorcheteI % 2) == 0)
                {
                    if ((sumaTodos % 2) == 0)//Se valide que en la suma numero par para asi verificar que todo este bien
                    {
                        //Si se valida se empieza a dividir letra por letra oh caracter y enlistar en una tabla que es lo que se introdujo
                        MessageBox.Show("Operacion Correcta", "¡Bien!");
                    }
                    else
                    {
                        MessageBox.Show("Operacion Mal", "¡UPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Operacion Mal", "¡UPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Salida;
        }
    }
}
