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
    public partial class FormRequestST12_07 : Form
    {
        public List<NumericUpDown> PMONIDList = new List<NumericUpDown>();
        public List<Label> PMONIDLabelList = new List<Label>();
        public List<NumericUpDown> paramIDList = new List<NumericUpDown> ();
        public List<Label> paramIDLabelList = new List<Label>();
        public List<NumericUpDown> repNumList = new List<NumericUpDown>();
        public List<Label> repNumLabelList = new List<Label>();
        public List<ComboBox> typeList = new List<ComboBox>();
        public List<Label> typeLabelList = new List<Label>();

        public List<NumericUpDown> eventIDLowList = new List<NumericUpDown>();
        public List<Label> eventIDLowLabelList = new List<Label>();
        public List<NumericUpDown> eventIDHighList = new List<NumericUpDown>();
        public List<Label> eventIDHighLabelList = new List<Label>();
        public List<NumericUpDown> deltaList = new List<NumericUpDown>();
        public List<Label> deltaLabelList = new List<Label>();
        public List<TextBox> parameterValue1List = new List<TextBox>();
        public List<Label> parameterValue1LabelList = new List<Label>();
        public List<TextBox> parameterValue2List = new List<TextBox>();
        public List<Label> parameterValue2LabelList = new List<Label>();

        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST12_07()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        private void textBox_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
        void updatePayloadAndGUI()
        {
            payload.Clear();
            Int32 offset = 153;
            byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownN.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            payload.Add(bytes[0]);
            payload.Add(bytes[1]);
            
            for (int j = 0; j < numericUpDownN.Value; j++)
            {
 
                UInt16 PMONID = decimal.ToUInt16(PMONIDList[j].Value);
                UInt16 paramID = decimal.ToUInt16(paramIDList[j].Value);
                UInt16 repNum = decimal.ToUInt16(repNumList[j].Value);
                Byte type = (byte)typeList[j].SelectedIndex;

                payload.Add((byte)(PMONID >> 8));
                payload.Add((byte)(PMONID & 0xff));

                payload.Add((byte)(paramID >> 8));
                payload.Add((byte)(paramID & 0xff));

                payload.Add((byte)(repNum >> 8));
                payload.Add((byte)(repNum & 0xff));

                payload.Add(type);

                offset += 30;
                PMONIDLabelList[j].Location = new System.Drawing.Point(150, offset+3);
                PMONIDList[j].Location = new System.Drawing.Point(250, offset);
                offset += 30;
                paramIDLabelList[j].Location = new System.Drawing.Point(150, offset + 3);
                paramIDList[j].Location = new System.Drawing.Point(250, offset);
                offset += 30;
                repNumLabelList[j].Location = new System.Drawing.Point(150, offset + 3);
                repNumList[j].Location = new System.Drawing.Point(250, offset);
                offset += 30;
                typeLabelList[j].Location = new System.Drawing.Point(150, offset + 3);
                typeList[j].Location = new System.Drawing.Point(250, offset);
                switch (type)
                {
                    case 0:
                        {
                            if (!(Regex.IsMatch(parameterValue1List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                   parameterValue1List[j].Text.Length % 2 != 0) && !(Regex.IsMatch(parameterValue2List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                  parameterValue2List[j].Text.Length % 2 != 0) && parameterValue1List[j].Text.Length == parameterValue2List[j].Text.Length)
                            {
                                int i = 0;
                                byte[] values = new byte[parameterValue1List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue1List[j].Text, 2))
                                    values[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values.Length; i++)
                                    payload.Add(values[i]);
                                i = 0;
                                byte[] values2 = new byte[parameterValue2List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue2List[j].Text, 2))
                                    values2[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values2.Length; i++)
                                    payload.Add(values2[i]);

                                UInt16 eventID = decimal.ToUInt16(eventIDLowList[j].Value);

                                payload.Add((byte)(eventID >> 8));
                                payload.Add((byte)(eventID & 0xff));
                            }
                            offset += 30;
                            parameterValue1LabelList[j].Text = "Mask #" + j.ToString();
                            parameterValue1LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue1List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            parameterValue2LabelList[j].Text = "Expected Value #" + j.ToString();
                            parameterValue2LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue2List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            eventIDLowLabelList[j].Text = "Event ID #" + j.ToString();
                            eventIDLowLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            eventIDLowList[j].Location = new System.Drawing.Point(300, offset);
                            eventIDHighLabelList[j].Visible = false;
                            eventIDHighList[j].Visible = false;
                            deltaList[j].Visible = false;
                            break;
                        }
                    case 1:
                        {
                            if (!(Regex.IsMatch(parameterValue1List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                   parameterValue1List[j].Text.Length % 2 != 0) && !(Regex.IsMatch(parameterValue2List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                  parameterValue2List[j].Text.Length % 2 != 0) && parameterValue1List[j].Text.Length == parameterValue2List[j].Text.Length)
                            {
                                int i = 0;
                                byte[] values = new byte[parameterValue1List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue1List[j].Text, 2))
                                    values[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values.Length; i++)
                                    payload.Add(values[i]);
                                UInt16 eventID = decimal.ToUInt16(eventIDLowList[j].Value);

                                payload.Add((byte)(eventID >> 8));
                                payload.Add((byte)(eventID & 0xff));
                                i = 0;
                                byte[] values2 = new byte[parameterValue2List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue2List[j].Text, 2))
                                    values2[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values2.Length; i++)
                                    payload.Add(values2[i]);
                                eventID = decimal.ToUInt16(eventIDHighList[j].Value);

                                payload.Add((byte)(eventID >> 8));
                                payload.Add((byte)(eventID & 0xff));
                            }

                            offset += 30;
                            parameterValue1LabelList[j].Text = "Low limit #" + j.ToString();
                            parameterValue1LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue1List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            eventIDLowLabelList[j].Text = "Event Low ID #" + j.ToString();
                            eventIDLowLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            eventIDLowList[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            parameterValue2LabelList[j].Text = "High limit #" + j.ToString();
                            parameterValue2LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue2List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            eventIDHighLabelList[j].Visible = true;
                            eventIDHighList[j].Visible = true;
                            eventIDHighLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            eventIDHighList[j].Location = new System.Drawing.Point(300, offset);
                            deltaList[j].Visible = false;
                            break;
                        }
                    case 2:
                        {
                            
                            if (!(Regex.IsMatch(parameterValue1List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                   parameterValue1List[j].Text.Length % 2 != 0) && !(Regex.IsMatch(parameterValue2List[j].Text, @"^[A-Fa-f0-9]*$") == false ||
                                  parameterValue2List[j].Text.Length % 2 != 0) && parameterValue1List[j].Text.Length == parameterValue2List[j].Text.Length)
                            {
                                int i = 0;
                                byte[] values = new byte[parameterValue1List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue1List[j].Text, 2))
                                    values[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values.Length; i++)
                                    payload.Add(values[i]);
                                UInt16 eventID = decimal.ToUInt16(eventIDLowList[j].Value);

                                payload.Add((byte)(eventID >> 8));
                                payload.Add((byte)(eventID & 0xff));
                                i = 0;
                                byte[] values2 = new byte[parameterValue2List[j].Text.Length / 2];
                                foreach (string s in SplitInParts(parameterValue2List[j].Text, 2))
                                    values2[i++] = Convert.ToByte(s, 16);
                                for (i = 0; i < values2.Length; i++)
                                    payload.Add(values2[i]);
                                eventID = decimal.ToUInt16(eventIDHighList[j].Value);

                                payload.Add((byte)(eventID >> 8));
                                payload.Add((byte)(eventID & 0xff));

                                UInt16 delta = decimal.ToUInt16(deltaList[j].Value);

                                payload.Add((byte)(delta >> 8));
                                payload.Add((byte)(delta & 0xff));
                            }
                            offset += 30;
                            parameterValue1LabelList[j].Text = "Low delta limit #" + j.ToString();
                            parameterValue1LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue1List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            eventIDLowLabelList[j].Text = "Event Low ID #" + j.ToString();
                            eventIDLowLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            eventIDLowList[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            parameterValue2LabelList[j].Text = "High delta limit #" + j.ToString();
                            parameterValue2LabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            parameterValue2List[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            eventIDHighLabelList[j].Visible = true;
                            eventIDHighList[j].Visible = true;
                            eventIDHighLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            eventIDHighList[j].Location = new System.Drawing.Point(300, offset);
                            offset += 30;
                            deltaList[j].Visible = true;
                            deltaLabelList[j].Location = new System.Drawing.Point(200, offset + 3);
                            deltaList[j].Location = new System.Drawing.Point(300, offset);
                            break;
                        }
                    default:
                        break;
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
        private void numericUpDownN_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownN.Value != PMONIDList.Count)
            {
                if (numericUpDownN.Value < PMONIDList.Count)
                {
                    for (int i = PMONIDList.Count - 1; numericUpDownN.Value < PMONIDList.Count; i--)
                    {
                        this.Controls.Remove(PMONIDList[i]);
                        PMONIDList.Remove(PMONIDList[i]);

                        this.Controls.Remove(PMONIDLabelList[i]);
                        PMONIDLabelList.Remove(PMONIDLabelList[i]);

                        this.Controls.Remove(paramIDList[i]);
                        paramIDList.Remove(paramIDList[i]);

                        this.Controls.Remove(paramIDLabelList[i]);
                        paramIDLabelList.Remove(paramIDLabelList[i]);

                        this.Controls.Remove(repNumList[i]);
                        repNumList.Remove(repNumList[i]);

                        this.Controls.Remove(repNumLabelList[i]);
                        repNumLabelList.Remove(repNumLabelList[i]);

                        this.Controls.Remove(typeList[i]);
                        typeList.Remove(typeList[i]);

                        this.Controls.Remove(typeLabelList[i]);
                        typeLabelList.Remove(typeLabelList[i]);

                        this.Controls.Remove(eventIDLowList[i]);
                        eventIDLowList.Remove(eventIDLowList[i]);

                        this.Controls.Remove(eventIDLowLabelList[i]);
                        eventIDLowLabelList.Remove(eventIDLowLabelList[i]);

                        this.Controls.Remove(eventIDHighList[i]);
                        eventIDHighList.Remove(eventIDHighList[i]);

                        this.Controls.Remove(eventIDHighLabelList[i]);
                        eventIDHighLabelList.Remove(eventIDHighLabelList[i]);

                        this.Controls.Remove(deltaList[i]);
                        deltaList.Remove(deltaList[i]);

                        this.Controls.Remove(deltaLabelList[i]);
                        deltaLabelList.Remove(deltaLabelList[i]);

                        this.Controls.Remove(parameterValue1List[i]);
                        parameterValue1List.Remove(parameterValue1List[i]);

                        this.Controls.Remove(parameterValue1LabelList[i]);
                        parameterValue1LabelList.Remove(parameterValue1LabelList[i]);

                        this.Controls.Remove(parameterValue2List[i]);
                        parameterValue2List.Remove(parameterValue2List[i]);

                        this.Controls.Remove(parameterValue2LabelList[i]);
                        parameterValue2LabelList.Remove(parameterValue2LabelList[i]);
                    }
                }
                else if (numericUpDownN.Value > PMONIDList.Count)
                {
                    for (int i = PMONIDList.Count; numericUpDownN.Value > PMONIDList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "PMON ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        PMONIDLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmpAppId = new NumericUpDown();
                        tmpAppId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpAppId.Size = new System.Drawing.Size(68, 20);
                        tmpAppId.Value = 0;
                        tmpAppId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        PMONIDList.Add(tmpAppId);
                        this.Controls.Add(tmpAppId);

                        Label tmpLabelParamID = new Label();
                        tmpLabelParamID.Text = "Parameter ID #" + i.ToString();
                        tmpLabelParamID.Size = new System.Drawing.Size(100, 20);
                        tmpLabelParamID.Location = new System.Drawing.Point(60, i * 60 + 212);
                        paramIDLabelList.Add(tmpLabelParamID);
                        this.Controls.Add(tmpLabelParamID);
                        NumericUpDown tmpEventId = new NumericUpDown();
                        tmpEventId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpEventId.Size = new System.Drawing.Size(68, 20);
                        tmpEventId.Value = 0;
                        tmpEventId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        paramIDList.Add(tmpEventId);
                        this.Controls.Add(tmpEventId);

                        Label tmpLabelRepNum = new Label();
                        tmpLabelRepNum.Text = "Repetition #" + i.ToString();
                        tmpLabelRepNum.Size = new System.Drawing.Size(100, 20);
                        repNumLabelList.Add(tmpLabelRepNum);
                        this.Controls.Add(tmpLabelRepNum);
                        NumericUpDown tmpRepNum = new NumericUpDown();
                        tmpRepNum.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpRepNum.Size = new System.Drawing.Size(68, 20);
                        tmpRepNum.Value = 0;
                        tmpRepNum.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        repNumList.Add(tmpRepNum);
                        this.Controls.Add(tmpRepNum);

                        Label tmpTypeLabel = new Label();
                        tmpTypeLabel.Text = "Type #" + i.ToString();
                        tmpTypeLabel.Size = new System.Drawing.Size(80, 20);
                        typeLabelList.Add(tmpTypeLabel);
                        this.Controls.Add(tmpTypeLabel);
                        ComboBox tmpType = new ComboBox();
                        tmpType.Items.AddRange(new object[] {
                              "Expected",
                              "Limit",
                              "Delta"});
                        tmpType.Size = new System.Drawing.Size(68, 20);
                        tmpType.SelectedIndex = 0;
                        tmpType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
                        typeList.Add(tmpType);
                        this.Controls.Add(tmpType);


                        Label tmpValues1Label = new Label();
                        tmpValues1Label.Text = "Parameter1 #" + i.ToString();
                        tmpValues1Label.Size = new System.Drawing.Size(100, 20);
                        parameterValue1LabelList.Add(tmpValues1Label);
                        this.Controls.Add(tmpValues1Label);
                        TextBox tmpValues1 = new TextBox();
                        tmpValues1.Size = new System.Drawing.Size(68, 20);
                        tmpValues1.TextChanged += new System.EventHandler(this.textBox_ValueChanged);
                        parameterValue1List.Add(tmpValues1);
                        this.Controls.Add(tmpValues1);

                        Label tmpValues2Label = new Label();
                        tmpValues2Label.Text = "Parameter2 #" + i.ToString();
                        tmpValues2Label.Size = new System.Drawing.Size(100, 20);
                        parameterValue2LabelList.Add(tmpValues2Label);
                        this.Controls.Add(tmpValues2Label);
                        TextBox tmpValues2 = new TextBox();
                        tmpValues2.Size = new System.Drawing.Size(68, 20);
                        tmpValues2.TextChanged += new System.EventHandler(this.textBox_ValueChanged);
                        parameterValue2List.Add(tmpValues2);
                        this.Controls.Add(tmpValues2);

                        Label tmpEvent1Label = new Label();
                        tmpEvent1Label.Text = "Event Low ID #" + i.ToString();
                        tmpEvent1Label.Size = new System.Drawing.Size(100, 20);
                        eventIDLowLabelList.Add(tmpEvent1Label);
                        this.Controls.Add(tmpEvent1Label);
                        NumericUpDown tmpEvent1 = new NumericUpDown();
                        tmpEvent1.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpEvent1.Size = new System.Drawing.Size(68, 20);
                        tmpEvent1.Value = 0;
                        tmpEvent1.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        eventIDLowList.Add(tmpEvent1);
                        this.Controls.Add(tmpEvent1);

                        Label tmpEvent2Label = new Label();
                        tmpEvent2Label.Text = "Event High ID #" + i.ToString();
                        tmpEvent2Label.Size = new System.Drawing.Size(100, 20);
                        eventIDHighLabelList.Add(tmpEvent2Label);
                        this.Controls.Add(tmpEvent2Label);
                        NumericUpDown tmpEvent2 = new NumericUpDown();
                        tmpEvent2.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpEvent2.Size = new System.Drawing.Size(68, 20);
                        tmpEvent2.Value = 0;
                        tmpEvent2.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        eventIDHighList.Add(tmpEvent2);
                        this.Controls.Add(tmpEvent2);

                        Label tmpDeltaLabel = new Label();
                        tmpDeltaLabel.Text = "Delta count #" + i.ToString();
                        tmpDeltaLabel.Size = new System.Drawing.Size(100, 20);
                        deltaLabelList.Add(tmpDeltaLabel);
                        this.Controls.Add(tmpDeltaLabel);
                        NumericUpDown tmpDelta = new NumericUpDown();
                        tmpDelta.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpDelta.Size = new System.Drawing.Size(68, 20);
                        tmpDelta.Value = 0;
                        tmpDelta.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        deltaList.Add(tmpDelta);
                        this.Controls.Add(tmpDelta);
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
    }
}
