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
    public partial class FormRequestST03_01 : Form
    {
        public List<NumericUpDown> parametersList = new List<NumericUpDown>();
        public List<Label> parametersLabelList = new List<Label>();
        public List<NumericUpDown> superConmRepetitionList = new List<NumericUpDown>();
        public List<Label> superConmRepetitionLabelList = new List<Label>();
        public List<NumericUpDown> superConmN2List = new List<NumericUpDown>();
        public List<Label> superConmN2LabelList = new List<Label>();
        public List<List<NumericUpDown>> superConmN2ParametersList = new List<List<NumericUpDown>>();
        public List<List<Label>> superConmN2ParametersLabelList = new List<List<Label>>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;
        public FormRequestST03_01()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;

            if(new_payload.Count > 0)
            {
                    var currentValueFieldStructID = numericUpDownStructID.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (currentValueFieldStructID != null)
                    {
                        currentValueFieldStructID.SetValue(numericUpDownStructID, Convert.ToDecimal(new_payload[0]));
                        numericUpDownStructID.Text = new_payload[0].ToString();
                    }
                    var currentValueFieldInterval = numericUpDownInterval.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (currentValueFieldInterval != null)
                    {
                        Byte[] payload = { new_payload[1], new_payload[2] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    ushort value = BitConverter.ToUInt16(payload, 0);
                        currentValueFieldInterval.SetValue(numericUpDownInterval, Convert.ToDecimal(value));
                        numericUpDownInterval.Text = value.ToString();
                    }
                ushort N1 = 0;
                var currentValueFieldN1 = numericUpDownN1.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldN1 != null)
                {
                    Byte[] payload = { new_payload[3], new_payload[4] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    N1 = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldN1.SetValue(numericUpDownN1, Convert.ToDecimal(N1));
                    numericUpDownN1.Text = N1.ToString();
                }
                ushort offset = 5;
                for(int i = 0; i < N1; i++, offset+=2)
                {
                    Byte[] payload = { new_payload[offset], new_payload[offset+1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    ushort paramID = BitConverter.ToUInt16(payload, 0);
                    Label tmpLabel = new Label();
                        tmpLabel.Text = "Parameter ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        parametersLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.Value = paramID;
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        parametersList.Add(tmp);
                        this.Controls.Add(tmp);

                }
                ushort NFA = 0;
                var currentValueFieldNFA = numericUpDownNFA.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentValueFieldNFA != null)
                {
                    Byte[] payload = { new_payload[offset], new_payload[offset+1] };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(payload);
                    NFA = BitConverter.ToUInt16(payload, 0);
                    currentValueFieldNFA.SetValue(numericUpDownNFA, Convert.ToDecimal(NFA));
                    numericUpDownNFA.Text = NFA.ToString();
                }
                offset += 2;

                for (int i = 0; i < NFA; i++)
                {
                    
                    var repetition = Convert.ToDecimal(new_payload[offset++]);
                    Label tmpLabelRep = new Label();
                    tmpLabelRep.Text = "Repetition #" + i.ToString();
                    tmpLabelRep.Size = new System.Drawing.Size(100, 20);
                    tmpLabelRep.Location = new System.Drawing.Point(210, i * 60 + numericUpDownNFA.Location.Y + 30);
                    superConmRepetitionLabelList.Add(tmpLabelRep);
                    this.Controls.Add(tmpLabelRep);
                    NumericUpDown tmpRep = new NumericUpDown();
                    tmpRep.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                    tmpRep.Size = new System.Drawing.Size(68, 20);
                    tmpRep.Location = new System.Drawing.Point(310, i * 60 + numericUpDownNFA.Location.Y + 30);
                    tmpRep.Value = repetition;
                    tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                    superConmRepetitionList.Add(tmpRep);
                    this.Controls.Add(tmpRep);

                    var N2 = Convert.ToDecimal(new_payload[offset++]);

                    Label tmpLabelN2 = new Label();
                    tmpLabelN2.Text = "N2 #" + i.ToString();
                    tmpLabelN2.Size = new System.Drawing.Size(100, 20);
                    tmpLabelN2.Location = new System.Drawing.Point(210, i * 60 + numericUpDownNFA.Location.Y + 60);
                    superConmN2LabelList.Add(tmpLabelN2);
                    this.Controls.Add(tmpLabelN2);
                    NumericUpDown tmpN2 = new NumericUpDown();
                    tmpN2.Maximum = new decimal(new int[] {
                            255,
                            0,
                            0,
                            0});
                    tmpN2.Size = new System.Drawing.Size(68, 20);
                    tmpN2.Location = new System.Drawing.Point(310, i * 60 + numericUpDownNFA.Location.Y + 60);

                    tmpN2.Value = N2;
                    tmpN2.Tag = i;
                    tmpN2.ValueChanged += new System.EventHandler(this.numericUpDownN2_ValueChanged);
                    superConmN2List.Add(tmpN2);
                    this.Controls.Add(tmpN2);
                    superConmN2ParametersList.Add(new List<NumericUpDown>());
                    superConmN2ParametersLabelList.Add(new List<Label>());

                    for (int j = 0; j < N2; j++, offset += 2)
                    {
                        Byte[] payloadParam = { new_payload[offset], new_payload[offset + 1] };
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(payloadParam);
                        ushort paramID = BitConverter.ToUInt16(payloadParam, 0);
                        Label tmpLabelRepN2 = new Label();
                        tmpLabelRepN2.Text = "Parameter ID #" + j.ToString();
                        tmpLabelRepN2.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelRepN2);
                        NumericUpDown tmpRepN2 = new NumericUpDown();
                        tmpRepN2.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpRepN2.Size = new System.Drawing.Size(68, 20);
                        
                        tmpRepN2.Value = paramID;
                        tmpRepN2.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        superConmN2ParametersList[i].Add(tmpRepN2);
                        this.Controls.Add(tmpRepN2);
                        superConmN2ParametersLabelList[i].Add(tmpLabelRepN2);
                        this.Controls.Add(tmpLabelRepN2);

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
            Int32 offset = 193;
            payload.Clear();
            payload.Add(decimal.ToByte(numericUpDownStructID.Value));
            byte[] intervalBytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(numericUpDownInterval.Value));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intervalBytes);
            payload.Add(intervalBytes[0]);
            payload.Add(intervalBytes[1]);

            byte[] N1 = BitConverter.GetBytes((ushort)parametersList.Count);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(N1);
            payload.Add(N1[0]);
            payload.Add(N1[1]);

            for (int i = 0; i < parametersList.Count; i++)
            {
                byte[] parameterID = BitConverter.GetBytes((ushort)decimal.ToUInt16(parametersList[i].Value));
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(parameterID);
                payload.Add(parameterID[0]);
                payload.Add(parameterID[1]);
                offset += 30;
                parametersLabelList[i].Location = new System.Drawing.Point(150, offset);
                parametersList[i].Location = new System.Drawing.Point(250, offset);
            }
            offset += 30;
            labelNFA.Location = new Point(labelNFA.Location.X, offset);
            numericUpDownNFA.Location = new Point(numericUpDownNFA.Location.X, offset);
            
            byte[] NFABytes = BitConverter.GetBytes((ushort)decimal.ToUInt16(superConmRepetitionList.Count));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(NFABytes);
            payload.Add(NFABytes[0]);
            payload.Add(NFABytes[1]);
            for (int j = 0; j < superConmRepetitionList.Count; j++)
            {
                offset += 30;
                superConmRepetitionLabelList[j].Location = new System.Drawing.Point(150, offset);
                superConmRepetitionList[j].Location = new System.Drawing.Point(250, offset);
                offset += 30;
                superConmN2LabelList[j].Location = new System.Drawing.Point(150, offset);
                superConmN2List[j].Location = new System.Drawing.Point(250, offset);
                
                payload.Add(decimal.ToByte(superConmRepetitionList[j].Value));
                payload.Add(decimal.ToByte(superConmN2ParametersList[j].Count));
                for (int h = 0; h < superConmN2ParametersList[j].Count; h++)
                {
                    offset += 30;
                    superConmN2ParametersLabelList[j][h].Location = new System.Drawing.Point(250, offset);
                    superConmN2ParametersList[j][h].Location = new System.Drawing.Point(350, offset);
                    byte[] superParameterID = BitConverter.GetBytes((ushort)decimal.ToUInt16(superConmN2ParametersList[j][h].Value));
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(superParameterID);
                    payload.Add(superParameterID[0]);
                    payload.Add(superParameterID[1]);
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
            if (numericUpDownN1.Value != parametersList.Count)
            {
                if (numericUpDownN1.Value < parametersList.Count)
                {
                    for (int i = parametersList.Count - 1; numericUpDownN1.Value < parametersList.Count; i--)
                    {
                        this.Controls.Remove(parametersList[i]);
                        parametersList.Remove(parametersList[i]);
                        this.Controls.Remove(parametersLabelList[i]);
                        parametersLabelList.Remove(parametersLabelList[i]);
                    }
                }
                else if (numericUpDownN1.Value > parametersList.Count)
                {
                    for (int i = parametersList.Count; numericUpDownN1.Value > parametersList.Count; i++)
                    {
                        Label tmpLabel = new Label();
                        tmpLabel.Text = "Parameter ID #" + i.ToString();
                        tmpLabel.Size = new System.Drawing.Size(100, 20);
                        parametersLabelList.Add(tmpLabel);
                        this.Controls.Add(tmpLabel);
                        NumericUpDown tmp = new NumericUpDown();
                        tmp.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmp.Size = new System.Drawing.Size(68, 20);
                        tmp.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        parametersList.Add(tmp);
                        this.Controls.Add(tmp);
                    }
                }
                updatePayloadAndGUI();
            }
        }

        private void numericUpDownNFA_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownNFA.Value != superConmRepetitionList.Count)
            {
                if (numericUpDownNFA.Value < superConmRepetitionList.Count)
                {
                    for (int i = superConmRepetitionList.Count - 1; numericUpDownNFA.Value < superConmRepetitionList.Count; i--)
                    {
                        this.Controls.Remove(superConmRepetitionList[i]);
                        superConmRepetitionList.Remove(superConmRepetitionList[i]);
                        this.Controls.Remove(superConmRepetitionLabelList[i]);
                        superConmRepetitionLabelList.Remove(superConmRepetitionLabelList[i]);
                        this.Controls.Remove(superConmN2List[i]);
                        superConmN2List.Remove(superConmN2List[i]);
                        this.Controls.Remove(superConmN2LabelList[i]);
                        superConmN2LabelList.Remove(superConmN2LabelList[i]);
                        for (int j = 0; j < superConmN2ParametersList[i].Count; j++)
                            this.Controls.Remove(superConmN2ParametersList[i][j]);
                        superConmN2ParametersList.Remove(superConmN2ParametersList[i]);
                        for (int j = 0; j < superConmN2ParametersLabelList[i].Count; j++)
                            this.Controls.Remove(superConmN2ParametersLabelList[i][j]);
                        superConmN2ParametersLabelList.Remove(superConmN2ParametersLabelList[i]);
                    }
                }
                else if (numericUpDownNFA.Value > superConmRepetitionList.Count)
                {
                    for (int i = superConmRepetitionList.Count; numericUpDownNFA.Value > superConmRepetitionList.Count; i++)
                    {
                        Label tmpLabelRep = new Label();
                        tmpLabelRep.Text = "Repetition #" + i.ToString();
                        tmpLabelRep.Size = new System.Drawing.Size(100, 20);
                        superConmRepetitionLabelList.Add(tmpLabelRep);
                        this.Controls.Add(tmpLabelRep);
                        NumericUpDown tmpRep = new NumericUpDown();
                        tmpRep.Maximum = new decimal(new int[] {
                            65535,
                            0,
                            0,
                            0});
                        tmpRep.Size = new System.Drawing.Size(68, 20);
                        tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        superConmRepetitionList.Add(tmpRep);
                        this.Controls.Add(tmpRep);

                        Label tmpLabelN2 = new Label();
                        tmpLabelN2.Text = "N2 #" + i.ToString();
                        tmpLabelN2.Size = new System.Drawing.Size(100, 20);
                        superConmN2LabelList.Add(tmpLabelN2);
                        this.Controls.Add(tmpLabelN2);
                        NumericUpDown tmpN2 = new NumericUpDown();
                        tmpN2.Maximum = new decimal(new int[] {
                            255,
                            0,
                            0,
                            0});
                        tmpN2.Size = new System.Drawing.Size(68, 20);
                        tmpN2.Tag = i;
                        tmpN2.ValueChanged += new System.EventHandler(this.numericUpDownN2_ValueChanged);
                        //new System.EventHandler(this.numericUpDownN2_ValueChanged, i);
                        superConmN2List.Add(tmpN2);
                        this.Controls.Add(tmpN2);
                        superConmN2ParametersList.Add(new List<NumericUpDown>());
                        superConmN2ParametersLabelList.Add(new List<Label>());
                    }
                }
                updatePayloadAndGUI();
            }
        }

        private void numericUpDownN2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            int i = (int)numericUpDown.Tag;
  
            if (numericUpDown.Value != superConmN2ParametersList[i].Count)
            {
                if (numericUpDown.Value < superConmN2ParametersList[i].Count)
                {
                    for (int j = superConmN2ParametersList[i].Count - 1; numericUpDown.Value < superConmN2ParametersList[i].Count; j--)
                    {

                        this.Controls.Remove(superConmN2ParametersList[i][j]);
                        superConmN2ParametersList[i].Remove(superConmN2ParametersList[i][j]);
                        this.Controls.Remove(superConmN2ParametersLabelList[i][j]);
                        superConmN2ParametersLabelList[i].Remove(superConmN2ParametersLabelList[i][j]);
                    }
                }
                else if (numericUpDown.Value > superConmN2ParametersList[i].Count)
                {
                    for (int j = superConmN2ParametersList[i].Count; numericUpDown.Value > superConmN2ParametersList[i].Count; j++)
                    {
                        Label tmpLabelRep = new Label();
                        tmpLabelRep.Text = "Parameter ID #" + j.ToString();
                        tmpLabelRep.Size = new System.Drawing.Size(100, 20);

                        this.Controls.Add(tmpLabelRep);
                        NumericUpDown tmpRep = new NumericUpDown();
                        tmpRep.Maximum = new decimal(new int[] {
                        65535,
                        0,
                        0,
                        0});
                        tmpRep.Size = new System.Drawing.Size(68, 20);
                        tmpRep.ValueChanged += new System.EventHandler(this.numericUpDownGeneric_ValueChanged);
                        superConmN2ParametersList[i].Add(tmpRep);
                        this.Controls.Add(tmpRep);
                        superConmN2ParametersLabelList[i].Add(tmpLabelRep);
                        this.Controls.Add(tmpLabelRep);
                    }
                }
                updatePayloadAndGUI();
            }
        }

        private void numericUpDownInterval_ValueChanged(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }

        private void numericUpDownInterval_ValueChanged_1(object sender, EventArgs e)
        {
            updatePayloadAndGUI();
        }
    }
}
