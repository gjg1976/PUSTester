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

    public partial class FormRequestST20_03 : Form
    {
        public List<NumericUpDown> parametersList = new List<NumericUpDown>();
        public List<Label> parametersLabelList = new List<Label>();
        public List<TextBox> parametersValuesList = new List<TextBox>();
        public List<Label> parametersValuesLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST20_03()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;
            updatePayload();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != parametersList.Count)
            {
                if (numericUpDown1.Value < parametersList.Count)
                {
                    for (int i = parametersList.Count - 1; numericUpDown1.Value < parametersList.Count; i--)
                    {
                        this.Controls.Remove(parametersList[i]);
                        parametersList.Remove(parametersList[i]);
                        this.Controls.Remove(parametersLabelList[i]);
                        parametersLabelList.Remove(parametersLabelList[i]);
                        this.Controls.Remove(parametersValuesList[i]);
                        parametersValuesList.Remove(parametersValuesList[i]);
                        this.Controls.Remove(parametersValuesLabelList[i]);
                        parametersValuesLabelList.Remove(parametersValuesLabelList[i]);
                    }
                }
                else if (numericUpDown1.Value > parametersList.Count)
                {
                    for (int i = parametersList.Count; numericUpDown1.Value > parametersList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Parameter ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        tmpLabel.Location = new System.Drawing.Point(100, i * 30 + 182);
                        parametersLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.Location = new System.Drawing.Point(200, i * 30 + 180);
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        parametersList.Add(tmp);
                        this.Controls.Add(tmp);

                        Label tmpValuesLabel = new Label();
                        tmpValuesLabel.Text = "Parameter Value #" + i.ToString();
                        tmpValuesLabel.Size = new System.Drawing.Size(100, 20);
                        tmpValuesLabel.Location = new System.Drawing.Point(270, i * 30 + 182);
                        parametersValuesLabelList.Add(tmpValuesLabel);
                        this.Controls.Add(tmpValuesLabel);
                        TextBox tmpValues = new TextBox();
                        tmpValues.Size = new System.Drawing.Size(68, 20);
                        tmpValues.Location = new System.Drawing.Point(370, i * 30 + 180);
                        tmpValues.TextChanged += new System.EventHandler(this.textBox_ValueChanged);
                        parametersValuesList.Add(tmpValues);
                        this.Controls.Add(tmpValues);

                    }
                }
                updatePayload();
            }
        }
        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
        {
            updatePayload();
        }
        private void textBox_ValueChanged(object sender, EventArgs e)
        {
            updatePayload();
        }
        void updatePayload()
        {
            for (int j = 0; j < parametersValuesList.Count; j++)
            {
                if (Regex.IsMatch(parametersValuesList[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                        parametersValuesList[j].Text.Length % 2 != 0)
                    return;
            }
            payload.Clear();
            byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDown1.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            payload.Add(bytes[0]);
            payload.Add(bytes[1]);
            for (int j = 0; j < parametersList.Count; j++)
            {
                byte[] bytesParam = BitConverter.GetBytes((ushort)decimal.ToUInt16(parametersList[j].Value));
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesParam);
                payload.Add(bytesParam[0]);
                payload.Add(bytesParam[1]);
                int i = 0;
                byte[] values = new byte[parametersValuesList[j].Text.Length / 2];
                foreach (string s in SplitInParts(parametersValuesList[j].Text, 2))
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
        public IEnumerable<String> SplitInParts(String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
}
