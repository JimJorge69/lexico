using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexico
{
    class Token
    {
        public enum Tipo
        {
            Error,
            ParentesisIzquierdo,
            ParentesisDerecho,
            LlaveIzquierda,
            LlaveDerecha,
            OperadorSuma,
            OperadorMultiplicador,
            OperadorResta,
            NumeroDecimal,
            CorcheteDerecho,
            CorcheteIzquierdo,
            OperadorDivision,
            Numero,
            NumeroNegativo
        }
        private Tipo tipoToken;
        private String valor;

        public Token(Tipo TipoDelToken, string val)
        {
            this.tipoToken = TipoDelToken;
            this.valor = val;
        }
        public String Getval()
        {
            return valor;
        }
        public String GetID()
        {
            return this.tipoToken.GetHashCode().ToString();
        }
        public String GetTipo()
        {
            switch (tipoToken)
            {
                case Tipo.Error:/**/
                    return "Error";
                case Tipo.ParentesisIzquierdo:/* ( */
                    return "Parentesis Izquierdo";
                case Tipo.ParentesisDerecho:/* ) */
                    return "Parentesis Derecho";
                case Tipo.LlaveIzquierda:/* { */
                    return "Llave Izquierda";
                case Tipo.LlaveDerecha:/* } */
                    return "Llave Derecha";
                case Tipo.OperadorSuma:/* + */
                    return "Operador Suma";
                case Tipo.OperadorMultiplicador:/* * */
                    return "Operador Multiplicador";
                case Tipo.OperadorResta:/* - */
                    return "Operador Resta";
                case Tipo.NumeroDecimal:/* Numeros como 1.1 etc.*/
                    return "Numero Decimal";
                case Tipo.CorcheteIzquierdo: /* [ */
                    return "Corchete Izquierdo";
                case Tipo.CorcheteDerecho: /* ] */
                    return "Corchete Derecho";
                case Tipo.OperadorDivision: /* / */
                    return "Operador Division";
                case Tipo.Numero: /* numero 1 235456789*/
                    return "Numero";
                default:
                    return "";
            }
        }
    }
}