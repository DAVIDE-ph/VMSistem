using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSistem.Class
{
    public class Gval
    {
        private static string nomevisito = "";
        private static string cognomevisito = "";
        private static string invisita = "";
        private static DateTime ingresso ;
        private static DateTime uscita;
        private static DateTime indata;
        private static string messaggio;


        public static string Nomevisitor { get { return nomevisito; } set { nomevisito = value; } }
        public static string Cognomevisitor { get { return cognomevisito; } set { cognomevisito = value; } }
        public static string Invisita { get { return invisita; } set { invisita = value; } }
        public static DateTime Ingresso { get { return ingresso; } set { ingresso = value; } }
        public static DateTime Uscita { get { return uscita; } set { uscita = value; } }
        public static DateTime Indata { get { return indata; } set { indata = value; } }
        public static string Messaggio { get { return messaggio; } set { messaggio = value; } }

    }
}
