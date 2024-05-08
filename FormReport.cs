using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PUS_tester
{
    public partial class FormReport : Form
    {
        Int32 parameter_id = 0;
        ushort strSize = 0;
        string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PUSTester\\";
        public FormReport(string xml_name, byte[] data_in, bool enableCRC, ushort CRC,
            ushort OBTType, bool PField, ushort BasicTimeSize, ushort FracTimeSize)
        {
            InitializeComponent();

            int obt_size = BasicTimeSize + FracTimeSize;
            if (PField) obt_size++;

            if (data_in.Length < Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER + obt_size)
            {
                return;
            }

            ushort ApplicationId = (ushort)((data_in[0] << 8) | data_in[1]);
            if ((ApplicationId & 0xE000) != 0)
            {
                //Error wrong CCSDS Packet Version
                return;
            }


            if ((ApplicationId & 0x0800) == 0)
            {
                //Error not Secondary Header
                return;
            }
            ApplicationId &= 0x07FF;

            if ((data_in[2] & 0xc0) != 0xc0)
            {
                return;
            }

            ushort packetSequenceCount = (ushort)(((data_in[2] << 8) | data_in[3]) & (~0xc000));

            ushort packetDataLength = (ushort)((data_in[4] << 8) | data_in[5]);

            byte PUSVersion = (byte)(data_in[6] >> 4);

            byte serviceType = data_in[7];

            byte serviceSubType = data_in[8];
            
            ushort messageTypeCounter = (ushort)((data_in[9] << 8) | data_in[10]);

            ushort destinationId = (ushort)((data_in[11] << 8) | data_in[12]);

            if (enableCRC)
            {
                ushort dataCRC = (ushort)((data_in[data_in.Length - 2] << 8) | data_in[data_in.Length - 1]);
                if (dataCRC == CRC)
                {
                    labelCRC.Text = "CRC match";
                    labelCRC.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else
                {
                    labelCRC.Text = "CRC error";
                    labelCRC.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
           
            ushort offset = Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER ;
            
            if (PField) offset++;

            uint obt_data = 0;
            uint obt_frac_data = 0;

            switch (BasicTimeSize)
            {
                case 1:
                    obt_data = (uint)(data_in[offset]);
                    offset++;
                    break;
                case 2:
                    obt_data = (uint)((data_in[offset] << 8) | data_in[offset + 1]);
                    offset+=2;
                    break;
                case 3:
                    obt_data = (uint)((data_in[offset] << 16) | (data_in[offset + 1] << 8) | data_in[offset + 2]);
                    offset += 3;
                    break;
                case 4:
                    obt_data = (uint)((data_in[offset] << 24) | (data_in[offset + 1] << 16) | (data_in[offset + 2] << 8) | data_in[offset + 3]);
                    offset += 4;
                    break;
            }
            switch (FracTimeSize)
            {
                case 0:
                    obt_frac_data = 0;
                    break;
                case 1:
                    obt_frac_data = (uint)(data_in[offset]);
                    break;
                case 2:
                    obt_frac_data = (uint)((data_in[offset] << 8) | data_in[offset + 1]);
                    break;
                case 3:
                    obt_frac_data = (uint)((data_in[offset] << 16) | (data_in[offset + 1] << 8) | data_in[offset + 2]);
                    break;
            }

            textBoxPktVersion.Text = ((data_in[0] >> 5) & 0x07).ToString();
            if ((data_in[0] & 0x10) != 0) checkBoxPktTypeTC.Checked = true;
            else checkBoxPktTypeTM.Checked = true;
            if ((data_in[0] & 0x08) != 0) checkBoxSecondaryHeader.Checked = true; 
            else checkBoxPktTypeTM.Checked = true;
            textBoxAPID.Text = ApplicationId.ToString();
            textBoxSeqFlags.Text =((data_in[2] >> 6) & 0x03).ToString();
            textBoxSeqCounter.Text = packetSequenceCount.ToString();
            textBoxSize.Text = packetDataLength.ToString();

            textBoxPUSVersion.Text = PUSVersion.ToString();
            textBoxSCTimeRef.Text = (data_in[6] & 0x0f).ToString();
            textBoxMsgCounter.Text = messageTypeCounter.ToString();
            textBoxDstID.Text = destinationId.ToString();
            textBoxServiceType.Text =  serviceType.ToString();
            textBoxServiceSubType.Text = serviceSubType.ToString();
            textBoxOBT.Text = obt_data.ToString();
            textBoxOBTFrac.Text = obt_frac_data.ToString();

            string logcmd = "";//!< Crea una variable string temporal para el log  de la GUI
            int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
            logcmd += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
            for (; hcmd < data_in.Length;)
            {
                byte _b = data_in[hcmd];//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
                logcmd += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                if (++hcmd % 24 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                {
                    logcmd += Environment.NewLine;//!< Se debe pasar a una nueva linea
                    logcmd += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                    continue;//!< Continua con el proximo byte
                }
                else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                {
                    logcmd += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                }
            }
            textBoxPayload.Text = logcmd;

            XDocument guiConfig = XDocument.Load(xml_name);

            // XElement item = (from xml2 in guiConfig.Elements("xml").Elements("template") select xml2).FirstOrDefault();

            int repetitions = 0;

            Int32 win_length = -450;
            Int32 pos_y = 107;
            ushort init_offset = 0;
            // this.Text = item.Attribute("name").Value;
            foreach (XElement template in from y in guiConfig.Descendants("template") select y)
            {
                this.Text = template.Attribute("name").Value;
                this.Size = new Size(Int32.Parse(template.Attribute("l").Value), Int32.Parse(template.Attribute("h").Value));

                Int32 tab_length = -730;
                foreach (XElement item in from y in guiConfig.Descendants("item") select y)
                {
                    Control tmp = new Control();
                    string item_type = item.Attribute("type").Value;
                    
                    switch (item_type)
                    {
                        case "Label":
                            tmp = new Label();
                            break;
                        case "CheckBox":
                            tmp = new CheckBox();
                            break;
                        case "Button":
                            tmp = new Button();
                            break;
                        case "TextBox":
                            tmp = new TextBox();
                            break;
                        case "Repeater":
                            switch (item.Attribute("data_type").Value)
                            {
                                case "int8":
                                case "uint8":
                                    repetitions = ParseInt8(item, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                    break;
                                case "int16":
                                    repetitions = ParseInt16(item, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                    break;
                                case "uint16":
                                    repetitions = ParseUInt16(item, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                    break;
                            }
                            if (repetitions > 0)
                            {
                                for (int i = 0; i < repetitions; i++)
                                {
                                    pos_y += Int32.Parse(item.Attribute("y").Value);
                                    pos_y = ParseRepeater(item, obt_size, data_in,i, pos_y, ref init_offset);
                                }
                            }
                              continue;
                        case "ListRepeater":
                            string[] list = item.Attribute("data_list").Value.Split(',');

                            foreach (string parameter in list)//!< Itera por toda la lista de comandos y telemetrias y,
                            {
                                parameter_id = Convert.ToInt32(parameter);
                                pos_y += Int32.Parse(item.Attribute("y").Value);
                                pos_y = ParseRepeater(item, obt_size, data_in, parameter_id , pos_y, ref init_offset);
                            }
                            continue;
                        case "ComboBox":
                            tmp = new ComboBox();

                            foreach (XElement childitem in from y in item.Elements() select y)
                            {
                                string option = childitem.Attribute("label").Value;
                                ((ComboBox)tmp).Items.Add(option);
                                
                            }
                            break;
                    }
                    pos_y += Int32.Parse(item.Attribute("y").Value);

                    tmp.Name = item.Attribute("name").Value;
                    tmp.Text = item.Attribute("text").Value;

                    tmp.Location = new Point(Int32.Parse(item.Attribute("x").Value), pos_y);
                    tmp.Size = new Size(Int32.Parse(item.Attribute("l").Value), Int32.Parse(item.Attribute("h").Value));

                    if (item_type == "TextBox" || item_type == "CheckBox" || item_type == "ComboBox")
                        {
                            switch (item.Attribute("data_type").Value)
                            {
                            case "bool":
                            case "int8":
                            case "sint8":
                            case "uint8":
                                    byte int8_data = ParseInt8(item, obt_size, data_in, init_offset);
                                    if (item_type == "TextBox")
                                    {
                                        tmp.Text = int8_data.ToString();
                                    }
                                    else if(item_type == "CheckBox")
                                    {
                                        if (int8_data != 0)
                                            ((CheckBox)tmp).Checked = true;
                                    }
                                    else if (item_type == "ComboBox")
                                    {
                                        ((ComboBox)tmp).SelectedIndex = int8_data;
                                    }
                                init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                                case "int16":
                            case "sint16":
                                tmp.Text = ParseInt16(item, obt_size, data_in, init_offset).ToString();
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                                case "uint16":
                                    tmp.Text = ParseUInt16(item, obt_size, data_in, init_offset).ToString();
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                                case "int32":
                            case "sint32":
                                tmp.Text = ParseInt32(item, obt_size, data_in, init_offset).ToString();
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                            case "uint32":
                                    tmp.Text = ParseUInt32(item, obt_size, data_in, init_offset).ToString();
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                            case "int64":
                            case "sint64":
                                tmp.Text = ParseInt64(item, obt_size, data_in, init_offset).ToString();
                                init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                            case "uint64":
                                tmp.Text = ParseUInt64(item, obt_size, data_in, init_offset).ToString();
                                init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                            case "double":
                                    tmp.Text = ParseDouble(item, obt_size, data_in, init_offset).ToString();
                                    init_offset += Convert.ToUInt16(item.Attribute("data_size").Value, 16); ;
                                break;
                            case "str":
                                ushort size = Convert.ToUInt16(item.Attribute("data_size").Value, 16);
                                tmp.Text = ParseString(item, obt_size, data_in, init_offset, size);
                                init_offset += strSize;
                                break;
                            case "request":
                                tmp.Text = ParseRequest(item, obt_size, data_in, init_offset);
                                init_offset += strSize;
                                break;
                        }
                    }
                    groupBoxPayload.Controls.Add(tmp);

                }
                tab_length += pos_y;
                groupBoxPayload.Size = new Size((Int32)540, Int32.Parse(template.Attribute("h").Value) + tab_length);
            }

            
            win_length += pos_y;
            this.Height += win_length;
        }

        public Int32 ParseRepeater(XElement item, int obt_size, byte[] data_in, int parent_repetitions, Int32 pos_y, ref ushort init_offset)
        {
            //ushort init_offset += ushort.Parse(item.Attribute("data_offset").Value);
            int repetitions = 0;

               foreach (XElement childitem in from y in item.Elements() select y)
                {
                    Control tmp = new Control();
                    string item_type = childitem.Attribute("type").Value;
                   // pos_y += Int32.Parse(childitem.Attribute("y").Value);

                    switch (item_type)
                    {
                        case "Label":
                            tmp = new Label();
                            break;
                        case "CheckBox":
                            tmp = new CheckBox();
                            break;
                        case "TextBox":
                            tmp = new TextBox();
                            break;
                        case "Repeater":
                            switch (childitem.Attribute("data_type").Value)
                            {
                                case "int8":
                            case "sint8":
                            case "uint8":
                                    repetitions = ParseInt8(childitem, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(childitem.Attribute("data_size").Value, 16); ;
                                    break;
                                case "int16":
                            case "sint16":
                                repetitions = ParseInt16(childitem, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(childitem.Attribute("data_size").Value, 16); ;
                                break;
                                case "uint16":
                                    repetitions = ParseUInt16(childitem, obt_size, data_in, init_offset);
                                    init_offset += Convert.ToUInt16(childitem.Attribute("data_size").Value, 16); ;
                                break;
                            }

                            if (repetitions > 0)
                            {
                               for(int i = 0; i < repetitions; i++) { 
                                    pos_y += Int32.Parse(childitem.Attribute("y").Value);
                                    pos_y = ParseRepeater(childitem, obt_size, data_in, i, pos_y, ref init_offset);
                                } 
                            }


                            continue;
                    case "ListRepeater":
                        string[] list = item.Attribute("data_list").Value.Split(',');

                        foreach (string parameter in list)//!< Itera por toda la lista de comandos y telemetrias y,
                        {
                            parameter_id = Convert.ToInt32(parameter);
                            pos_y += Int32.Parse(item.Attribute("y").Value);
                            pos_y = ParseRepeater(item, obt_size, data_in, parameter_id, pos_y, ref init_offset);
                        }
                        continue;
                    case "ComboBox":
                        tmp = new ComboBox();
                        UInt16 offset = Convert.ToUInt16(childitem.Attribute("data_size").Value, 16);
                        byte int8_data = ParseInt8(childitem, obt_size, data_in, init_offset);
                        init_offset += offset;
                        tmp.Name = childitem.Attribute("name").Value + parent_repetitions.ToString();
                        tmp.Location = new Point(Int32.Parse(childitem.Attribute("x").Value), pos_y);
                        tmp.Size = new Size(Int32.Parse(childitem.Attribute("l").Value), Int32.Parse(childitem.Attribute("h").Value));
                        groupBoxPayload.Controls.Add(tmp);
                        foreach (XElement comboitem in from y in childitem.Elements() select y)
                        {
                            if (int8_data == Byte.Parse(comboitem.Attribute("value").Value))
                            {
                                string option = comboitem.Attribute("label").Value;
                                ((ComboBox)tmp).Items.Add(option);

                                pos_y += Int32.Parse(childitem.Attribute("y").Value);
                                pos_y = ParseRepeater(comboitem, obt_size, data_in, parameter_id, pos_y, ref init_offset);
                            }
                        }
                        ((ComboBox)tmp).SelectedIndex = 0;
                        continue;
                }
                pos_y += Int32.Parse(childitem.Attribute("y").Value);


                tmp.Name = childitem.Attribute("name").Value + parent_repetitions.ToString();

                tmp.Text = childitem.Attribute("text").Value + parent_repetitions.ToString();

                tmp.Location = new Point(Int32.Parse(childitem.Attribute("x").Value), pos_y);
                tmp.Size = new Size(Int32.Parse(childitem.Attribute("l").Value), Int32.Parse(childitem.Attribute("h").Value));

                if (item_type == "TextBox" || item_type == "CheckBox")
                {
                    string parse_case = childitem.Attribute("data_type").Value;
                    UInt16 offset = Convert.ToUInt16(childitem.Attribute("data_size").Value, 16);

                    if (parse_case == "id")
                    {
                        getTypeAndSizeFromID(ref parse_case, ref offset);
                    }
                    switch (parse_case)
                    {
                        case "bool":
                        case "int8":
                        case "sint8":
                        case "uint8":
                            byte int8_data = ParseInt8(childitem, obt_size, data_in, init_offset);
                            if (item_type == "TextBox")
                            {
                                tmp.Text = int8_data.ToString();
                            }
                            else if (item_type == "CheckBox")
                            {
                                if (int8_data != 0)
                                    ((CheckBox)tmp).Checked = true;
                            }
                            init_offset += offset;
                            break;
                        case "int16":
                        case "sint16":
                            tmp.Text = ParseInt16(childitem, obt_size, data_in, init_offset).ToString();
                            init_offset += offset; 
                            break;
                        case "uint16":
                                tmp.Text = ParseUInt16(childitem, obt_size, data_in, init_offset).ToString();
                                init_offset += offset;
                            break;
                        case "int32":
                        case "sint32":
                            tmp.Text = ParseInt32(childitem, obt_size, data_in, init_offset).ToString();
                                init_offset += offset;
                            break;
                        case "uint32":
                            tmp.Text = ParseUInt32(childitem, obt_size, data_in, init_offset).ToString();
                                init_offset += offset;
                            break;
                        case "int64":
                        case "sint64":
                            tmp.Text = ParseInt64(childitem, obt_size, data_in, init_offset).ToString();
                            init_offset += offset;
                            break;
                        case "uint64":
                            tmp.Text = ParseUInt64(childitem, obt_size, data_in, init_offset).ToString();
                            init_offset += offset;
                            break;
                        case "double":
                                tmp.Text = ParseDouble(childitem, obt_size, data_in, init_offset).ToString();
                                init_offset += offset;
                            break;
                        case "str":
                            tmp.Text = ParseString(childitem, obt_size, data_in, init_offset, offset);
                            init_offset += strSize;
                            break;
                        case "request":
                            tmp.Text = ParseRequest(childitem, obt_size, data_in, init_offset);
                            init_offset += strSize;
                            break;
                    }
                }
                try
                {   if(childitem.Attribute("id") != null)
                        if(Convert.ToBoolean(childitem.Attribute("id").Value))
                            parameter_id = Convert.ToInt32(tmp.Text);
                }
                catch {
                    parameter_id = 0;

                }
                groupBoxPayload.Controls.Add(tmp);

                }

            return pos_y;
        }

        public byte ParseInt8(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort int8_offset = 0;// ushort.Parse(item.Attribute("data_offset").Value);
            int8_offset += init_offset;
            int8_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            int8_offset += (ushort)obt_size;
            byte int8_mask = 0;
            if (item.Attribute("data_mask").Value == "-1")
                int8_mask = Convert.ToByte("0xff", 16);
            else
                int8_mask = Convert.ToByte(item.Attribute("data_mask").Value, 16);

            byte int8_shift = Convert.ToByte(item.Attribute("data_shift").Value, 16);
            byte int8_data = (byte)((data_in[int8_offset] >> int8_shift) & int8_mask);
            return int8_data;
        }

        public byte ParseUInt8(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort uint8_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            uint8_offset += init_offset;
            uint8_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            uint8_offset += (ushort)obt_size;
            byte uint8_mask = 0;
            if (item.Attribute("data_mask").Value == "-1") 
                uint8_mask = Convert.ToByte("0xff", 16);
            else
                uint8_mask = Convert.ToByte(item.Attribute("data_mask").Value, 16);
            byte uint8_shift = Convert.ToByte(item.Attribute("data_shift").Value, 16);
            byte uint8_data = (byte)((data_in[uint8_offset] >> uint8_shift) & uint8_mask);
            return uint8_data;
        }
        public short ParseInt16(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort int16_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            int16_offset += init_offset;
            int16_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            int16_offset += (ushort)obt_size;
            short int16_mask = 0;
            if (item.Attribute("data_mask").Value == "-1") 
                int16_mask = Convert.ToInt16("0xffff", 16);
            else
                int16_mask = Convert.ToInt16(item.Attribute("data_mask").Value, 16);
            short int16_shift = Convert.ToInt16(item.Attribute("data_shift").Value, 16);
            short int16_data = (short)((((data_in[int16_offset] << 8) | data_in[int16_offset + 1]) >> int16_shift) & int16_mask);
            return int16_data;
        }

        public ushort ParseUInt16(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort uint16_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            uint16_offset += init_offset;
            uint16_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            uint16_offset += (ushort)obt_size;
            short uint16_mask = 0;
            if (item.Attribute("data_mask").Value == "-1") 
                uint16_mask = Convert.ToInt16("0xffff", 16);
            else
                uint16_mask = Convert.ToInt16(item.Attribute("data_mask").Value, 16);
            short uint16_shift = Convert.ToInt16(item.Attribute("data_shift").Value, 16);
            ushort uint16_data = (ushort)((((data_in[uint16_offset] << 8) | data_in[uint16_offset + 1]) >> uint16_shift) & uint16_mask);
            return uint16_data;
        }

        public Int32 ParseInt32(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort int32_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            int32_offset += init_offset;
            int32_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            int32_offset += (ushort)obt_size;
            Int32 int32_mask = 0;
            if (item.Attribute("data_mask").Value == "-1")
                int32_mask = Convert.ToInt32("0xffffffff", 16);
            else 
                int32_mask = Convert.ToInt32(item.Attribute("data_mask").Value, 16);
            Int32 int32_shift = Convert.ToInt32(item.Attribute("data_shift").Value, 16);
            Int32 int32_data = (Int32)((((data_in[int32_offset] << 24) | (data_in[int32_offset + 1] << 16) |
                                (data_in[int32_offset + 2] << 8) | data_in[int32_offset + 3]) >> int32_shift) & int32_mask);
            return int32_data;
        }

        public UInt32 ParseUInt32(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort uint32_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            uint32_offset += init_offset;
            uint32_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            uint32_offset += (ushort)obt_size;
            Int32 uint32_mask = 0;
            if (item.Attribute("data_mask").Value == "-1")
                uint32_mask = Convert.ToInt32("0xffffffff", 16);
            else
                uint32_mask = Convert.ToInt32(item.Attribute("data_mask").Value, 16);
            Int32 uint32_shift = Convert.ToInt32(item.Attribute("data_shift").Value, 16);
            UInt32 uint32_data = (UInt32)((((data_in[uint32_offset] << 24) | (data_in[uint32_offset + 1] << 16) |
                                (data_in[uint32_offset + 2] << 8) | data_in[uint32_offset + 3]) >> uint32_shift) & uint32_mask);
            return uint32_data;
        }
        public Int64 ParseInt64(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort int64_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            int64_offset += init_offset;
            int64_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            int64_offset += (ushort)obt_size;
            Int64 int64_mask = 0;
            if (item.Attribute("data_mask").Value == "-1")
                int64_mask = Convert.ToInt64("0xffffffffffffffff", 16);
            else
                int64_mask = Convert.ToInt64(item.Attribute("data_mask").Value, 16);
            Int64 int64_shift = Convert.ToInt64(item.Attribute("data_shift").Value, 16);
            Int64 int64_data = ((((Int64)data_in[int64_offset]) << 56) | (((Int64)data_in[int64_offset+1]) << 48) |
                (((Int64)data_in[int64_offset+2]) << 40) | (((Int64)data_in[int64_offset+3]) << 32) |
                (((Int64)data_in[int64_offset+4]) << 24) | (((Int64)data_in[int64_offset+5]) << 16) |
                (((Int64)data_in[int64_offset+6]) << 8) | ((Int64)data_in[int64_offset+7])) & int64_mask;

            return int64_data;
        }

        public UInt64 ParseUInt64(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort uint64_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            uint64_offset += init_offset;
            uint64_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            uint64_offset += (ushort)obt_size;
            UInt64 uint64_mask = 0;
            if (item.Attribute("data_mask").Value == "-1")
                uint64_mask = Convert.ToUInt64("0xffffffffffffffff", 16);
            else
                uint64_mask = Convert.ToUInt64(item.Attribute("data_mask").Value, 16);
            UInt64 uint64_shift = Convert.ToUInt64(item.Attribute("data_shift").Value, 16);
            UInt64 uint64_data = ((((UInt64)data_in[uint64_offset]) << 56) | (((UInt64)data_in[uint64_offset + 1]) << 48) |
                (((UInt64)data_in[uint64_offset + 2]) << 40) | (((UInt64)data_in[uint64_offset + 3]) << 32) |
                (((UInt64)data_in[uint64_offset + 4]) << 24) | (((UInt64)data_in[uint64_offset + 5]) << 16) |
                (((UInt64)data_in[uint64_offset + 6]) << 8) | ((UInt64)data_in[uint64_offset + 7])) & uint64_mask;

            return uint64_data;
        }
        public double ParseDouble(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort d_offset = 0;//ushort.Parse(item.Attribute("data_offset").Value);
            d_offset += init_offset;
            d_offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            d_offset += (ushort)obt_size;

            double d_data = 0;
            bool little = BitConverter.IsLittleEndian;
            if (little)
            {
                byte[] nb = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    nb[i] = data_in[d_offset + 7 - i];
                }
                d_data = BitConverter.ToDouble(nb, 0);
            }
            else
            {
                d_data = BitConverter.ToDouble(data_in, d_offset);
            }

            return d_data;
        }

        public string ParseString(XElement item, int obt_size, byte[] data_in, ushort init_offset, ushort size)
        {
            ushort offset = 0;
            offset += init_offset;
            offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            offset += (ushort)obt_size;
            strSize = 0;
            if (size == 0)
            {
                byte[] count = new byte[2];
                Array.Copy(data_in, offset, count, 0, 2);
                size = (UInt16)((count[0] << 8) + count[1]);
                offset += 2;
                strSize += 2;
            }
            byte[] source = new byte[size];
            Array.Copy(data_in, offset, source, 0, size);
            strSize += size;
            return source != null ? System.Text.Encoding.UTF8.GetString(source) : null;
        }
        public string ParseRequest(XElement item, int obt_size, byte[] data_in, ushort init_offset)
        {
            ushort offset = 0;
            offset += init_offset;
            offset += Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER;
            offset += (ushort)obt_size;
            strSize = (UInt16)((data_in[offset + 4] << 8) + data_in[offset + 5]);
            strSize += Constants.ECCS_PRIMARY_HEADER + 1;
            byte[] source = new byte[strSize];
            Array.Copy(data_in, offset, source, 0, strSize);

            string dataPayload = "";
            for (int h = 0; h < source.Length; h++)
            {
                dataPayload += string.Format("{0:x2}", source[h]);
            }
            return dataPayload;
        }

        public void getTypeAndSizeFromID(ref string type, ref UInt16 offset)
        {
            XDocument paramConfig = XDocument.Load(pathMyDocuments + Properties.Settings.Default.Param_XML_file);

            foreach (XElement param in from y in paramConfig.Descendants("param") select y)
            {
                if (parameter_id == Convert.ToInt32(param.Attribute("id").Value))
                {
                    type = param.Attribute("type").Value;
                    offset = Convert.ToUInt16(param.Attribute("data_size").Value, 16);
                    return;
                }

            }
            offset = 0;
            type = "unknown";
        }
    }
}
