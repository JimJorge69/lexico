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
                // se declara cada elemento del string para extrar con elementAt
                letra = entrada.ElementAt(ii);
                
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

            for (int ii = 0; ii < entrada.Length; ii++)
            {
                Console.WriteLine(encriptar[ii]);
            }
            Console.WriteLine();

            int[] encriptado = new int[entrada.Length];

            int contador = 1;

            int[] p1 = new int[3]; 
            int[] p2 = new int[3]; 
            int[] p3 = new int[3];

            //Se encripta
            for (int ii = 0; ii < entrada.Length; ii++)
            {
                if (contador==1)
                {
                    p1[0] = encriptar[ii] * 1;
                    p2[0] = encriptar[ii] * 2;
                    p3[0] = encriptar[ii] * 1;
                }
                else if (contador==2)
                {
                    p1[1] = encriptar[ii] * 0;
                    p2[1] = encriptar[ii] * (-1);
                    p3[1] = encriptar[ii] * 3;
                }
                else if (contador==3)
                {
                    p1[2] = encriptar[ii] * 2;
                    p2[2] = encriptar[ii] * 1;
                    p3[2] = encriptar[ii] * 0;
                                                   
                    encriptado[ii - 2] = p1[0] + p1[1] + p1[2];
                    encriptado[ii - 1] = p2[0] + p2[1] + p2[2];
                    encriptado[ii] = p3[0] + p3[1] + p3[2];

                    contador = 0;
                    Console.WriteLine();
                }
                contador += 1;
            }
            //Imprimo resultados encriptados
            Console.WriteLine();
            for (int ii = 0; ii < entrada.Length; ii++)
            {
                Console.WriteLine(encriptado[ii]);
            }

            //Desencriptar

            int[] Desencriptar = new int[entrada.Length];

            for (int ii = 0; ii < entrada.Length; ii++)
            {
                if (contador == 1)
                {
                    p1[0] = encriptado[ii] * 1;
                    p2[0] = encriptado[ii] * 2;
                    p3[0] = encriptado[ii] * 1;
                }
                else if (contador == 2)
                {
                    p1[1] = encriptado[ii] * 0;
                    p2[1] = encriptado[ii] * (-1);
                    p3[1] = encriptado[ii] * 3;
                }
                else if (contador == 3)
                {
                    p1[2] = encriptado[ii] * 2;
                    p2[2] = encriptado[ii] * 1;
                    p3[2] = encriptado[ii] * 0;

                    Desencriptar[ii] = p3[0] + p3[1] + p3[2];


                    contador = 0;
                    Console.WriteLine();
                }
                contador += 1;
            }
            //Imprimo resultados Desencriptados
            Console.WriteLine();
            for (int ii = 0; ii < entrada.Length; ii++)
            {
                Console.WriteLine(encriptar[ii]);
            }
            return Salida;
        }
    }
}
