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
    public partial class FormRequestST15_24 : Form
    {
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST15_24()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;
            comboBoxType.SelectedIndex = 0;
            if (new_payload.Count > 0)
            {
                int offset = 0;
                comboBoxType.SelectedIndex = new_payload[offset++];

                Byte[] payloadTimeTag1 = { new_payload[offset], new_payload[offset + 1], new_payload[offset + 2], new_payload[offset + 3] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadTimeTag1);
                UInt32 timeTag1 = BitConverter.ToUInt32(payloadTimeTag1, 0);
                offset += 4;
                var currentValueFieldTimeTag1 = numericUpDownTag1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldTimeTag1 != null)
                {
                    currentValueFieldTimeTag1.SetValue(numericUpDownTag1, Convert.ToDecimal(timeTag1));
                    numericUpDownTag1.Text = timeTag1.ToString();
                }

                Byte[] payloadTimeTag2 = { new_payload[offset], new_payload[offset + 1], new_payload[offset + 2], new_payload[offset + 3] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadTimeTag2);
                UInt32 timeTag2 = BitConverter.ToUInt32(payloadTimeTag2, 0);
                offset += 4;
                var currentValueFieldTimeTag2 = numericUpDownTag1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldTimeTag2 != null)
                {
                    currentValueFieldTimeTag2.SetValue(numericUpDownTag2, Convert.ToDecimal(timeTag2));
                    numericUpDownTag2.Text = timeTag2.ToString();
                }

                Byte[] ToName = new byte[Properties.Settings.Default.ST15StoresIDSize];
                for (int i = 0; i < Properties.Settings.Default.ST15StoresIDSize; i++, offset++)
                {
                    ToName[i] = new_payload[offset];
                }

                textBoxToName.Text = System.Text.Encoding.UTF8.GetString(ToName);

                Byte[] FromName = new byte[Properties.Settings.Default.ST15StoresIDSize];
                for (int i = 0; i < Properties.Settings.Default.ST15StoresIDSize; i++, offset++)
                {
                    FromName[i] = new_payload[offset];
                }

                textBoxFromName.Text = System.Text.Encoding.UTF8.GetString(FromName);
            }
        }

        void updatePayloadAndGUI()
        {
            Int32 offset = 150;
            payload.Clear();
            payload.Add((byte)(comboBoxType.SelectedIndex));

            UInt32 timeTag1 = decimal.ToUInt32(numericUpDownTag1.Value);
            payload.Add((byte)(timeTag1 >> 24));
            payload.Add((byte)(timeTag1 >> 16));
            payload.Add((byte)(timeTag1 >> 8));
            payload.Add((byte)(timeTag1 & 0xff));

            UInt32 timeTag2 = decimal.ToUInt32(numericUpDownTag2.Value);
            payload.Add((byte)(timeTag2 >> 24));
            payload.Add((byte)(timeTag2 >> 16));
            payload.Add((byte)(timeTag2 >> 8));
            payload.Add((byte)(timeTag2 & 0xff));

            byte[] bytesTo = Encoding.ASCII.GetBytes(textBoxToName.Text);
            int i = 0;
            for (; i < bytesTo.Length; i++)
            {
                payload.Add(bytesTo[i]);
            }
            for (; i < Properties.Settings.Default.ST15StoresIDSize; i++)
            {
                payload.Add(0);
            }
            byte[] bytesFrom = Encoding.ASCII.GetBytes(textBoxFromName.Text);
            i = 0;
            for (; i < bytesFrom.Length; i++)
            {
                payload.Add(bytesFrom[i]);
            }
            for (; i < Properties.Settings.Default.ST15StoresIDSize; i++)
            {
                payload.Add(0);
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

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        private void numericUpDownTag1_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        private void numericUpDownTag2_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        private void textBoxToName_TextChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        private void textBoxFromName_TextChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
    }
}
