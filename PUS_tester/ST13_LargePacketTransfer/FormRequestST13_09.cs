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
    public partial class FormRequestST13_09 : Form
    {
        public List<NumericUpDown> structuresList = new List<NumericUpDown>();
        public List<Label> structuresLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;

        public FormRequestST13_09()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if (new_payload.Count > 0)
            {
                ushort ID = 0;
                var currentValueFieldID = numericUpDownID.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldID != null)
                {
                    Byte[] payload = { new_payload[0], new_payload[1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    ID = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldID.SetValue(numericUpDownID, Convert.ToDecimal(ID));
                    numericUpDownID.Text = ID.ToString();
                }
                ushort seq = 0;
                var currentValueField1 = numericUpDown1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueField1 != null)
                {
                    Byte[] payload = { new_payload[2], new_payload[3] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    seq = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldID.SetValue(numericUpDown1, Convert.ToDecimal(seq));
                    numericUpDown1.Text = seq.ToString();
                }

                string logPayload = "";
                for (int i = 4; i < new_payload.Count; i++)
                {
                    logPayload += string.Format("{0:x2}", new_payload[i]);
                }
                textBoxFunctionData.Text = logPayload;
            }
        }

        void updatePayload()
        {
            if(Regex.IsMatch(textBoxFunctionData.Text, @"^[A-Fa-f0-9]*$") == false)
                return;
            payload.Clear();

            byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownID.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            payload.Add(bytes[0]);
            payload.Add(bytes[1]);

            byte[] bytesSeq = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDown1.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytesSeq);
            payload.Add(bytesSeq[0]);
            payload.Add(bytesSeq[1]);

            int i = 0;
            if (textBoxFunctionData.Text.Length % 2 == 0)
            {
                byte[] values = new byte[textBoxFunctionData.Text.Length / 2];
                foreach (string s in SplitInParts(textBoxFunctionData.Text, 2))
                    values[i++] = Convert.ToByte(s, 16);
                for (i = 0; i < values.Length; i++)
                    payload.Add(values[i]);

            }

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

        private void textBoxFunctionArg_TextChanged(object sender, EventArgs e)
        {
            updatePayload();
        }
        public IEnumerable<String> SplitInParts(String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        private void numericUpDownID_ValueChanged(object sender, EventArgs e)
        {
            updatePayload();
        }
    }
}
