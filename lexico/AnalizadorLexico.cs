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

        // asignacion de valor por letra
        private int a=1,b=2,c=3,d=4,e=5,f=6,g=7,h=8,i=9,j=10,k=11,l=12,m=13,n=14,ñ=15,o=16,p=17,q=18,r=19,s=20,t=21,u=22,v=23,w=24,x=25,y=26,z=27;
        
        public LinkedList<Token> escanear(String entrada)
        {

            Char letra;
            //Se inicia un siclo para la verificacion de la operacion sea correcta
            int [] encriptar = new int[entrada.Length];

            for (int ii = 0; ii < entrada.Length; ii++)
            {

                letra = entrada.ElementAt(ii);
                //int letra = (int)Char.GetNumericValue(caracter);// Se cambia a enteros para que valide los errores         
                switch (letra)
                {
                    case 'a':
                        encriptar[ii] = a;
                        break;
                    case 'b':
                        encriptar[ii] = b;
                        break;
                    case 'c':
                        encriptar[ii] = c;
                        break;
                    case 'd':
                        encriptar[ii] = d;
                        break;
                    case 'e':
                        encriptar[ii] = e;
                        break;
                    case 'f':
                        encriptar[ii] = f;
                        break;
                    case 'g':
                        encriptar[ii] = g;
                        break;
                    case 'h':
                        encriptar[ii] = h;
                        break;
                    case 'i':
                        encriptar[ii] = i;
                        break;
                    case 'j':
                        encriptar[ii] = j;
                        break;
                    case 'k':
                        encriptar[ii] = k;
                        break;
                    case 'l':
                        encriptar[ii] = l;
                        break;
                    case 'm':
                        encriptar[ii] = m;
                        break;
                    case 'n':
                        encriptar[ii] = n;
                        break;
                    case 'ñ':
                        encriptar[ii] = ñ;
                        break;
                    case 'o':
                        encriptar[ii] = o;
                        break;
                    case 'p':
                        encriptar[ii] = p;
                        break;
                    case 'q':
                        encriptar[ii] = q;
                        break;
                    case 'r':
                        encriptar[ii] = r;
                        break;
                    case 's':
                        encriptar[ii] = s;
                        break;
                    case 't':
                        encriptar[ii] = t;
                        break;
                    case 'u':
                        encriptar[ii] = u;
                        break;
                    case 'v':
                        encriptar[ii] = v;
                        break;
                    case 'w':
                        encriptar[ii] = w;
                        break;
                    case 'x':
                        encriptar[ii] = x;
                        break;
                    case 'y':
                        encriptar[ii] = y;
                        break;
                    case 'z':
                        encriptar[ii] = z;
                        break;
                    default:
                        // ningun valor recibido
                        break;
                }
            }
            int[] encriptado = new int[entrada.Length];
            int contador = 1,numero=0;
            int n1 = 0, n2 = 0, n3 = 0;

            /// encriptado
            for (int ii = 0; ii < entrada.Length; ii++)
            {

                Console.WriteLine(encriptar[ii]);
            }

            Console.WriteLine();

            for (int ii = 0; ii < entrada.Length; ii++)
            {
                if (contador==1)
                {
                    n1 = encriptar[ii] * 1;
                    n2 = encriptar[ii] * 0;
                    n3 = encriptar[ii] * 2;
                    encriptado[ii] = n1 + n2 + n3;
                }
                else if (contador==2)
                {
                    n1 = encriptar[ii] * 2;
                    n2 = encriptar[ii] * (-1);
                    n3 = encriptar[ii] * 1;
                    encriptado[ii] = n1 + n2 + n3;
                }
                else if (contador==3)
                {
                    n1 = encriptar[ii] * 1;
                    n2 = encriptar[ii] * 3;
                    n3 = encriptar[ii] * 0;
                    encriptado[ii] = n1 + n2 + n3;
                    contador = 0;
                }
                contador += 1;
                Console.WriteLine();
            }
            for (int ii = 0; ii < entrada.Length; ii++)
            {
                Console.WriteLine(encriptado[ii]);
            }
            return Salida;
        }
    }
}
