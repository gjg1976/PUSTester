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
    public partial class FormRequestST15_17 : Form
    {
        public List<TextBox> storeList = new List<TextBox>();
        public List<Label> storeLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST15_17()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count > 0)
            {
                int offset = 0;
                Byte[] payloadN1 = { new_payload[offset], new_payload[offset + 1] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadN1);
                ushort N1 = BitConverter.ToUInt16(payloadN1, 0);

                var currentValueFieldN1 = numericUpDown1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN1 != null)
                {
                    currentValueFieldN1.SetValue(numericUpDown1, Convert.ToDecimal(N1));
                    numericUpDown1.Text = N1.ToString();
                }
                offset = 2;
                for (int i = 0; i < N1; i++)
                 {
                    Byte[] storeID = new byte[Properties.Settings.Default.ST15StoresIDSize];
                    for (int j = 0; j < Properties.Settings.Default.ST15StoresIDSize; j++, offset++)
                    {
                        storeID[j] = new_payload[offset];
                    }

                    Label tmpLabel = new Label();
                    tmpLabel.Text = "Store ID #" + i.ToString();
                    tmpLabel.Size = new System.Drawing.Size(80, 20);
                    tmpLabel.Location = new System.Drawing.Point(100, i * 30 + 182);
                    storeLabelList.Add(tmpLabel);
                    this.Controls.Add(tmpLabel);
                    TextBox tmp = new TextBox();
                    tmp.MaxLength = Properties.Settings.Default.ST15StoresIDSize;
                    tmp.Size = new System.Drawing.Size(120, 20);
                    tmp.Location = new System.Drawing.Point(190, i * 30 + 180);
                    tmp.Text = System.Text.Encoding.UTF8.GetString(storeID);
                    tmp.TextChanged += new System.EventHandler(this.textBoxGeneric_TextChanged);
                    storeList.Add(tmp);
                    this.Controls.Add(tmp);
                }
                
            }
            updatePayload();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != storeList.Count)
            {
                if (numericUpDown1.Value < storeList.Count) {
                    for (int i = storeList.Count-1; numericUpDown1.Value < storeList.Count; i--)
                    {
                        this.Controls.Remove(storeList[i]);
                        storeList.Remove(storeList[i]);
                        this.Controls.Remove(storeLabelList[i]);
                        storeLabelList.Remove(storeLabelList[i]);
                    }
                } else if (numericUpDown1.Value > storeList.Count){
                    for (int i = storeList.Count; numericUpDown1.Value > storeList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Store ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(80, 20);
                        tmpLabel.Location = new System.Drawing.Point(100, i * 30 + 182);
                        storeLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        TextBox tmp = new TextBox();
                        tmp.MaxLength = Properties.Settings.Default.ST15StoresIDSize;
                        tmp.Size = new System.Drawing.Size(120, 20);
                        tmp.Location = new System.Drawing.Point(190, i * 30 + 180);
                        tmp.TextChanged += new System.EventHandler(this.textBoxGeneric_TextChanged);
                        storeList.Add(tmp);
                        this.Controls.Add(tmp);
                    }
                }
                updatePayload();
            }
        }
        private void textBoxGeneric_TextChanged(object sender, EventArgs e)
        {
            updatePayload();
        }

        void updatePayload()
        {
            payload.Clear();
            UInt16 count = decimal.ToUInt16(numericUpDown1.Value);
            payload.Add((byte)(count >> 8));
            payload.Add((byte)(count & 0xff));
            for (int j = 0; j < count; j++) {
                byte[] bytes = Encoding.ASCII.GetBytes(storeList[j].Text);
                int i = 0;
                for (; i < bytes.Length; i++)
                {
                    payload.Add(bytes[i]);
                }
                for (; i < Properties.Settings.Default.ST15StoresIDSize; i++)
                {
                    payload.Add(0);
                }
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
