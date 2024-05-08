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
    public partial class FormRequestST21_01 : Form
    {
        public List<NumericUpDown> delayList = new List<NumericUpDown> ();
        public List<Label> delayLabelList = new List<Label>();
        public List<TextBox> requestList = new List<TextBox>();
        public List<Label> requestLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST21_01()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count > 0)
            {
                int offset = 0;
                Byte[] functionName = new byte[Properties.Settings.Default.ST21StringSize];
                for (int i = 0; i < Properties.Settings.Default.ST21StringSize; i++, offset++)
                {
                    functionName[i] = new_payload[offset];
                }

                textBoxFunctionName.Text = System.Text.Encoding.UTF8.GetString(functionName);
                ushort N = 0;
                var currentValueFieldN = numericUpDownN.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN != null)
                {
                    Byte[] payload = { new_payload[offset], new_payload[offset + 1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    N = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldN.SetValue(numericUpDownN, Convert.ToDecimal(N));
                    numericUpDownN.Text = N.ToString();
                }

                offset += 2;
                for (int i = 0; i < N; i++)
                {
                    ushort packetDataLength = (ushort)((new_payload[offset + 4] << 8) | new_payload[offset + 5]);
                    packetDataLength += 1;

                    if (packetDataLength < (Constants.ECCS_SECONDARY_TC_HEADER + Constants.ECSS_CRC_TAIL))
                        return;

                    Byte[] payloadLen = new Byte[Constants.ECCS_PRIMARY_HEADER + packetDataLength];
                    for (int h = 0; h < Constants.ECCS_PRIMARY_HEADER + packetDataLength; h++)
                    {
                        payloadLen[h] = new_payload[offset++];
                    }

                    string dataPayload = "";
                    for (int h = 0; h < payloadLen.Length; h++)
                    {
                        dataPayload += string.Format("{0:x2}", payloadLen[h]);
                    }
                    Byte[] payloaddelay = { new_payload[offset], new_payload[offset + 1], new_payload[offset + 2], new_payload[offset + 3]};
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(payloaddelay);
                     }
                    UInt32 delay = BitConverter.ToUInt32(payloaddelay, 0);

                    offset += 4;
                    Label tmpLabel = new Label();
                    tmpLabel.Text = "Delay #" + i.ToString();
                    tmpLabel.Size = new System.Drawing.Size(100, 20);
                    tmpLabel.Location = new System.Drawing.Point(60, i * 60 + 242);
                    delayLabelList.Add(tmpLabel);
                    this.Controls.Add(tmpLabel);
                    NumericUpDown tmpdelay = new NumericUpDown();
                    tmpdelay.Maximum = new decimal(new int[] {
                            2147483647,
                            0,
                            0,
                            0});
                    tmpdelay.Size = new System.Drawing.Size(68, 20);
                    tmpdelay.Location = new System.Drawing.Point(190, i * 60 + 240);
                    tmpdelay.Value = delay;
                    tmpdelay.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    delayList.Add(tmpdelay);
                    this.Controls.Add(tmpdelay);



                    Label tmpDataLabel = new Label();
                    tmpDataLabel.Text = "Request #" + i.ToString();
                    tmpDataLabel.Size = new System.Drawing.Size(50, 20);
                    tmpDataLabel.Location = new System.Drawing.Point(60, i * 60 + 212);
                    requestLabelList.Add(tmpDataLabel);
                    this.Controls.Add(tmpDataLabel);
                    TextBox tmpData = new TextBox();
                    tmpData.Text = dataPayload;
                    tmpData.Size = new System.Drawing.Size(250, 20);
                    tmpData.Location = new System.Drawing.Point(190, i * 60 + 210);
                    tmpData.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                    requestList.Add(tmpData);
                    this.Controls.Add(tmpData);
                }
            }
            updatePayloadAndGUI();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        private void textBoxFunctionName_TextChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        void updatePayloadAndGUI()
        {
            for(int j = 0; j < delayList.Count; j++)
            {
                if (Regex.IsMatch(requestList[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                    requestList[j].Text.Length % 2 != 0)
                    return;
                if (requestList[j].Text.Length / 2 < Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + Constants.ECSS_CRC_TAIL)
                    return;
                byte[] values = new byte[requestList[j].Text.Length / 2];
                int h = 0;
                foreach (string s in SplitInParts(requestList[j].Text, 2))
                    values[h++] = Convert.ToByte(s, 16);
                ushort packetDataLength = (ushort)((values[4] << 8) | values[5]);
                packetDataLength += 1;
                if (requestList[j].Text.Length / 2 != Constants.ECCS_PRIMARY_HEADER + packetDataLength)
                    return;
            }
            payload.Clear();
            byte[] bytes = Encoding.ASCII.GetBytes(textBoxFunctionName.Text);
            int i = 0;
            for (; i < bytes.Length; i++)
            {
                payload.Add(bytes[i]);
            }
            for (; i < Properties.Settings.Default.ST21StringSize; i++)
            {
                payload.Add(0);
            }
            byte[] bytesN = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownN.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytesN);
            payload.Add(bytesN[0]);
            payload.Add(bytesN[1]);
            
            for (int j = 0; j < numericUpDownN.Value; j++)
            {
                int h = 0;
                ushort length = Convert.ToUInt16(requestList[j].Text.Length / 2);
                byte[] values = new byte[requestList[j].Text.Length / 2];
                foreach (string s in SplitInParts(requestList[j].Text, 2))
                    values[h++] = Convert.ToByte(s, 16);
                for (h = 0; h < values.Length; h++)
                    payload.Add(values[h]);

                UInt32 delay = decimal.ToUInt32(delayList[j].Value);
                payload.Add((byte)(delay >> 24));
                payload.Add((byte)(delay >> 16));
                payload.Add((byte)(delay >> 8));
                payload.Add((byte)(delay & 0xff));

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

        private void numericUpDownN_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownN.Value != delayList.Count)
            {
                if (numericUpDownN.Value < delayList.Count)
                {
                    for (int i = delayList.Count - 1; numericUpDownN.Value < delayList.Count; i--)
                    {
                        this.Controls.Remove(delayList[i]);
                        delayList.Remove(delayList[i]);

                        this.Controls.Remove(delayLabelList[i]);
                        delayLabelList.Remove(delayLabelList[i]);

                        this.Controls.Remove(requestList[i]);
                        requestList.Remove(requestList[i]);

                        this.Controls.Remove(requestLabelList[i]);
                        requestLabelList.Remove(requestLabelList[i]);
                    }
                }
                else if (numericUpDownN.Value > delayList.Count)
                {
                    for (int i = delayList.Count; numericUpDownN.Value > delayList.Count; i++)
                    {
                        Label tmpDataLabel = new Label();
                        tmpDataLabel.Text = "Request #" + i.ToString();
                        tmpDataLabel.Size = new System.Drawing.Size(100, 20);
                        tmpDataLabel.Location = new System.Drawing.Point(60, i * 60 + 212);
                        requestLabelList.Add(tmpDataLabel);
                        this.Controls.Add(tmpDataLabel);
                        TextBox tmpData = new TextBox();
                        tmpData.Size = new System.Drawing.Size(250, 20);
                        tmpData.Location = new System.Drawing.Point(190, i * 60 + 210);
                        tmpData.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                        requestList.Add(tmpData);
                        this.Controls.Add(tmpData);

                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Delay #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        tmpLabel.Location = new System.Drawing.Point(60, i * 60 + 242);
                        delayLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmpdelay = new NumericUpDown();
                        tmpdelay.Maximum = new decimal(new int[] {
                            2147483647,
                            0,
                            0,
                            0});
                        tmpdelay.Size = new System.Drawing.Size(68, 20);
                        tmpdelay.Location = new System.Drawing.Point(190, i * 60 + 240);
                        tmpdelay.Value = 0;
                        tmpdelay.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        delayList.Add(tmpdelay);
                        this.Controls.Add(tmpdelay);


                    }
                }
                updatePayloadAndGUI();
            }
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

        private void textBoxFunctionName_TextChanged_1(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
    }
}
