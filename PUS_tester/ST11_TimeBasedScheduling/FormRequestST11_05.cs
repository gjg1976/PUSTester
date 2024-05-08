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
    public partial class FormRequestST11_05 : Form
    {
        public List<NumericUpDown> sourceList = new List<NumericUpDown> ();
        public List<Label> sourceLabelList = new List<Label>();
        public List<NumericUpDown> appIDList = new List<NumericUpDown>();
        public List<Label> appIDLabelList = new List<Label>();
        public List<NumericUpDown> sequenceIDList = new List<NumericUpDown>();
        public List<Label> sequenceIDLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST11_05()
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
                for (int i = 0; i < N; i++, offset +=6)
                {
                    Byte[] payloadSrc = { new_payload[offset], new_payload[offset + 1]};
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadSrc);
                    UInt16 source = BitConverter.ToUInt16(payloadSrc, 0);

                    Byte[] payloadApp = { new_payload[offset + 2], new_payload[offset + 3] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadApp);
                    UInt16 app = BitConverter.ToUInt16(payloadApp, 0);

                    Byte[] payloadSeq = { new_payload[offset + 4], new_payload[offset + 5] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadSeq);
                    UInt16 seq = BitConverter.ToUInt16(payloadSeq, 0);

                    Label tmpSourceLabel = new Label();
                    tmpSourceLabel.Text = "Source ID #" + i.ToString();
                    tmpSourceLabel.Size = new System.Drawing.Size(80, 20);
                    tmpSourceLabel.Location = new System.Drawing.Point(60, i * 30 + 182);
                    sourceLabelList.Add(tmpSourceLabel);
                    this.Controls.Add(tmpSourceLabel);
                    NumericUpDown tmpSource = new NumericUpDown();
                    tmpSource.Value = source;
                    tmpSource.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpSource.Size = new System.Drawing.Size(68, 20);
                    tmpSource.Location = new System.Drawing.Point(150, i * 30 + 180);
                    tmpSource.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    sourceList.Add(tmpSource);
                    this.Controls.Add(tmpSource);

                    Label tmpAppIDLabel = new Label();
                    tmpAppIDLabel.Text = "App ID #" + i.ToString();
                    tmpAppIDLabel.Size = new System.Drawing.Size(60, 20);
                    tmpAppIDLabel.Location = new System.Drawing.Point(220, i * 30 + 182);
                    appIDLabelList.Add(tmpAppIDLabel);
                    this.Controls.Add(tmpAppIDLabel);
                    NumericUpDown tmpAppID = new NumericUpDown();
                    tmpAppID.Value = app;
                    tmpAppID.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpAppID.Size = new System.Drawing.Size(68, 20);
                    tmpAppID.Location = new System.Drawing.Point(290, i * 30 + 180);
                    tmpAppID.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    appIDList.Add(tmpAppID);
                    this.Controls.Add(tmpAppID);

                    Label tmpSeqIDLabel = new Label();
                    tmpSeqIDLabel.Text = "Sequence #" + i.ToString();
                    tmpSeqIDLabel.Size = new System.Drawing.Size(80, 20);
                    tmpSeqIDLabel.Location = new System.Drawing.Point(360, i * 30 + 182);
                    sequenceIDLabelList.Add(tmpSeqIDLabel);
                    this.Controls.Add(tmpSeqIDLabel);
                    NumericUpDown tmpSeqID = new NumericUpDown();
                    tmpSeqID.Value = seq;
                    tmpSeqID.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpSeqID.Size = new System.Drawing.Size(68, 20);
                    tmpSeqID.Location = new System.Drawing.Point(450, i * 30 + 180);
                    tmpSeqID.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    sequenceIDList.Add(tmpSeqID);
                    this.Controls.Add(tmpSeqID);
                }
            }
            updatePayloadAndGUI();
        }

        private void numericUpDownGeneric_ValueChanged(object sender, EventArgs e)
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
                UInt16 source = Convert.ToUInt16(sourceList[j].Value);
                byte[] bytesSrc = BitConverter.GetBytes(source);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesSrc);
                payload.Add(bytesSrc[0]);
                payload.Add(bytesSrc[1]);

                UInt16 appID = Convert.ToUInt16(appIDList[j].Value);
                byte[] bytesApp = BitConverter.GetBytes(appID);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesApp);
                payload.Add(bytesApp[0]);
                payload.Add(bytesApp[1]);

                UInt16 seqID = Convert.ToUInt16(sequenceIDList[j].Value);
                byte[] bytesSeq = BitConverter.GetBytes(seqID);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(bytesSeq);
                payload.Add(bytesSeq[0]);
                payload.Add(bytesSeq[1]);
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
            if (numericUpDownN.Value != sourceList.Count)
            {
                if (numericUpDownN.Value < sourceList.Count)
                {
                    for (int i = sourceList.Count - 1; numericUpDownN.Value < sourceList.Count; i--)
                    {
                        this.Controls.Remove(sourceList[i]);
                        sourceList.Remove(sourceList[i]);

                        this.Controls.Remove(sourceLabelList[i]);
                        sourceLabelList.Remove(sourceLabelList[i]);

                        this.Controls.Remove(appIDList[i]);
                        sourceList.Remove(appIDList[i]);

                        this.Controls.Remove(appIDLabelList[i]);
                        sourceLabelList.Remove(appIDLabelList[i]);

                        this.Controls.Remove(sequenceIDList[i]);
                        sourceList.Remove(sequenceIDList[i]);

                        this.Controls.Remove(sequenceIDLabelList[i]);
                        sourceLabelList.Remove(sequenceIDLabelList[i]);

                    }
                }
                else if (numericUpDownN.Value > sourceList.Count)
                {
                    for (int i = sourceList.Count; numericUpDownN.Value > sourceList.Count; i++)
                    {
                        Label tmpSourceLabel = new Label();
                        tmpSourceLabel.Text = "Source ID #" + i.ToString();
                        tmpSourceLabel.Size = new System.Drawing.Size(80, 20);
                        tmpSourceLabel.Location = new System.Drawing.Point(60, i * 30 + 182);
                        sourceLabelList.Add(tmpSourceLabel);
                        this.Controls.Add(tmpSourceLabel);
                        NumericUpDown tmpSource = new NumericUpDown();
                        tmpSource.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpSource.Size = new System.Drawing.Size(68, 20);
                        tmpSource.Location = new System.Drawing.Point(150, i * 30 + 180);
                        tmpSource.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        sourceList.Add(tmpSource);
                        this.Controls.Add(tmpSource);

                        Label tmpAppIDLabel = new Label();
                        tmpAppIDLabel.Text = "App ID #" + i.ToString();
                        tmpAppIDLabel.Size = new System.Drawing.Size(60, 20);
                        tmpAppIDLabel.Location = new System.Drawing.Point(220, i * 30 + 182);
                        appIDLabelList.Add(tmpAppIDLabel);
                        this.Controls.Add(tmpAppIDLabel);
                        NumericUpDown tmpAppID = new NumericUpDown();
                        tmpAppID.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpAppID.Size = new System.Drawing.Size(68, 20);
                        tmpAppID.Location = new System.Drawing.Point(290, i * 30 + 180);
                        tmpAppID.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        appIDList.Add(tmpAppID);
                        this.Controls.Add(tmpAppID);

                        Label tmpSeqIDLabel = new Label();
                        tmpSeqIDLabel.Text = "Sequence #" + i.ToString();
                        tmpSeqIDLabel.Size = new System.Drawing.Size(80, 20);
                        tmpSeqIDLabel.Location = new System.Drawing.Point(360, i * 30 + 182);
                        sequenceIDLabelList.Add(tmpSeqIDLabel);
                        this.Controls.Add(tmpSeqIDLabel);
                        NumericUpDown tmpSeqID = new NumericUpDown();
                        tmpSeqID.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpSeqID.Size = new System.Drawing.Size(68, 20);
                        tmpSeqID.Location = new System.Drawing.Point(450, i * 30 + 180);
                        tmpSeqID.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        sequenceIDList.Add(tmpSeqID);
                        this.Controls.Add(tmpSeqID);
                    }
                }
                updatePayloadAndGUI();
            }
        }
    }
}
