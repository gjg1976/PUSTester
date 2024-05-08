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
    public partial class FormRequestST15_04 : Form
    {
        public List<NumericUpDown> appIDList = new List<NumericUpDown>();
        public List<Label> appIDLabelList = new List<Label>();
        public List<NumericUpDown> N2List = new List<NumericUpDown>();
        public List<Label> N2LabelList = new List<Label>();
        public List<List<NumericUpDown>> serviceTypeList = new List<List<NumericUpDown>>();
        public List<List<Label>> serviceTypeLabelList = new List<List<Label>>();
        public List<List<NumericUpDown>> N3List = new List<List<NumericUpDown>>();
        public List<List<Label>> N3LabelList = new List<List<Label>>();
        public List<List<List<NumericUpDown>>> serviceSubTypeList = new List<List<List<NumericUpDown>>>();
        public List<List<List<Label>>> serviceSubTypeLabelList = new List<List<List<Label>>>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST15_04()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;
            if (new_payload.Count > 0)
            {
                int offset = 0;
                Byte[] functionName = new byte[Properties.Settings.Default.ST15StoresIDSize];
                for (int i = 0; i < Properties.Settings.Default.ST15StoresIDSize; i++, offset++)
                {
                    functionName[i] = new_payload[offset];
                }

                textBoxFunctionName.Text = System.Text.Encoding.UTF8.GetString(functionName);


                Byte[] payloadN1 = { new_payload[offset], new_payload[offset + 1] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadN1);
                ushort N1 = BitConverter.ToUInt16(payloadN1, 0);

                var currentValueFieldN1 = numericUpDownN1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN1 != null)
                {
                    currentValueFieldN1.SetValue(numericUpDownN1, Convert.ToDecimal(N1));
                    numericUpDownN1.Text = N1.ToString();
                }
                offset += 2;
                for (int i = 0; i < N1; i++)
                {
                    Byte[] payloadAppID = { new_payload[offset], new_payload[offset + 1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadAppID);
                    ushort appID = BitConverter.ToUInt16(payloadAppID, 0);

                    Byte[] payloadN2 = { new_payload[offset+2], new_payload[offset + 3] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payloadN2);
                    ushort N2 = BitConverter.ToUInt16(payloadN2, 0);

                    Label tmpLabel = new Label();
                    tmpLabel.Text = "App ID #" + i.ToString();
                    tmpLabel.Size = new System.Drawing.Size(100, 20);
                    appIDLabelList.Add(tmpLabel);
                    this.Controls.Add(tmpLabel);
                    NumericUpDown tmp = new NumericUpDown();
                    tmp.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmp.Size = new System.Drawing.Size(68, 20);
                    tmp.Value = appID;
                    tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    appIDList.Add(tmp);
                    this.Controls.Add(tmp);

                    Label tmpN2Label = new Label();
                    tmpN2Label.Text = "N2 #" + i.ToString();
                    tmpN2Label.Size = new System.Drawing.Size(100, 20);
                    N2LabelList.Add(tmpN2Label);
                    this.Controls.Add(tmpN2Label);
                    NumericUpDown tmpN2 = new NumericUpDown();
                    tmpN2.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpN2.Size = new System.Drawing.Size(68, 20);
                    tmpN2.Tag = i;
                    tmpN2.Value = N2;
                    tmpN2.ValueChanged += new System.EventHandler(this.numericUpDownN2_ValueChanged);
                    N2List.Add(tmpN2);
                    this.Controls.Add(tmpN2);
                    serviceTypeList.Add(new List<NumericUpDown>());
                    serviceTypeLabelList.Add(new List<Label>());
                    N3List.Add(new List<NumericUpDown>());
                    N3LabelList.Add(new List<Label>());
                    serviceSubTypeList.Add(new List<List<NumericUpDown>>());
                    serviceSubTypeLabelList.Add(new List<List<Label>>());

                    offset += 4;
                    for (int j = 0; j < N2; j++)
                    {
                        byte serviceType = new_payload[offset];

                        Byte[] payloadN3 = { new_payload[offset + 1], new_payload[offset + 2] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(payloadN3);
                        ushort N3 = BitConverter.ToUInt16(payloadN3, 0);

                        Label tmpLabelRep = new Label();
                        tmpLabelRep.Text = "Service Type#" + j.ToString();
                        tmpLabelRep.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelRep);
                        NumericUpDown tmpRep = new NumericUpDown();
                        tmpRep.Maximum = new decimal(new int[] {
                        255,
                        0,
                        0,
                        0});
                        tmpRep.Size = new System.Drawing.Size(68, 20);
                        tmpRep.Value = serviceType;
                        tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        serviceTypeList[i].Add(tmpRep);
                        this.Controls.Add(tmpRep);
                        serviceTypeLabelList[i].Add(tmpLabelRep);
                        this.Controls.Add(tmpLabelRep);

                        Label tmpLabelN3 = new Label();
                        tmpLabelN3.Text = "N3 #" + j.ToString();
                        tmpLabelN3.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelN3);
                        NumericUpDown tmpN3 = new NumericUpDown();
                        tmpN3.Maximum = new decimal(new int[] {
                        65535,
                        0,
                        0,
                        0});
                        tmpN3.Size = new System.Drawing.Size(68, 20);
                        UInt16[] tag = { (ushort)i, (ushort)j };
                        tmpN3.Tag = tag;
                        tmpN3.Value = N3;
                        tmpN3.ValueChanged += new System.EventHandler(this.numericUpDownN3_ValueChanged);
                        N3List[i].Add(tmpN3);
                        this.Controls.Add(tmpN3);
                        N3LabelList[i].Add(tmpLabelN3);
                        this.Controls.Add(tmpLabelN3);
                        serviceSubTypeList[i].Add(new List<NumericUpDown>());
                        serviceSubTypeLabelList[i].Add(new List<Label>());

                        offset += 3;
                        for (int h = 0; h < N3; h++)
                        {
                            byte serviceSubType = new_payload[offset++];
                            Label tmpLabelRepN3 = new Label();
                            tmpLabelRepN3.Text = "Service Sub Type#" + j.ToString();
                            tmpLabelRepN3.Size = new System.Drawing.Size(120, 20);

                            this.Controls.Add(tmpLabelRepN3);
                            NumericUpDown tmpRepN3 = new NumericUpDown();
                            tmpRepN3.Maximum = new decimal(new int[] {
                        255,
                        0,
                        0,
                        0});
                            tmpRepN3.Size = new System.Drawing.Size(68, 20);
                            tmpRepN3.Value = serviceSubType;
                            tmpRepN3.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                            serviceSubTypeList[i][j].Add(tmpRepN3);
                            this.Controls.Add(tmpRepN3);
                            serviceSubTypeLabelList[i][j].Add(tmpLabelRepN3);
                            this.Controls.Add(tmpLabelRepN3);
                        }
                    }
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

        void updatePayloadAndGUI()
        {
            Int32 offset = 150;
            payload.Clear();
            byte[] bytes = Encoding.ASCII.GetBytes(textBoxFunctionName.Text);
            int i = 0;
            for (; i < bytes.Length; i++)
            {
                payload.Add(bytes[i]);
            }
            for (; i < Properties.Settings.Default.ST15StoresIDSize; i++)
            {
                payload.Add(0);
            }
            byte[] N1 = BitConverter.GetBytes((ushort)appIDList.Count);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(N1);
            payload.Add(N1[0]);
            payload.Add(N1[1]);

            for (i = 0; i < appIDList.Count; i++)
            {
                offset += 30;
                byte[] appID = BitConverter.GetBytes((ushort)decimal.ToUInt16(appIDList[i].Value));
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(appID);
                payload.Add(appID[0]);
                payload.Add(appID[1]);

                appIDLabelList[i].Location = new System.Drawing.Point(150, offset + 3);
                appIDList[i].Location = new System.Drawing.Point(250, offset);
                offset += 30;
                N2LabelList[i].Location = new System.Drawing.Point(150, offset + 3);
                N2List[i].Location = new System.Drawing.Point(250, offset);

                byte[] N2 = BitConverter.GetBytes((ushort)N2List[i].Value);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(N2);
                payload.Add(N2[0]);
                payload.Add(N2[1]);
                for (int j = 0; j < serviceTypeList[i].Count; j++)
                {
                    offset += 30;
                    serviceTypeLabelList[i][j].Location = new System.Drawing.Point(250, offset + 3);
                    serviceTypeList[i][j].Location = new System.Drawing.Point(350, offset);
                    offset += 30;
                    N3LabelList[i][j].Location = new System.Drawing.Point(250, offset + 3);
                    N3List[i][j].Location = new System.Drawing.Point(350, offset);

                    payload.Add(decimal.ToByte(serviceTypeList[i][j].Value));

                    byte[] N3 = BitConverter.GetBytes((ushort)N3List[i][j].Value);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(N3);
                    payload.Add(N3[0]);
                    payload.Add(N3[1]);

                    for (int h = 0; h < serviceSubTypeList[i][j].Count; h++)
                    {
                        offset += 30;
                        serviceSubTypeLabelList[i][j][h].Location = new System.Drawing.Point(350, offset+3);
                        serviceSubTypeList[i][j][h].Location = new System.Drawing.Point(470, offset);
                        payload.Add(decimal.ToByte(serviceSubTypeList[i][j][h].Value));
                    }

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

        private void numericUpDownN1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownN1.Value != appIDList.Count)
            {
                if (numericUpDownN1.Value < appIDList.Count)
                {
                    for (int i = appIDList.Count - 1; numericUpDownN1.Value < appIDList.Count; i--)
                    {
                        for (int j = serviceTypeList[i].Count - 1; j >= 0; j--)
                        {
                            this.Controls.Remove(serviceTypeList[i][j]);
                            serviceTypeList[i].Remove(serviceTypeList[i][j]);
                            this.Controls.Remove(serviceTypeLabelList[i][j]);
                            serviceTypeLabelList[i].Remove(serviceTypeLabelList[i][j]);
                            this.Controls.Remove(N3List[i][j]);
                            N3List[i].Remove(N3List[i][j]);
                            this.Controls.Remove(N3LabelList[i][j]);
                            N3LabelList[i].Remove(N3LabelList[i][j]);
                            for (int h = serviceSubTypeList[i][j].Count - 1; h >= 0; h--)
                            {
                                this.Controls.Remove(serviceSubTypeList[i][j][j]);
                                serviceSubTypeList[i][j].Remove(serviceSubTypeList[i][j][j]);
                                this.Controls.Remove(serviceSubTypeLabelList[i][j][j]);
                                serviceSubTypeLabelList[i][j].Remove(serviceSubTypeLabelList[i][j][j]);
                            }
                            serviceSubTypeList[i].Remove(serviceSubTypeList[i][j]);
                            serviceSubTypeLabelList[i].Remove(serviceSubTypeLabelList[i][j]);
                        }
                        this.Controls.Remove(appIDList[i]);
                        appIDList.Remove(appIDList[i]);
                        this.Controls.Remove(appIDLabelList[i]);
                        appIDLabelList.Remove(appIDLabelList[i]);
                        this.Controls.Remove(N2List[i]);
                        N2List.Remove(N2List[i]);
                        this.Controls.Remove(N2LabelList[i]);
                        N2LabelList.Remove(N2LabelList[i]);
                    }
                }
                else if (numericUpDownN1.Value > appIDList.Count)
                {
                    for (int i = appIDList.Count; numericUpDownN1.Value > appIDList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "App ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        appIDLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        appIDList.Add(tmp);
                        this.Controls.Add(tmp);

                        Label tmpN2Label = new Label();
                        tmpN2Label.Text = "N2 #" + i.ToString();
                        tmpN2Label.Size = new System.Drawing.Size(100, 20);
                        N2LabelList.Add(tmpN2Label);
                        this.Controls.Add(tmpN2Label);
                        NumericUpDown tmpN2 = new NumericUpDown();
                        tmpN2.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpN2.Size = new System.Drawing.Size(68, 20);
                        tmpN2.Tag = i;
                        tmpN2.ValueChanged += new System.EventHandler(this.numericUpDownN2_ValueChanged);
                        N2List.Add(tmpN2);
                        this.Controls.Add(tmpN2);
                        serviceTypeList.Add(new List<NumericUpDown>());
                        serviceTypeLabelList.Add(new List<Label>());
                        N3List.Add(new List<NumericUpDown>());
                        N3LabelList.Add(new List<Label>());
                        serviceSubTypeList.Add(new List<List<NumericUpDown>>());
                        serviceSubTypeLabelList.Add(new List<List<Label>>());
                    }
                }
                updatePayloadAndGUI();
            }
        }
        private void numericUpDownN2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            int i = (int)numericUpDown.Tag;
  
            if (numericUpDown.Value != serviceTypeList[i].Count)
            {
                if (numericUpDown.Value < serviceTypeList[i].Count)
                {
                    for (int j = serviceTypeList[i].Count - 1; numericUpDown.Value < serviceTypeList[i].Count; j--)
                    {
                        this.Controls.Remove(serviceTypeList[i][j]);
                        serviceTypeList[i].Remove(serviceTypeList[i][j]);
                        this.Controls.Remove(serviceTypeLabelList[i][j]);
                        serviceTypeLabelList[i].Remove(serviceTypeLabelList[i][j]);
                        this.Controls.Remove(N3List[i][j]);
                        N3List[i].Remove(N3List[i][j]);
                        this.Controls.Remove(N3LabelList[i][j]);
                        N3LabelList[i].Remove(N3LabelList[i][j]);
                        for (int h = serviceSubTypeList[i][j].Count - 1; h >= 0; h--)
                        {
                            this.Controls.Remove(serviceSubTypeList[i][j][j]);
                            serviceSubTypeList[i][j].Remove(serviceSubTypeList[i][j][j]);
                            this.Controls.Remove(serviceSubTypeLabelList[i][j][j]);
                            serviceSubTypeLabelList[i][j].Remove(serviceSubTypeLabelList[i][j][j]);
                        }
                        serviceSubTypeList[i].Remove(serviceSubTypeList[i][j]);
                        serviceSubTypeLabelList[i].Remove(serviceSubTypeLabelList[i][j]);

                    }
                }
                else if (numericUpDown.Value > serviceTypeList[i].Count)
                {
                    for (int j = serviceTypeList[i].Count; numericUpDown.Value > serviceTypeList[i].Count; j++)
                    {
                        Label tmpLabelRep = new Label();
                        tmpLabelRep.Text = "Service Type#" + j.ToString();
                        tmpLabelRep.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelRep);
                        NumericUpDown tmpRep = new NumericUpDown();
                        tmpRep.Maximum = new decimal(new int[] {
                        255,
                        0,
                        0,
                        0});
                        tmpRep.Size = new System.Drawing.Size(68, 20);
                        tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        serviceTypeList[i].Add(tmpRep);
                        this.Controls.Add(tmpRep);
                        serviceTypeLabelList[i].Add(tmpLabelRep);
                        this.Controls.Add(tmpLabelRep);

                        Label tmpLabelN3 = new Label();
                        tmpLabelN3.Text = "N3 #" + j.ToString();
                        tmpLabelN3.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelN3);
                        NumericUpDown tmpN3 = new NumericUpDown();
                        tmpN3.Maximum = new decimal(new int[] {
                        65535,
                        0,
                        0,
                        0});
                        tmpN3.Size = new System.Drawing.Size(68, 20);
                        UInt16[] tag = { (ushort)i, (ushort)j };
                        tmpN3.Tag = tag;
                        tmpN3.ValueChanged += new System.EventHandler(this.numericUpDownN3_ValueChanged);
                        N3List[i].Add(tmpN3);
                        this.Controls.Add(tmpN3);
                        N3LabelList[i].Add(tmpLabelN3);
                        this.Controls.Add(tmpLabelN3);
                        serviceSubTypeList[i].Add(new List<NumericUpDown>());
                        serviceSubTypeLabelList[i].Add(new List<Label>());
                    }
                }
                updatePayloadAndGUI();
            }
        }
        private void numericUpDownN3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            UInt16[] tag = (UInt16[])numericUpDown.Tag;

            if (numericUpDown.Value != serviceSubTypeList[tag[0]][tag[1]].Count)
            {
                if (numericUpDown.Value < serviceSubTypeList[tag[0]][tag[1]].Count)
                {
                    for (int j = serviceSubTypeList[tag[0]][tag[1]].Count - 1; numericUpDown.Value < serviceSubTypeList[tag[0]][tag[1]].Count; j--)
                    {
                        this.Controls.Remove(serviceSubTypeList[tag[0]][tag[1]][j]);
                        serviceSubTypeList[tag[0]][tag[1]].Remove(serviceSubTypeList[tag[0]][tag[1]][j]);
                        this.Controls.Remove(serviceSubTypeLabelList[tag[0]][tag[1]][j]);
                        serviceSubTypeLabelList[tag[0]][tag[1]].Remove(serviceSubTypeLabelList[tag[0]][tag[1]][j]);
                    }
                }
                else if (numericUpDown.Value > serviceSubTypeList[tag[0]][tag[1]].Count)
                {
                    for (int j = serviceSubTypeList[tag[0]][tag[1]].Count; numericUpDown.Value > serviceSubTypeList[tag[0]][tag[1]].Count; j++)
                    {
                        Label tmpLabelRep = new Label();
                        tmpLabelRep.Text = "Service Sub Type#" + j.ToString();
                        tmpLabelRep.Size = new System.Drawing.Size(120, 20);

                        this.Controls.Add(tmpLabelRep);
                        NumericUpDown tmpRep = new NumericUpDown();
                        tmpRep.Maximum = new decimal(new int[] {
                        255,
                        0,
                        0,
                        0});
                        tmpRep.Size = new System.Drawing.Size(68, 20);
                        tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        serviceSubTypeList[tag[0]][tag[1]].Add(tmpRep);
                        this.Controls.Add(tmpRep);
                        serviceSubTypeLabelList[tag[0]][tag[1]].Add(tmpLabelRep);
                        this.Controls.Add(tmpLabelRep);
                    }
                }
                updatePayloadAndGUI();
            }
        }

        private void textBoxFunctionName_TextChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();

        }
    }
}
