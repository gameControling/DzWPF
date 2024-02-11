using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Serves
    {
        string ser;
        string log;
        string pas;

        public Serves(string ser, string log, string pas)
        {
            this.ser = ser;
            this.log = log;
            this.pas = pas;
        }

        public Serves(string[] str)
        {
            this.ser = str[0];
            this.log = str[1];
            this.pas = str[2];
        }

        public Serves() { }

        public string Ser { get { return ser; } set { ser = value; } }
        public string Log { get { return log; } set { log = value; } }
        public string Pas { get { return pas; } set {  pas = value; } }

        public override string ToString()
        {
            return ser + " " + log + " " + pas;
        }
    }
}
