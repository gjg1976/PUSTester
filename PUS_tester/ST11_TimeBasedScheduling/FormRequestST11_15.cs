using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PUS_tester
{
    public partial class FormRequestST11_15 : Form
    {

        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST11_15()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count == 4)
            {
                    Byte[] payload = { new_payload[0], new_payload[1], new_payload[2], new_payload[3] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    UInt32 offsetTime = BitConverter.ToUInt32(payload, 0);
                    numericUpDownOffset.Value = offsetTime;
            }

        }

        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        void updatePayloadAndGUI()
        {
            payload.Clear();

            byte[] bytesOffset = BitConverter.GetBytes(decimal.ToUInt32(numericUpDownOffset.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytesOffset);
            payload.Add(bytesOffset[0]);
            payload.Add(bytesOffset[1]);
            payload.Add(bytesOffset[2]);
            payload.Add(bytesOffset[3]);

            string logPayload = "";//!< Crea una variable string temporal para el log Tx RS422 de la GUI
            int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
            logPayload += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
            for (; hcmd < payload.Count;)
            {
                byte _b = payload[hcmd];//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
                logPayload += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                if (++hcmd % 16 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                {
                    logPayload += Environment.NewLine;//!< Se debe pasar a una nueva linea
                    logPayload += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                    continue;//!< Continua con el proximo byte
                }
                else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                {
                    logPayload += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                }
            }
            textBoxPayload.Text = logPayload + Environment.NewLine;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            new_payload.Clear();
            new_payload.AddRange(payload);
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
    }
}
