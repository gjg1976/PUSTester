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
    public partial class FormRequestST06_02 : Form
    {
        public List<TextBox> addressList = new List<TextBox> ();
        public List<Label> addressLabelList = new List<Label>();
        public List<TextBox> dataList = new List<TextBox>();
        public List<Label> dataLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST06_02()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count > 0)
            {
                var currentValueFieldMemID = numericUpDownMemID.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldMemID != null)
                {
                    currentValueFieldMemID.SetValue(numericUpDownMemID, Convert.ToDecimal(new_payload[0]));
                    numericUpDownMemID.Text = new_payload[0].ToString();
                }
                ushort N = 0;
                var currentValueFieldN = numericUpDownN.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN != null)
                {
                    Byte[] payload = { new_payload[1], new_payload[2] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    N = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldN.SetValue(numericUpDownN, Convert.ToDecimal(N));
                    numericUpDownN.Text = N.ToString();
                }

                ushort offset = 3;
                for (int i = 0; i < N; i++)
                {
                    Byte[] payload = { new_payload[offset], new_payload[offset + 1],
                                        new_payload[offset + 2], new_payload[offset + 3],
                                        new_payload[offset + 4], new_payload[offset + 5],
                                        new_payload[offset + 6], new_payload[offset + 7]};
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    Int64 paramID = BitConverter.ToInt64(payload, 0);
                    Label tmpLabel = new Label();
                    tmpLabel.Text = "Start Address #" + i.ToString();
                    tmpLabel.Size = new System.Drawing.Size(100, 20);
                    tmpLabel.Location = new System.Drawing.Point(40, i * 30 + 202);
                    addressLabelList.Add(tmpLabel);
                    this.Controls.Add(tmpLabel);
                    TextBox tmp = new TextBox();
                    tmp.MaxLength = 16;
                    tmp.Text = Convert.ToString(paramID, 16);
                    tmp.Size = new System.Drawing.Size(110, 20);
                    tmp.Location = new System.Drawing.Point(140, i * 30 + 200);
                    tmp.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                    addressList.Add(tmp);
                    this.Controls.Add(tmp);

                    Byte[] payloadLen = { new_payload[offset + 8], new_payload[offset + 9] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadLen);
                    UInt16 length = BitConverter.ToUInt16(payloadLen, 0);
                    offset += 10;
                    string dataPayload = "";
                    for (int h = 0; h < length; h++)
                    {
                        dataPayload += string.Format("{0:x2}", new_payload[offset++]);
                    }

                    Label tmpDataLabel = new Label();
                    tmpDataLabel.Text = "Data #" + i.ToString();
                    tmpDataLabel.Size = new System.Drawing.Size(50, 20);
                    tmpDataLabel.Location = new System.Drawing.Point(250, i * 30 + 202);
                    dataLabelList.Add(tmpDataLabel);
                    this.Controls.Add(tmpDataLabel);
                    TextBox tmpData = new TextBox();
                    tmpData.Text = dataPayload;
                    tmpData.Size = new System.Drawing.Size(250, 20);
                    tmpData.Location = new System.Drawing.Point(310, i * 30 + 200);
                    tmpData.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                    dataList.Add(tmpData);
                    this.Controls.Add(tmpData);
                    offset += 2;
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
            for(int j = 0; j < dataList.Count; j++)
            {
                if (addressList[j].Text.Length % 2 != 0)
                    return;

                if (Regex.IsMatch(dataList[j].Text, @"^[A-Fa-f0-9]*$") == false || 
                        dataList[j].Text.Length % 2 != 0) 
                    return;
                
                if (addressList[j].Text.Length < 16)
                {
                    string str = "";
                    for (int h = addressList[j].Text.Length; h < 16; h++)
                        str += "0";
                    str += addressList[j].Text;
                    addressList[j].Text = str;
                }
            }
            payload.Clear();
            payload.Add(decimal.ToByte(numericUpDownMemID.Value));

            byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownN.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            payload.Add(bytes[0]);
            payload.Add(bytes[1]);
            
            for (int j = 0; j < numericUpDownN.Value; j++)
            {
                int i = 0;
                byte[] valuesAddr = new byte[addressList[j].Text.Length / 2];
                foreach (string s in SplitInParts(addressList[j].Text, 2))
                    valuesAddr[i++] = Convert.ToByte(s, 16);
                for (i = 0; i < 8; i++)
                    payload.Add(valuesAddr[i]);

                ushort length = Convert.ToUInt16(dataList[j].Text.Length / 2);
                byte[] bytesLen = BitConverter.GetBytes(length);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesLen);
                payload.Add(bytesLen[0]);
                payload.Add(bytesLen[1]);

                i = 0;
                byte[] values = new byte[dataList[j].Text.Length / 2];
                foreach (string s in SplitInParts(dataList[j].Text, 2))
                    values[i++] = Convert.ToByte(s, 16);
                for (i = 0; i < values.Length; i++)
                    payload.Add(values[i]);

                ushort crc = calculateCRC(values);
                byte[] bytesCrc = BitConverter.GetBytes(crc);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesCrc);
                payload.Add(bytesCrc[0]);
                payload.Add(bytesCrc[1]);
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
            if (numericUpDownN.Value != addressList.Count)
            {
                if (numericUpDownN.Value < addressList.Count)
                {
                    for (int i = addressList.Count - 1; numericUpDownN.Value < addressList.Count; i--)
                    {
                        this.Controls.Remove(addressList[i]);
                        addressList.Remove(addressList[i]);

                        this.Controls.Remove(addressLabelList[i]);
                        addressLabelList.Remove(addressLabelList[i]);

                        this.Controls.Remove(dataList[i]);
                        dataList.Remove(dataList[i]);

                        this.Controls.Remove(dataLabelList[i]);
                        dataLabelList.Remove(dataLabelList[i]);
                    }
                }
                else if (numericUpDownN.Value > addressList.Count)
                {
                    for (int i = addressList.Count; numericUpDownN.Value > addressList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Start Address #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        tmpLabel.Location = new System.Drawing.Point(40, i * 30 + 202);
                        addressLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        TextBox tmp = new TextBox();
                        tmp.MaxLength = 16;
                        tmp.Text = "FFFFFFFFFFFFFFFF";
                        tmp.Size = new System.Drawing.Size(110, 20);
                        tmp.Location = new System.Drawing.Point(140, i * 30 + 200);
                        tmp.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                        addressList.Add(tmp);
                        this.Controls.Add(tmp);

                        Label tmpDataLabel = new Label();
                        tmpDataLabel.Text = "Data #" + i.ToString();
                        tmpDataLabel.Size = new System.Drawing.Size(50, 20);
                        tmpDataLabel.Location = new System.Drawing.Point(250, i * 30 + 202);
                        dataLabelList.Add(tmpDataLabel);
                        this.Controls.Add(tmpDataLabel);
                        TextBox tmpData = new TextBox();
                        tmpData.Size = new System.Drawing.Size(250, 20);
                        tmpData.Location = new System.Drawing.Point(310, i * 30 + 200);
                        tmpData.TextChanged += new System.EventHandler(this.textBoxFunctionName_TextChanged);
                        dataList.Add(tmpData);
                        this.Controls.Add(tmpData);
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
        private ushort calculateCRC(byte[] message)
        {
            // shift register contains all 1's initially (ECSS-E-ST-70-41C, Annex B - CRC and ISO checksum)
            ushort shiftReg = 0xFFFF;

            // CRC16-CCITT generator polynomial (as specified in standard)
            ushort polynomial = 0x1021;

            for (uint i = 0; i < message.Length - Constants.ECSS_CRC_TAIL; i++)
            {
                // "copy" (XOR w/ existing contents) the current msg bits into the MSB of the shift register
                shiftReg ^= (ushort)(message[i] << 8);

                for (int j = 0; j < 8; j++)
                {
                    // if the MSB is set, the bitwise AND gives 1
                    if ((shiftReg & 0x8000U) != 0U)
                    {
                        // toss out of the register the MSB and divide (XOR) its content with the generator
                        shiftReg = (ushort)((shiftReg << 1) ^ polynomial);
                    }
                    else
                    {
                        // just toss out the MSB and make room for a new bit
                        shiftReg = (ushort)(shiftReg << 1);
                    }
                }
            }
            return shiftReg;
        }
    }
}
