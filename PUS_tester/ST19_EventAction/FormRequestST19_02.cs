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
    public partial class FormRequestST19_02 : Form
    {
        public List<NumericUpDown> appIDList = new List<NumericUpDown> ();
        public List<Label> appIDLabelList = new List<Label>();
        public List<NumericUpDown> eventIDList = new List<NumericUpDown>();
        public List<Label> eventIDLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST19_02()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count > 0)
            {

                ushort N = 0;
                var currentValueFieldN = numericUpDownN.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN != null)
                {
                    Byte[] payload = { new_payload[0], new_payload[1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    N = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldN.SetValue(numericUpDownN, Convert.ToDecimal(N));
                    numericUpDownN.Text = N.ToString();
                }

                ushort offset = 2;
                for (int i = 0; i < N; i++)
                {
                    Byte[] payloadAppID = { new_payload[offset], new_payload[offset + 1] };
                    Byte[] payloadEventID = { new_payload[offset + 2], new_payload[offset + 3]};
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(payloadAppID);
                        Array.Reverse(payloadEventID);
                    }
                    UInt16 appID = BitConverter.ToUInt16(payloadAppID, 0);
                    UInt16 eventID = BitConverter.ToUInt16(payloadEventID, 0);
                    offset += 4;

                    Label tmpLabel = new Label();
                    tmpLabel.Text = "App ID #" + i.ToString();
                    tmpLabel.Size = new System.Drawing.Size(100, 20);
                    tmpLabel.Location = new System.Drawing.Point(60, i * 60 + 182);
                    appIDLabelList.Add(tmpLabel);
                    this.Controls.Add(tmpLabel);
                    NumericUpDown tmpAppId = new NumericUpDown();
                    tmpAppId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpAppId.Size = new System.Drawing.Size(68, 20);
                    tmpAppId.Location = new System.Drawing.Point(190, i * 60 + 180);
                    tmpAppId.Value = appID;
                    tmpAppId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    appIDList.Add(tmpAppId);
                    this.Controls.Add(tmpAppId);

                    Label tmpLabelEventID = new Label();
                    tmpLabelEventID.Text = "Event ID #" + i.ToString();
                    tmpLabelEventID.Size = new System.Drawing.Size(100, 20);
                    tmpLabelEventID.Location = new System.Drawing.Point(60, i * 60 + 212);
                    eventIDLabelList.Add(tmpLabelEventID);
                    this.Controls.Add(tmpLabelEventID);
                    NumericUpDown tmpEventId = new NumericUpDown();
                    tmpEventId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpEventId.Size = new System.Drawing.Size(68, 20);
                    tmpEventId.Location = new System.Drawing.Point(190, i * 60 + 210);
                    tmpEventId.Value = eventID;
                    tmpEventId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    eventIDList.Add(tmpEventId);
                    this.Controls.Add(tmpEventId);
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
            payload.Clear();

            byte[] bytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownN.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            payload.Add(bytes[0]);
            payload.Add(bytes[1]);
            
            for (int j = 0; j < numericUpDownN.Value; j++)
            {
                int i = 0;
                UInt16 appID = decimal.ToUInt16(appIDList[j].Value);
                UInt16 eventID = decimal.ToUInt16(eventIDList[j].Value);
                payload.Add((byte)(appID >> 8));
                payload.Add((byte)(appID & 0xff));
                payload.Add((byte)(eventID >> 8));
                payload.Add((byte)(eventID & 0xff));
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
            if (numericUpDownN.Value != appIDList.Count)
            {
                if (numericUpDownN.Value < appIDList.Count)
                {
                    for (int i = appIDList.Count - 1; numericUpDownN.Value < appIDList.Count; i--)
                    {
                        this.Controls.Remove(appIDList[i]);
                        appIDList.Remove(appIDList[i]);

                        this.Controls.Remove(appIDLabelList[i]);
                        appIDLabelList.Remove(appIDLabelList[i]);

                        this.Controls.Remove(eventIDList[i]);
                        eventIDList.Remove(eventIDList[i]);

                        this.Controls.Remove(eventIDLabelList[i]);
                        eventIDLabelList.Remove(eventIDLabelList[i]);
                    }
                }
                else if (numericUpDownN.Value > appIDList.Count)
                {
                    for (int i = appIDList.Count; numericUpDownN.Value > appIDList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "App ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        tmpLabel.Location = new System.Drawing.Point(60, i * 60 + 182);
                        appIDLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmpAppId = new NumericUpDown();
                        tmpAppId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpAppId.Size = new System.Drawing.Size(68, 20);
                        tmpAppId.Location = new System.Drawing.Point(190, i * 60 + 180);
                        tmpAppId.Value = 0;
                        tmpAppId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        appIDList.Add(tmpAppId);
                        this.Controls.Add(tmpAppId);

                        Label tmpLabelEventID = new Label();
                        tmpLabelEventID.Text = "Event ID #" + i.ToString();
                        tmpLabelEventID.Size = new System.Drawing.Size(100, 20);
                        tmpLabelEventID.Location = new System.Drawing.Point(60, i * 60 + 212);
                        eventIDLabelList.Add(tmpLabelEventID);
                        this.Controls.Add(tmpLabelEventID);
                        NumericUpDown tmpEventId = new NumericUpDown();
                        tmpEventId.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpEventId.Size = new System.Drawing.Size(68, 20);
                        tmpEventId.Location = new System.Drawing.Point(190, i * 60 +210);
                        tmpEventId.Value = 0;
                        tmpEventId.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        eventIDList.Add(tmpEventId);
                        this.Controls.Add(tmpEventId);
                    }
                }
                updatePayloadAndGUI();
            }
        }

    }
}
