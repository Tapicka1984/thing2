using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader cti = new StreamReader("Sport.txt");

            FileStream data = new FileStream("znaky.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter zapis = new BinaryWriter(data, Encoding.GetEncoding("UTF-8"));

            int osc = 0;
            string jmeno = "";
            string prijmeni = "";
            char pohlavi;
            int vyska = 0;
            int hmotnost = 0;

            while (!cti.EndOfStream)
            {
                string[] pole = (cti.ReadLine()).Split(';');
                osc = int.Parse(pole[0]);
                jmeno = pole[1];
                prijmeni = pole[2];
                char[] pole1 = pole[3].ToCharArray();
                pohlavi = pole1[0];
                vyska = int.Parse(pole[4]);
                hmotnost = int.Parse(pole[5]);

                zapis.Write(osc);
                zapis.Write(jmeno);
                zapis.Write(prijmeni);
                zapis.Write(pohlavi);
                zapis.Write(vyska);
                zapis.Write(hmotnost);
            }

            BinaryReader ctiB = new BinaryReader(data, Encoding.GetEncoding("UTF-8"));
            ctiB.BaseStream.Position = 0;
            while (ctiB.BaseStream.Position < ctiB.BaseStream.Length)
            {
                int readOsc = ctiB.ReadInt32();
                string readJmeno = ctiB.ReadString();
                string readPrijmeni = ctiB.ReadString();
                char readpohlavi = ctiB.ReadChar();
                int readVyska = ctiB.ReadInt32();
                int readHmotnost = ctiB.ReadInt32();

                listBox1.Items.Add(readOsc + " " + readJmeno + " " + readPrijmeni + "" + readpohlavi + " " + readVyska + " " + readHmotnost);
            }
            cti.Close();
            ctiB.Close();
            data.Close();
        }
    }
}
