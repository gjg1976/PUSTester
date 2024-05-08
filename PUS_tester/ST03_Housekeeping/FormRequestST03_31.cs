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

namespace PUS_tester
{

    public partial class FormRequestST03_31 : Form
    {
        public List<NumericUpDown> structuresList = new List<NumericUpDown>();
        public List<Label> structuresLabelList = new List<Label>();
        public List<NumericUpDown> intervalList = new List<NumericUpDown>();
        public List<Label> intervalLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST03_31()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if (new_payload.Count > 0)
            {
                if (new_payload.Count == new_payload[0] * 3 + 1)
                {
                    var currentValueField = numericUpDown1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (currentValueField != null)
                    {
                        currentValueField.SetValue(numericUpDown1, Convert.ToDecimal(new_payload[0]));
                        numericUpDown1.Text = new_payload[0].ToString();
                    }
                    for (int i = 1, j = 0; i < new_payload[0] * 3 + 1; i+=3, j++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Structure ID #" + j.ToString();
                        tmpLabel.Size = new System.Drawing.Size(80, 20);
                        tmpLabel.Location = new System.Drawing.Point(100, j * 60 + 182);
                        structuresLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            255,
                            0,
                            0,
                            0});
                        tmp.Value = new_payload[i];
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.Location = new System.Drawing.Point(190, j * 60 + 180);
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        structuresList.Add(tmp);
                        this.Controls.Add(tmp);

                        Byte[] payload = { new_payload[i+1], new_payload[i+2] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(payload);
                        ushort interval = BitConverter.ToUInt16(payload, 0);

                        Label tmpLabelInt = new Label();
                        tmpLabelInt.Text = "Interval #" + j.ToString();
                        tmpLabelInt.Size = new System.Drawing.Size(80, 20);
                        tmpLabelInt.Location = new System.Drawing.Point(100, j * 60 + 212);
                        intervalLabelList.Add(tmpLabelInt);
                        this.Controls.Add(tmpLabelInt);
                        NumericUpDown tmpInt = new NumericUpDown();
                        tmpInt.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpInt.Value = interval;
                        tmpInt.Size = new System.Drawing.Size(68, 20);
                        tmpInt.Location = new System.Drawing.Point(190, j * 60 + 210);
                        tmpInt.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        intervalList.Add(tmpInt);
                        this.Controls.Add(tmpInt);
                    }
                }
            }
            updatePayload();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != structuresList.Count)
            {
                if (numericUpDown1.Value < structuresList.Count)
                {
                    for (int i = structuresList.Count - 1; numericUpDown1.Value < structuresList.Count; i--)
                    {
                        this.Controls.Remove(structuresList[i]);
                        structuresList.Remove(structuresList[i]);
                        this.Controls.Remove(structuresLabelList[i]);
                        structuresLabelList.Remove(structuresLabelList[i]);
                        this.Controls.Remove(intervalList[i]);
                        intervalList.Remove(intervalList[i]);
                        this.Controls.Remove(intervalLabelList[i]);
                        intervalLabelList.Remove(intervalLabelList[i]);
                    }
                }
                else if (numericUpDown1.Value > structuresList.Count)
                {
                    for (int i = structuresList.Count; numericUpDown1.Value > structuresList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Structure ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(80, 20);
                        tmpLabel.Location = new System.Drawing.Point(100, i * 60 + 182);
                        structuresLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            255,
                            0,
                            0,
                            0});
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.Location = new System.Drawing.Point(190, i * 60 + 180);
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        structuresList.Add(tmp);
                        this.Controls.Add(tmp);

                        Label tmpLabelInt = new Label();
                        tmpLabelInt.Text = "Interval #" + i.ToString();
                        tmpLabelInt.Size = new System.Drawing.Size(80, 20);
                        tmpLabelInt.Location = new System.Drawing.Point(100, i * 60 + 212);
                        intervalLabelList.Add(tmpLabelInt);
                        this.Controls.Add(tmpLabelInt);
                        NumericUpDown tmpInt = new NumericUpDown();
                        tmpInt.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpInt.Size = new System.Drawing.Size(68, 20);
                        tmpInt.Location = new System.Drawing.Point(190, i * 60 + 210);
                        tmpInt.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        intervalList.Add(tmpInt);
                        this.Controls.Add(tmpInt);
                    }
                }
                updatePayload();
            }
        }
        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
        {
            updatePayload();
        }

        void updatePayload()
        {
            payload.Clear();
            payload.Add(decimal.ToByte(numericUpDown1.Value));
            for (int i = 0; i < structuresList.Count; i++) { 
                payload.Add(decimal.ToByte(structuresList[i].Value));
                byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(intervalList[i].Value));
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytes);
                payload.Add(bytes[0]);
                payload.Add(bytes[1]);
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

    }
}
