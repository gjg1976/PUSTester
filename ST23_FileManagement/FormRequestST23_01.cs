using System;
using System.IO;
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
    public partial class FormRequestST23_01 : Form
    {
        public List<NumericUpDown> structuresList = new List<NumericUpDown>();
        public List<Label> structuresLabelList = new List<Label>();
        public List<byte> payload = new List<byte>();
        private List<byte> new_payload = null;

        public FormRequestST23_01()
        {
            InitializeComponent();
            this.new_payload = StaticPayload.PayloadList;
            int offset = 0;
            if (new_payload.Count > 0)
            {
                Byte[] payloadPathSize = { new_payload[offset], new_payload[offset + 1] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadPathSize);
                UInt16 filepathSize = BitConverter.ToUInt16(payloadPathSize, 0);
                Byte[] filepath = new byte[filepathSize];
                offset += 2;
                for (int j = 0; j < filepathSize; j++, offset++)
                    filepath[j] = new_payload[offset];

                Byte[] payloadfileSize = { new_payload[offset], new_payload[offset + 1] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadfileSize);
                UInt16 filenameSize = BitConverter.ToUInt16(payloadfileSize, 0);
                Byte[] filename = new byte[filenameSize];
                offset += 2;
                for (int j = 0; j < filenameSize; j++, offset++)
                    filename[j] = new_payload[offset];

                textBoxFilePath.Text = System.Text.Encoding.UTF8.GetString(filepath) +
                                        System.Text.Encoding.UTF8.GetString(filename);

                Byte[] payloadfileMaxSize = { new_payload[offset], new_payload[offset + 1], new_payload[offset + 2], new_payload[offset + 3] };
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(payloadfileMaxSize);
                UInt32 fileMaxSize = BitConverter.ToUInt32(payloadfileMaxSize, 0);
                numericUpDownMaxSize.Value = fileMaxSize;
                if (new_payload[offset + 4] > 0)
                    checkBoxLocked.Checked = true;
            }
        }

        void updatePayload()
        {
            payload.Clear();
            string filename = Path.GetFileName(textBoxFilePath.Text);
            string filepath = "";
            if (filename.Length > 0)
                filepath = textBoxFilePath.Text.Replace(filename, "");

            UInt16 count = (UInt16)filepath.Length;

            payload.Add((byte)(count >> 8));
            payload.Add((byte)(count & 0xff));

            byte[] bytesFilepath = Encoding.ASCII.GetBytes(filepath);
            foreach (byte b in bytesFilepath)
                payload.Add(b);

            count = (UInt16)filename.Length;

            payload.Add((byte)(count >> 8));
            payload.Add((byte)(count & 0xff));

            byte[] bytesFilename = Encoding.ASCII.GetBytes(filename);
            foreach (byte b in bytesFilename)
                payload.Add(b);

            UInt32 size = Convert.ToUInt32(numericUpDownMaxSize.Value);

            payload.Add((byte)((size >> 24) & 0xff));
            payload.Add((byte)((size >> 16) & 0xff));
            payload.Add((byte)((size >> 8) & 0xff));
            payload.Add((byte)(size & 0xff));

            if(checkBoxLocked.Checked)
                payload.Add(1);
            else
                payload.Add(0);

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

        private void textBoxFunctionName_TextChanged(object sender, EventArgs e)
        {
            updatePayload();
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

        private void numericUpDownMaxSize_ValueChanged(object sender, EventArgs e)
        {
            updatePayload();
        }

        private void checkBoxLocked_CheckedChanged(object sender, EventArgs e)
        {
            updatePayload();
        }
    }
}
