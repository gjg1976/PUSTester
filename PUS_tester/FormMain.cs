using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace PUS_tester
{
    public partial class FormMain : Form
    {
        private List<byte> new_payload = null;

        private ushort applicationId = 0;

        private ushort packetSeqCounter = 0;

        private ushort sourceId = 0;

        string pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "\\PUSTester\\";

        private short maxID = 0;

        private SerialPort serialPortRS422;//! Variables de los puertos serie

        private byte[] serial_port_array = new byte[Properties.Settings.Default.Max_payload_size];//! buffer de recepcion del puerto RS422
        private int serial_port_array_index = 0;//! variable que lleva el indice del array del buffer de recepcion del puerto RS422

        //! Variables a los archivos de Log
        private System.IO.FileStream LogFile;
        private System.IO.FileStream Log422RxFile;
        private System.IO.FileStream Log422TxFile;
        private byte[] data_in;

        DataTable memoryUpload = new DataTable();
        DataTable schedulingUpload = new DataTable();
        DataTable eventsUpload = new DataTable();
        DataTable sequencingUpload = new DataTable();

        public FormMain()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            memoryUpload.Columns.Add("Offset");
            memoryUpload.Columns.Add("Path");
            memoryUpload.Columns.Add("Length");
            memoryUpload.Columns.Add("CRC");

            dataGridViewST06.DataSource = memoryUpload;

            dataGridViewST06.Columns[0].Width = 105;
            dataGridViewST06.Columns[0].ReadOnly = true;

            dataGridViewST06.Columns[1].Width = 190;
            dataGridViewST06.Columns[1].ReadOnly = true;

            dataGridViewST06.Columns[2].Width = 50;
            dataGridViewST06.Columns[2].ReadOnly = true;

            dataGridViewST06.Columns[3].Width = 50;
            dataGridViewST06.Columns[3].ReadOnly = true;

            schedulingUpload.Columns.Add("Time");
            schedulingUpload.Columns.Add("Command");
            schedulingUpload.Columns.Add("Description");
            schedulingUpload.Columns.Add("RAW");
            dataGridViewST11.DataSource = schedulingUpload;

            dataGridViewST11.Columns[0].Width = 80;
            dataGridViewST11.Columns[0].ReadOnly = true;

            dataGridViewST11.Columns[1].Width = 150;
            dataGridViewST11.Columns[1].ReadOnly = true;

            dataGridViewST11.Columns[2].Width = 150;
            dataGridViewST11.Columns[2].ReadOnly = true;

            dataGridViewST11.Columns[3].Visible = false;

            eventsUpload.Columns.Add("EventID");
            eventsUpload.Columns.Add("AppID");
            eventsUpload.Columns.Add("Command");
            eventsUpload.Columns.Add("Description");
            eventsUpload.Columns.Add("RAW");
            dataGridViewST19.DataSource = eventsUpload;

            dataGridViewST19.Columns[0].Width = 70;
            dataGridViewST19.Columns[0].ReadOnly = true;

            dataGridViewST19.Columns[1].Width = 50;
            dataGridViewST19.Columns[1].ReadOnly = true;

            dataGridViewST19.Columns[2].Width = 130;
            dataGridViewST19.Columns[2].ReadOnly = true;

            dataGridViewST19.Columns[3].Width = 130;
            dataGridViewST19.Columns[3].ReadOnly = true;

            dataGridViewST19.Columns[4].Visible = false;

            sequencingUpload.Columns.Add("Delay");
            sequencingUpload.Columns.Add("Command");
            sequencingUpload.Columns.Add("Description");
            sequencingUpload.Columns.Add("RAW");
            dataGridViewST21.DataSource = sequencingUpload;

            dataGridViewST21.Columns[0].Width = 80;
            dataGridViewST21.Columns[0].ReadOnly = true;

            dataGridViewST21.Columns[1].Width = 150;
            dataGridViewST21.Columns[1].ReadOnly = true;

            dataGridViewST21.Columns[2].Width = 150;
            dataGridViewST21.Columns[2].ReadOnly = true;

            dataGridViewST21.Columns[3].Visible = false;

            TimeSpan span = DateTime.UtcNow.Subtract(new DateTime(1980, 1, 6, 0, 0, 0));
            numericUpDownST11Release.Value = Convert.ToUInt32(span.TotalSeconds);
            this.new_payload = StaticPayload.PayloadList;
            applicationId = Properties.Settings.Default.ApplicationID;
            this.Text += " version: " + System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            this.Text += " => target APID: " + applicationId.ToString();
            this.RenderXMLFile(pathMyDocuments + Properties.Settings.Default.TC_XML_file);

            //!< Muestra la disponibilidad de los puertos Serie en la GUI 
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())//!< Obtiene desde el OS, los nombres de todos los puertos e itera por cada uno
            {
                comboBoxRS422.Items.Add(portName);//!< y para agregarlo al control con el listado de los puertos RS422
            }

            string SerialUART = Properties.Settings.Default.DefaultCOMUART;//!< Lee el puerto RS422 por defecto desde el xml de propiedas de la aplicacion Properties.Settings.Default.DefaultCOMUART, este string tiene el nombre del puerto y el bitrate
            comboBoxRS422.SelectedItem = SerialUART;//!< setea el puerto RS422 por defecto leido desde el xml de propiedades
            comboBoxRS422bps.SelectedItem = "115200"; //!< setea el bitrate del puerto para el MOSAIC

            if (comboBoxRS422.SelectedIndex > -1)//!< si estan dadas las condiciones para comenzar una conexion, es decir, se selecciono el puerto RS422, entonces 
                buttonOpenUart.Visible = true;//!< Habilita el listado de telecomandos
            else//!< si no estan dadas las condiciones
                buttonOpenUart.Visible = false;//!< Deshabilita el listado de telecomandos

            string today = DateTime.Now.ToString("yyyyMMddHHmmss");//!< Obtiene la fecha local actual del sistema en formato yyyyMMddHHmmss para el nombre de los archivos de log
            string SerialLogRxFilePath = pathMyDocuments + Properties.Settings.Default.SerialLogRxFilePath;//!< Obtiene el path donde se almacenan los archivos de log de las propiedades xml por defecto de la aplicacion Properties.Settings.Default.SerialLogRxFilePath
            string day_today_422RxFile = today + " Log422RxFile.bin";//!< a la fecha y hora con formato de nombre para el archivo le agrega el string " Log422RxFile.bin" para el nombre del archivo de log de recepcion RS422
            if (System.IO.Directory.Exists(SerialLogRxFilePath) == false)//!< Verifica que el directorio donde se van a almacenar los logs exista
                System.IO.Directory.CreateDirectory(SerialLogRxFilePath);//!< sino lo crea

            Log422RxFile = System.IO.File.Open(SerialLogRxFilePath + day_today_422RxFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read);//!< Crea y abre el arcivo de log usando el nombre anterior en el path correspondiente. El archivo se puede leer x otras aplicaciones mientras se escribe

            string SerialLogTxFilePath = pathMyDocuments + Properties.Settings.Default.SerialLogTxFilePath;//!< Obtiene el path donde se almacenan los archivos de log de las propiedades xml por defecto de la aplicacion Properties.Settings.Default.SerialLogTxFilePath
            string day_today_422TxFile = today + " Log422TxFile.bin";//!< a la fecha y hora con formato de nombre para el archivo le agrega el string " Log422TxFile.bin" para el nombre del archivo de log de transmision RS422
            if (System.IO.Directory.Exists(SerialLogTxFilePath) == false)//!< Verifica que el directorio donde se van a almacenar los logs exista
                System.IO.Directory.CreateDirectory(SerialLogTxFilePath);//!< sino lo crea

            Log422TxFile = System.IO.File.Open(SerialLogTxFilePath + day_today_422TxFile, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read);//!< Crea y abre el arcivo de log usando el nombre anterior en el path correspondiente. El archivo se puede leer x otras aplicaciones mientras se escribe

            string LogFilePath = pathMyDocuments + Properties.Settings.Default.LogFilePath;//!< Obtiene el path donde se almacenan los archivos de log de las propiedades xml por defecto de la aplicacion Properties.Settings.Default.LogFilePath
            string day_today = today + " LogFile.txt";//!< a dicha fecha le agrega el string " LogFile.txt" para el nombre del archivo de log
            if (System.IO.Directory.Exists(LogFilePath) == false)//!< Verifica que el directorio donde se van a almacenar los logs exista
                System.IO.Directory.CreateDirectory(LogFilePath);//!< sino lo crea

            LogFile = System.IO.File.Open(LogFilePath + day_today, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read);//!< Crea y abre el arcivo de log usando el nombre anterior en el path correspondiente. El archivo se puede leer x otras aplicaciones mientras se escribe

            string dataasstring = DateTime.Now.ToString() + " Starting PUS Tester App" + Environment.NewLine; //!< crea un string auxiliar para agregar las entradas del archivo de log y lo inicializa con la fecha y hora y un string de " Starting GPS Simulator"
            dataasstring += "\t" + this.Text + Environment.NewLine;//!< Agrega los datos d version del soft y GPS simulado que estan estampados en el texto de la GUI principal
            byte[] info = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
            LogFile.Write(info, 0, info.Length); //!< y lo graba en el archivo de log
            LogFile.Flush(); //!< espera que se grabe


            comboBoxOBTType.SelectedIndex = Properties.Settings.Default.OBTType;
            checkBoxPField.Checked = Properties.Settings.Default.PField;
            comboBoxNBasicTime.SelectedIndex = Properties.Settings.Default.BasicTimeSize - 1;
            comboBoxNFracTime.SelectedIndex = Properties.Settings.Default.FracTimeSize;
            dateTimePickerEpoch.Value = Properties.Settings.Default.Epoch;
            checkBoxCRC.Checked = Properties.Settings.Default.CRCReports;

        }

        //! Funcion de llamada cuando se cierra el software, apaga el Servidor SCPI, Cierra el Thread y el socket UDP para el envio de la solucion en formato Spirent             
        /*!
        \sa FormMain_FormClosing 
        \param object sender                                                                      
        \param FormClosingEventArgs e                                                             
        \return void 
         */
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dataasstring = DateTime.Now.ToString() + " Closing PUS Tester App" + Environment.NewLine; //!< crea un string auxiliar para agregar las entradas del archivo de log y lo inicializa con la fecha y hora y un string de " Playing GPS Simulation"
            byte[] info = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
            LogFile.Write(info, 0, info.Length); //!< y lo graba en el archivo de log general
            LogFile.Flush(); //!< espera que se grabe
            LogFile.Close();
        }

        private void RenderXMLFile(string filepath)
        {
            try
            {
                // 1. Read XML File from a local path
                string xmlString = File.ReadAllText(filepath, Encoding.UTF8);

                // 2. Create a XML DOM Document and load the data into it.
                XmlDocument dom = new XmlDocument();
                dom.LoadXml(xmlString);

                // 3. Initialize the TreeView control. treeView1 can be contextMenuStripTreeViewd dinamically
                // and attached to the form or you can just drag and drop the widget from the toolbox
                // into the Form.

                // Clear any previous content of the widget
                treeViewTlcmd.Nodes.Clear();
                // Create the root tree node, on any XML file the container (first root)
                // will be the DocumentElement name as any content must be wrapped in some node first.
                treeViewTlcmd.Nodes.Add(new TreeNode("PUS Services"));

                // 4. Create an instance of the first node in the treeview (the one that contains the DocumentElement name)
                TreeNode tNode = new TreeNode();
                tNode = treeViewTlcmd.Nodes[0];

                // 5. Populate the TreeView with the DOM nodes.
                this.AddNode(dom.DocumentElement, tNode);
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Renders a node of XML into a TreeNode. Recursive if inside the node there are more child nodes.
        /// </summary>
        /// <param name="inXmlNode"></param>
        /// <param name="inTreeNode"></param>
        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;

                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];

                    inTreeNode.Nodes.Add(new TreeNode(xNode.Attributes["name"].Value.ToString()));
                    if (xNode.LocalName == "packet")
                    {
                        short id = Int16.Parse(xNode.Attributes["id"].Value);
                        if (id > maxID)
                        {
                            maxID = id;
                        }
                        string description = "";
                        if (xNode.Attributes["description"] != null)
                        {
                            description += xNode.Attributes["description"].Value;
                            if (xNode.Attributes["type"].Value == "1")
                                inTreeNode.Nodes[i].ToolTipText = "Request: " + xNode.Attributes["name"].Value;
                            else if(xNode.Attributes["type"].Value == "0")
                                inTreeNode.Nodes[i].ToolTipText = "Report: " + xNode.Attributes["name"].Value;
                            inTreeNode.Nodes[i].Text = xNode.Attributes["description"].Value;
                        }
                        if (xNode.Attributes["type"].Value == "1")
                        {
                            Font boldFont = new Font(treeViewTlcmd.Font, FontStyle.Bold);
                            inTreeNode.Nodes[i].NodeFont = boldFont;
                            inTreeNode.Nodes[i].ForeColor = System.Drawing.Color.DarkGreen;
                            if (xNode.Attributes["form"] != null)
                            {
                                inTreeNode.Nodes[i].Tag = new Packet(id, description, applicationId,
                                    PacketType.TC,
                                    Byte.Parse(xNode.Attributes["ack"].Value),
                                    Byte.Parse(xNode.Attributes["service"].Value),
                                    Byte.Parse(xNode.Attributes["subservice"].Value),
                                    sourceId, xNode.Attributes["data"].Value, xNode.Attributes["form"].Value);
                            }
                            else
                            {
                                inTreeNode.Nodes[i].Tag = new Packet(id, description, applicationId,
                                    PacketType.TC,
                                    Byte.Parse(xNode.Attributes["ack"].Value),
                                    Byte.Parse(xNode.Attributes["service"].Value),
                                    Byte.Parse(xNode.Attributes["subservice"].Value),
                                    sourceId, xNode.Attributes["data"].Value);
                            }
                        }
                        else if (xNode.Attributes["type"].Value == "0")
                        {
                            Font boldFont = new Font(treeViewTlcmd.Font, FontStyle.Italic | FontStyle.Bold);
                            inTreeNode.Nodes[i].NodeFont = boldFont;
                            inTreeNode.Nodes[i].ForeColor = System.Drawing.Color.DarkBlue;
                            Font italicFont = new Font(treeViewTlcmd.Font, FontStyle.Italic);
                            inTreeNode.NodeFont = italicFont;
                            if (xNode.Attributes["template"].Value == "")
                                continue;
                            inTreeNode.Nodes[i].Tag = new Packet(applicationId, PacketType.TM,
                                   Byte.Parse(xNode.Attributes["service"].Value),
                                   Byte.Parse(xNode.Attributes["subservice"].Value),
                                   sourceId, @"../../config/" + xNode.Attributes["template"].Value);

                        }
                    }
                    else
                    {
                        if (xNode.LocalName == "subservice" && xNode.Attributes["form"] != null)
                        {
                            inTreeNode.Nodes[i].Tag = new Packet(applicationId, PacketType.TCT,
                                   Byte.Parse(xNode.Attributes["service"].Value),
                                   Byte.Parse(xNode.Attributes["subservice"].Value),
                                   sourceId, xNode.Attributes["form"].Value);
                        }
                        else if (xNode.LocalName == "service" && xNode.Attributes["specialGUI"] != null)
                        {
                            Font boldFont = new Font(treeViewTlcmd.Font, FontStyle.Bold);
                            inTreeNode.Nodes[i].NodeFont = boldFont;
                            inTreeNode.Nodes[i].Tag = new Packet(applicationId, PacketType.SPC,
                                   Byte.Parse(xNode.Attributes["service"].Value),
                                   0,
                                   sourceId, xNode.Attributes["specialGUI"].Value);
                        }
                    }


                    tNode = inTreeNode.Nodes[i];
                    this.AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                //               inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        private void buttonSendTC_Click(object sender, EventArgs e)
        {
            if (treeViewTlcmd.SelectedNode != null)
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;
                    if (packet.packetType == PacketType.TC || packet.packetType == PacketType.TCT)
                    {

                        byte[] data = new byte[Constants.ECCS_PRIMARY_HEADER +
                                            Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL];
                        int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL - 1;
                        UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownSeq.Value);
                        numericUpDownSeq.Value = ++packetSeqCounter;
                        byte ackflags = 0;

                        if (checkBoxAckAcc.Checked) ackflags |= 0x01;
                        if (checkBoxAckExec.Checked) ackflags |= 0x02;
                        if (checkBoxAckProg.Checked) ackflags |= 0x04;
                        if (checkBoxAckComp.Checked) ackflags |= 0x08;

                        data[0] = (byte)((applicationId >> 8) | 0x18);
                        data[1] = (byte)(applicationId & 0xff);
                        data[2] = (byte)((packetSequenceControl >> 8) | 0xc0);
                        data[3] = (byte)(packetSequenceControl & 0xff);
                        data[4] = (byte)(packetDataLength >> 8);
                        data[5] = (byte)(packetDataLength & 0xff);

                        data[Constants.ECCS_PRIMARY_HEADER + 0] = (byte)(Constants.ECSSPUSVersion << 4); // Assign the pusVersion = 2
                        data[Constants.ECCS_PRIMARY_HEADER + 0] |= (byte)(ackflags & 0x0F);                 // Spacecraft time reference status
                        data[Constants.ECCS_PRIMARY_HEADER + 1] = packet.serviceType;
                        data[Constants.ECCS_PRIMARY_HEADER + 2] = packet.serviceSubType;
                        data[Constants.ECCS_PRIMARY_HEADER + 3] = (byte)(sourceId >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + 4] = (byte)(sourceId & 0xff);

                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] =
                                            Convert.ToByte(s, 16);

                        ushort CRC = calculateCRC(data);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC & 0xff);

                        if (sourceId == 65535)
                            sourceId = 0;
                        else
                            sourceId++;

                        labelCRC.Text = "CRC: " + CRC.ToString("X4");
                        labelCRC.Visible = true;
                        String dataasstring = DateTime.Now.ToString() + " Tx: " + treeViewTlcmd.SelectedNode.Text + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando

                        SendCommand(data, dataasstring);
                    }
                }
            }
        }

        //! Funcion de llamada de evento al presionar el boton de envio de telecomando            
        /*!
        \sa SendCommand 
        \param telecommand: the byte array with the telecommand RAW data to send                                                               
        \return void
         */
        private void SendCommand(byte[] data, String dataasstring)
        {
 
            //serialPortRS422.DiscardOutBuffer();
            //serialPortRS422.DiscardInBuffer();

            string logcmd422 = "";//!< Crea una variable string temporal para el log Tx RS422 de la GUI
            int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
            logcmd422 += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
            foreach (byte _b in data)//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
            {
                Log422TxFile.WriteByte(_b);//!< En el archivo log de Tx RS422, se agrega el byte RAW en binario, es un archivo binario con todo lo transmitido sin nada extra agregado 
                logcmd422 += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                if (++hcmd % 16 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                {
                    logcmd422 += Environment.NewLine;//!< Se debe pasar a una nueva linea
                    logcmd422 += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                    continue;//!< Continua con el proximo byte
                }
                else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                {
                    logcmd422 += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                }
            }
            logcmd422 += Environment.NewLine;


            Log422TxFile.Flush();                           //!< Termina de escribir el archivo de Log

            byte[] infoheader = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
            LogFile.Write(infoheader, 0, infoheader.Length); //!< y lo graba en el archivo de log

            byte[] infohex = new UTF8Encoding(true).GetBytes(logcmd422 + Environment.NewLine); //!< Codifica ese string en UTF8
            LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
            LogFile.Flush(); //!< espera que se grabe

            textBoxSend.Text = logcmd422;

            labelSend.Visible = true;  //<! muestra el mensaje Sent en la GUI
            SendTxThru422(data); //!< Envia por RS422 el paquete de datos con la respuesta al comando almanaque
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
        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        //! Funcion de envio por el puerto serie RS422             
        /*!
        \sa SendTxThru422
        \param byte[] data buffer de bytes a enviar por el puerto
        \return void
         */
        private void SendTxThru422(byte[] data)
        {
            if (serialPortRS422.IsOpen)//!< Si el puerto esta abierto, entonces
                serialPortRS422.Write(data, 0, data.Length);//!< Escribe el buffer de datos a enviar
        }

        private void treeViewTlcmd_AfterSelect(object sender, TreeViewEventArgs e)
        {
            labelSend.Visible = false;  //<! oculta el mensaje Sent en la GUI
            tabControlSpecialGUI.Visible = false;
            buttonST13StoreFile.Enabled = false;
            buttonST13StoreDB.Enabled = false;
            labelST14Warning.Text = "";
            this.Width = 925;
            if (treeViewTlcmd.SelectedNode != null)
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        buttonEditTC.Visible = false;
                        buttonSaveTC.Visible = false;
                        buttonSendTC.Visible = true;
                        buttonDelTC.Visible = false;
                        groupBoxTelecommand.Enabled = true;
                        groupBoxTelecommand.Text = "Telecommand: " + treeViewTlcmd.SelectedNode.Parent.Text;
                        textBoxServiceTypeTx.Text = packet.serviceType.ToString();
                        textBoxServiceSubTypeTx.Text = packet.serviceSubType.ToString();
                        checkBoxAckAcc.Checked = false;
                        checkBoxAckExec.Checked = false;
                        checkBoxAckProg.Checked = false;
                        checkBoxAckComp.Checked = false;
                        if ((packet.ack & 0x01) != 0) checkBoxAckAcc.Checked = true;
                        if ((packet.ack & 0x02) != 0) checkBoxAckExec.Checked = true;
                        if ((packet.ack & 0x04) != 0) checkBoxAckProg.Checked = true;
                        if ((packet.ack & 0x08) != 0) checkBoxAckComp.Checked = true;
                        textBoxDescription.Text = packet.des;
                        numericUpDownSeq.Value = packetSeqCounter;

                        int pktLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL - 1;
                        textBoxSizeTx.Text = pktLength.ToString("X4");

                        byte[] values = new byte[packet.data.Length / 2];
                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            values[i++] = Convert.ToByte(s, 16);

                        string logcmd422 = "";//!< Crea una variable string temporal para el log Tx RS422 de la GUI
                        int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
                        logcmd422 += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
                        for (; hcmd < values.Length;)
                        {
                            byte _b = values[hcmd];//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
                            logcmd422 += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                            if (++hcmd % 16 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                            {
                                logcmd422 += Environment.NewLine;//!< Se debe pasar a una nueva linea
                                logcmd422 += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                                continue;//!< Continua con el proximo byte
                            }
                            else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                            {
                                logcmd422 += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                            }
                        }
                        textBoxPayloadTx.Text = logcmd422 + Environment.NewLine;
                        if (packet.template != "")
                        {
                            buttonEditTC.Visible = true;
                            buttonSaveTC.Visible = true;
                            buttonDelTC.Visible = true;
                        }
                    }
                    else if (packet.packetType == PacketType.TCT)
                    {
                        if (packet.template != "")
                        {
                            buttonEditTC.Visible = true;
                            buttonSaveTC.Visible = true;
                            buttonSendTC.Visible = true;
                            buttonDelTC.Visible = false;
                            groupBoxTelecommand.Enabled = true;
                            groupBoxTelecommand.Text = "Telecommand Template: " + treeViewTlcmd.SelectedNode.Text;
                            textBoxServiceTypeTx.Text = packet.serviceType.ToString();
                            textBoxServiceSubTypeTx.Text = packet.serviceSubType.ToString();
                            checkBoxAckAcc.Checked = false;
                            checkBoxAckExec.Checked = false;
                            checkBoxAckProg.Checked = false;
                            checkBoxAckComp.Checked = false;
                            if ((packet.ack & 0x01) != 0) checkBoxAckAcc.Checked = true;
                            if ((packet.ack & 0x02) != 0) checkBoxAckExec.Checked = true;
                            if ((packet.ack & 0x04) != 0) checkBoxAckProg.Checked = true;
                            if ((packet.ack & 0x08) != 0) checkBoxAckComp.Checked = true;
                            numericUpDownSeq.Value = packetSeqCounter;
                            int pktLength = Constants.ECCS_SECONDARY_TC_HEADER + Constants.ECSS_CRC_TAIL - 1;
                            textBoxSizeTx.Text = pktLength.ToString("X4");
                            textBoxPayloadTx.Text = "";
                        }
                    }
                    else if (packet.packetType == PacketType.SPC)
                    {
                        if (packet.template != "")
                        {
                            groupBoxTelecommand.Enabled = false;
                            tabControlSpecialGUI.Visible = true;
                            tabControlSpecialGUI.SelectedIndex = Convert.ToInt32(packet.template);
                            this.Width = 1390;
                            if(tabControlSpecialGUI.SelectedIndex == 1)
                            {
                                CopyTreeNodes(treeViewTlcmd, treeViewST11);
                            }else if (tabControlSpecialGUI.SelectedIndex == 3)
                            {
                                CopyTreeNodes(treeViewTlcmd, treeViewST19);
                            }
                            else if (tabControlSpecialGUI.SelectedIndex == 4)
                            {
                                CopyTreeNodes(treeViewTlcmd, treeViewST21);
                            }
                        }
                    }
                }
                else
                {
                    groupBoxTelecommand.Enabled = false;
                    groupBoxTelecommand.Text = "Telecommand";
                    textBoxServiceTypeTx.Text = "";
                    textBoxPayloadTx.Text = textBoxServiceSubTypeTx.Text = "";
                    checkBoxAckAcc.Checked = false;
                    checkBoxAckExec.Checked = false;
                    checkBoxAckProg.Checked = false;
                    checkBoxAckComp.Checked = false;
                    textBoxSizeTx.Text = "";
                    labelCRC.Text = "CRC";
                    labelCRC.Visible = false;
                    buttonEditTC.Visible = false;
                    buttonSaveTC.Visible = false;
                    buttonSendTC.Visible = false;
                    buttonDelTC.Visible = false;
                    numericUpDownSeq.Value = 0;
                }
            }
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

        private void buttonEditTC_Click(object sender, EventArgs e)
        {
            if (treeViewTlcmd.SelectedNode != null)
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    string formName = packet.template;
                    new_payload.Clear();

                    foreach (string s in SplitInParts(packet.data, 2))
                        new_payload.Add(Convert.ToByte(s, 16));

                    var form = Activator.CreateInstance(Type.GetType("PUS_tester." + formName)) as Form;

                    form.ShowDialog();
                    if (new_payload.Count > 0)
                    {
                        packet.data = BitConverter.ToString(new_payload.ToArray()).Replace("-", string.Empty);

                        int pktLength = Constants.ECCS_SECONDARY_TC_HEADER +
                        packet.data.Length / 2 +
                        Constants.ECSS_CRC_TAIL - 1;
                        textBoxSizeTx.Text = pktLength.ToString("X4");

                        byte[] values = new byte[packet.data.Length / 2];
                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            values[i++] = Convert.ToByte(s, 16);

                        string logcmd422 = "";//!< Crea una variable string temporal para el log Tx RS422 de la GUI
                        int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
                        logcmd422 += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
                        for (; hcmd < values.Length;)
                        {
                            byte _b = values[hcmd];//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
                            logcmd422 += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                            if (++hcmd % 16 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                            {
                                logcmd422 += Environment.NewLine;//!< Se debe pasar a una nueva linea
                                logcmd422 += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                                continue;//!< Continua con el proximo byte
                            }
                            else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                            {
                                logcmd422 += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                            }
                        }
                        textBoxPayloadTx.Text = logcmd422 + Environment.NewLine;

                    }
                }

            }
        }

        //! Funcion de llamada de evento al presionar el boton de cierre del puerto UART            
        /*!
        \sa buttonCloseUart_Click 
        \param object sender Objeto que llama a esta funcion (el boton de CloseUart)
        \param EventArgs e   Argumentos que envia el boton junto con la llamada                                                                    
        \return void
         */
        private void buttonCloseUart_Click(object sender, EventArgs e)
        {
            string dataasstring = DateTime.Now.ToString() + " Closing UART: " + comboBoxRS422.SelectedItem.ToString() + Environment.NewLine; //!< crea un string auxiliar para agregar las entradas del archivo de log y lo inicializa con la fecha y hora y un string de " Playing GPS Simulation"

            serialPortRS422.Close();//!< Cierra el puerto RS422 usado para comunicarse con el DUT
            labelRS422.Text = "Port Closed";//!< Avisa en el GUI que el port RS422 se cerro
            buttonSendTC.Enabled = false;
            buttonOpenUart.Visible = true;
            buttonCloseUart.Visible = false;
            buttonLoadSend.Enabled = false;
            groupBoxRAW.Enabled = false;
            labelSend.Visible = false;
            textBoxRawFile.Text = "";

            byte[] info = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
            LogFile.Write(info, 0, info.Length); //!< y lo graba en el archivo de log general
            LogFile.Flush(); //!< espera que se grabe
        }

        //! Funcion de llamada de evento al presionar el boton de apertura del puerto UART            
        /*!
        \sa buttonOpenUart_Click 
        \param object sender Objeto que llama a esta funcion (el boton de OpenUart)
        \param EventArgs e   Argumentos que envia el boton junto con la llamada                                                                    
        \return void
         */
        private void buttonOpenUart_Click(object sender, EventArgs e)
        {
            string dataasstring = DateTime.Now.ToString() + " Opening UART: "; //!< crea un string auxiliar para agregar las entradas del archivo de log y lo inicializa con la fecha y hora y un string de " Playing GPS Simulation"

            /****************************************************************************************************************
             *                                             Serial Ports initialization
             ***************************************************************************************************************/
            serialPortRS422 = new SerialPort();//!< crea un puerto serie RS422

            if (serialPortRS422 is SerialPort)//!< Si el puerto RS422 se creo correctamente, entonces
            {
                serialPortRS422.PortName = comboBoxRS422.SelectedItem.ToString();//!< inica el nombre de puerto con los datos del puerto seleccionado en la GUI
                serialPortRS422.DataBits = 8;//!< con 8 bits de datos
                serialPortRS422.Parity = Parity.None;
                serialPortRS422.StopBits = StopBits.One;//!< un bit de stop
                serialPortRS422.BaudRate = int.Parse(comboBoxRS422bps.SelectedItem.ToString());//!< toma el bit rate de lo seleccionado en la GUI
                serialPortRS422.Handshake = Handshake.None;
                try
                {
                    serialPortRS422.Open();//!< Abre el puerto RS422
                    serialPortRS422.DiscardOutBuffer();//!< Limpia el buffer de salida
                    serialPortRS422.DiscardInBuffer();//!< y de entrada
                    serialPortRS422.DataReceived += new SerialDataReceivedEventHandler(serialRS422_DataReceived);//!< agrega la funcion de llamada al recibir datos
                    labelRS422.Text = comboBoxRS422.SelectedItem.ToString() + ", 8-N-1" + " Opened";//!< Informa en la GUI que se abrio el puerto

                    buttonSendTC.Enabled = true;
                    buttonOpenUart.Visible = false;
                    buttonCloseUart.Visible = true;
                    groupBoxRAW.Enabled = true;

                    dataasstring += comboBoxRS422.SelectedItem.ToString() + ", " + comboBoxRS422bps.SelectedItem.ToString() + ", 8-N-1" + Environment.NewLine; //!< Crea una entrada en el log general con los datos del puerto abierto
                }
                catch (Exception exc)//!< Si durante la apertura del puerto se produce una excepcion, entonces
                {
                    buttonSendTC.Enabled = false;
                    buttonOpenUart.Visible = true;
                    buttonCloseUart.Visible = false;
                    groupBoxRAW.Enabled = false;
                    dataasstring += comboBoxRS422.SelectedItem.ToString() + "\t Exception: " + exc.Message + Environment.NewLine;//!< Agrega el mensaje de excepcion al Log general 
                }
            }
            else
            {
                dataasstring += comboBoxRS422.SelectedItem.ToString() + "\tError Creating Port " + Environment.NewLine; //!< Avisa del error en el log general 
            }

            byte[] info = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
            LogFile.Write(info, 0, info.Length); //!< y lo graba en el archivo de log general
            LogFile.Flush(); //!< espera que se grabe

        }

        /*!
\sa serialRS422_DataReceived
\param object sender Objeto que llama a esta funcion (el puerto Serie RS232)
\param SerialDataReceivedEventArgs e   Argumentos que envia el puerto junto con la llamada                                                                    
\return void
*/
        void serialRS422_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool process_tlcmd = false;
            Thread.Sleep(100);
            if (serialPortRS422.IsOpen)//!< Si el puerto esta abierto, entonces
            {
                int bytes_count = serialPortRS422.BytesToRead;//!< OBtiene el tamaño del buffer de bytes a leer

                data_in = new byte[bytes_count];


                for (int i = 0; i < bytes_count; i++)
                { //!< cicla en cada byte a leer

                    data_in[i] = Convert.ToByte(serialPortRS422.ReadByte());
                }

                String dataasstring = DateTime.Now.ToString() + " Rx: " + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                string logcmd422 = "";//!< Crea una variable string temporal para el log Tx RS422 de la GUI
                int hcmd = 0;//!< Crea una variable auxiliar h para la convertir los datos RAW en strings hexadecimales para el log Tx RS422 de la GUI
                logcmd422 += string.Format("{0:x4}   ", hcmd);//!< Cada linea del log Tx RS422 de la GUI comienza con la "direccion" de los datos en 4 bytes representados en hexadecimal. La primer linea es 0x00000000, luego un grupo de 8 bytes, separados por espacio, dos espacios para tener mas separacion, otro grupo de 8 bytes separados por espacio y luego una nueva linea
                foreach (byte _b in data_in)//!< Y luego, por cada bytes de datos, itera para armar el log Tx RS422 de la GUI en un formato legible 
                {
                    if (Log422RxFile.CanWrite)
                        Log422RxFile.WriteByte(_b);//!< En el archivo log de Tx RS422, se agrega el byte RAW en binario, es un archivo binario con todo lo transmitido sin nada extra agregado 
                    logcmd422 += string.Format("{0:x2} ", _b);//!< En el cado del log Tx RS422 de la GUI, cada byte se representa en un formato legible en hexadecimal, separados por " " entre byte y byte
                    if (++hcmd % 16 == 0)//!< Incrementa la variable auxiliar, si ya se agregaron 16 bytes a una linea de log de Tx RS422 para la GUi, entonces 
                    {
                        logcmd422 += Environment.NewLine;//!< Se debe pasar a una nueva linea
                        logcmd422 += string.Format("{0:x4}   ", hcmd);//!< que comienza con la direccion
                        continue;//!< Continua con el proximo byte
                    }
                    else if (hcmd % 8 == 0)//!< Si por el contrario, se agregaron 8 bytes a una linea de log de Tx RS422
                    {
                        logcmd422 += " ";//!< entonces se agregan 2 espacios para separar en grupo de 8 y 8 bytes y hacer el GUI mas legible

                    }
                }
                logcmd422 += Environment.NewLine;
                Log422RxFile.Flush();  //!< Termina de escribir el archivo de Log


                byte[] infoheader = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                LogFile.Write(infoheader, 0, infoheader.Length); //!< y lo graba en el archivo de log

                byte[] infohex = new UTF8Encoding(true).GetBytes(logcmd422 + Environment.NewLine); //!< Codifica ese string en UTF8
                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                LogFile.Flush(); //!< espera que se grabe

                textBoxReceive.Invoke((Action)(() => { textBoxReceive.Text = logcmd422; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos

            }
        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            byte[] processing = data_in;

            if (data_in == null)
                return;

            labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = false; }));

            while (processing.Length > Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER)
            {

                ushort packetDataLength = (ushort)((processing[4] << 8) | processing[5]);

                if (packetDataLength > (Constants.ECCS_PRIMARY_HEADER + processing.Length))
                {
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Text = "Error: Wrong Size"; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = true; }));
                    return;
                }

                byte serviceType = processing[7];

                byte serviceSubType = processing[8];


                byte[] report = new byte[Constants.ECCS_PRIMARY_HEADER + packetDataLength + 1];
                byte[] remain = new byte[processing.Length - report.Length];
                ushort CRC = 0;

                System.Array.Copy(processing, report, report.Length);
                System.Array.Copy(processing, report.Length, remain, 0, processing.Length - report.Length);
                processing = remain;

                if (report.Length < Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TM_HEADER)
                {
                    //Error wrong Data
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Text = "Error: Wrong Size"; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = true; }));
                    return;
                }

                ushort ApplicationId = (ushort)((report[0] << 8) | report[1]);
                if ((ApplicationId & 0xE000) != 0)
                {
                    //Error wrong CCSDS Packet Version
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Text = "Error: Wrong CCSDS Packet Version"; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = true; }));

                    return;
                }

                if ((ApplicationId & 0x1000) != 0)
                {
                    //Error not TM
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Text = "Error: Not a Report Packet"; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = true; }));
                    return;
                }

                if ((ApplicationId & 0x0800) == 0)
                {
                    //Error not Secondary Header
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Text = "Error: Secondary Header not presents"; }));//!< Copia el string hexadecimal a la GUI para mostrar los datos
                    labelErrorRx.Invoke((Action)(() => { labelErrorRx.Visible = true; }));
                    return;
                }

                if (checkBoxCRC.Checked)
                    CRC = calculateCRC(report);

                TreeNode result = TreeNode_Search(treeViewTlcmd.Nodes[0], serviceType, serviceSubType);
                if (result != null)
                {
                    object pkt = result.Tag;
                    if (pkt != null)
                    {
                        Packet packet = (Packet)pkt;
                        FormReport formReport = new FormReport(packet.template, report,
                            checkBoxCRC.Checked, CRC,
                            (ushort)Properties.Settings.Default.OBTType,
                            Properties.Settings.Default.PField,
                            (ushort)Properties.Settings.Default.BasicTimeSize,
                            (ushort)Properties.Settings.Default.FracTimeSize);

                        formReport.Show();
                    }

                }
            }
        }

        private TreeNode TreeNode_Search(TreeNode inTreeNode, byte serviceType, byte serviceSubType)
        {
            foreach (TreeNode childNode in inTreeNode.Nodes)
            {
                object pkt = childNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;
                    if (packet.serviceType == serviceType && packet.serviceSubType == serviceSubType)
                        return childNode;

                }
   //             else
   //             {
                    TreeNode result = TreeNode_Search(childNode, serviceType, serviceSubType);
                    if (result != null)
                        return result;
   //             }
            }
            return null;
        }

        private void comboBoxRS422_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRS422.SelectedItem.ToString().Length > 0)
                buttonOpenUart.Visible = true;
        }

        private void buttonSaveTC_Click(object sender, EventArgs e)
        {
            SaveXML(0, 0);
        }

        private void SaveXML(Byte serviceType, Byte serviceSubType)
        {

            // 1. Read XML File from a local path
            string xmlString = File.ReadAllText(pathMyDocuments + Properties.Settings.Default.TC_XML_file, Encoding.UTF8);

            // 2. Create a XML DOM Document and load the data into it.
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xmlString);

            XmlNode inXmlNode = dom.DocumentElement;

            SaveNode(inXmlNode, dom, serviceType, serviceSubType);

            dom.Save(pathMyDocuments + Properties.Settings.Default.TC_XML_file);

            this.Refresh();
        }

        private bool SaveNode(XmlNode inXmlNode, XmlDocument dom, Byte serviceType, Byte serviceSubType)
        {
            object pkt = treeViewTlcmd.SelectedNode.Tag;
            if (pkt == null)
                return true;
            Packet packet = (Packet)pkt;

            XmlNode xNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;

                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];

                    if (xNode.LocalName == "packet" && packet.id >= 0)
                    {
                        if (xNode.Attributes["type"].Value == "1")
                        {
                            if (Int16.Parse(xNode.Attributes["id"].Value) == packet.id)
                            {
                                byte ackflags = 0;

                                if (checkBoxAckAcc.Checked) ackflags |= 0x01;
                                if (checkBoxAckExec.Checked) ackflags |= 0x02;
                                if (checkBoxAckProg.Checked) ackflags |= 0x04;
                                if (checkBoxAckComp.Checked) ackflags |= 0x08;
                                maxID++;
                                if (xNode.Attributes["description"] == null)
                                {
                                    XmlAttribute attr = dom.CreateAttribute("description");
                                    attr.Value = textBoxDescription.Text;
                                    xNode.Attributes.Append(attr);
                                }
                                else
                                    xNode.Attributes["description"].Value = textBoxDescription.Text;
                                xNode.Attributes["ack"].Value = ackflags.ToString();
                                xNode.Attributes["data"].Value = packet.data;
                                packet.des = textBoxDescription.Text;
                                packet.ack = ackflags;

                                String dataasstring = DateTime.Now.ToString() + " Updating Request ID#" + packet.id + " in database: " + textBoxDescription.Text + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                                dataasstring += "\t\t\t from subservice: " + treeViewTlcmd.SelectedNode.Parent.Text + Environment.NewLine;
                                dataasstring += "\t\t\t Payload: " + packet.data + Environment.NewLine + Environment.NewLine;
                                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log


                                return true;
                            }
                        }
                    }
                    else if (xNode.LocalName == "subservice" && packet.id < 0)
                    {
                        if (xNode.Attributes["name"].Value == treeViewTlcmd.SelectedNode.Text)
                        {
                            byte ackflags = 0;

                            if (checkBoxAckAcc.Checked) ackflags |= 0x01;
                            if (checkBoxAckExec.Checked) ackflags |= 0x02;
                            if (checkBoxAckProg.Checked) ackflags |= 0x04;
                            if (checkBoxAckComp.Checked) ackflags |= 0x08;

                            XmlElement XEle = dom.CreateElement("packet");
                            maxID++;
                            XEle.SetAttribute("id", maxID.ToString());
                            XEle.SetAttribute("name", treeViewTlcmd.SelectedNode.Text);
                            XEle.SetAttribute("description", textBoxDescription.Text);
                            XEle.SetAttribute("type", "1");
                            XEle.SetAttribute("service", packet.serviceType.ToString());
                            XEle.SetAttribute("subservice", packet.serviceSubType.ToString());
                            XEle.SetAttribute("ack", ackflags.ToString());
                            XEle.SetAttribute("data", packet.data);
                            XEle.SetAttribute("form", packet.template);
                            xNode.AppendChild(XEle.Clone());

                            TreeNode newNode = new TreeNode(treeViewTlcmd.SelectedNode.Text);
                            newNode.Tag = new Packet(maxID, textBoxDescription.Text, applicationId,
                                    PacketType.TC,
                                    ackflags,
                                    packet.serviceType,
                                    packet.serviceSubType,
                                    sourceId, packet.data, packet.template);
                            Font boldFont = new Font(treeViewTlcmd.Font, FontStyle.Bold);
                            newNode.NodeFont = boldFont;
                            newNode.ForeColor = System.Drawing.Color.DarkGreen;
                            if (textBoxDescription.Text != "")
                            {
                                newNode.ToolTipText = "Request: " + treeViewTlcmd.SelectedNode.Text;
                                newNode.Text = textBoxDescription.Text;
                            }
                            treeViewTlcmd.SelectedNode.Nodes.Add(newNode);

                            String dataasstring = DateTime.Now.ToString() + " Creating Request ID#" + maxID + " in database: " + textBoxDescription.Text + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                            dataasstring += "\t\t\t from subservice: " + treeViewTlcmd.SelectedNode.Text + Environment.NewLine;
                            dataasstring += "\t\t\t Payload: " + packet.data + Environment.NewLine + Environment.NewLine;
                            byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                            LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log                           

                            return true;
                        }
                    }
                    else if (xNode.LocalName == "service" && packet.id < 0)
                    {
                        if (xNode.Attributes["name"].Value == treeViewTlcmd.SelectedNode.Text)
                        {
                            for (int h = 0; h <= xNode.ChildNodes.Count - 1; h++)
                            {
                                XmlNode jNode = xNode.ChildNodes[h];
                                if (jNode.LocalName == "subservice")
                                {
                                    for (int n = 0; n <= jNode.ChildNodes.Count - 1; n++)
                                    {
                                        XmlNode mNode = jNode.ChildNodes[n];
                                        if (mNode.LocalName == "packet")
                                        {
                                            if (Convert.ToByte(mNode.Attributes["service"].Value) == serviceType &&
                                                Convert.ToByte(mNode.Attributes["subservice"].Value) == serviceSubType)
                                            {
                                                XmlElement XEle = dom.CreateElement("packet");
                                                maxID++;
                                                XEle.SetAttribute("id", maxID.ToString());
                                                XEle.SetAttribute("name", mNode.Attributes["name"].Value);
                                                XEle.SetAttribute("description", packet.des);
                                                XEle.SetAttribute("type", "1");
                                                XEle.SetAttribute("service", serviceType.ToString());
                                                XEle.SetAttribute("subservice", serviceSubType.ToString());
                                                XEle.SetAttribute("ack", "0");
                                                XEle.SetAttribute("data", packet.data);
                                                jNode.AppendChild(XEle.Clone());

                                                for (int g = 0; g < treeViewTlcmd.SelectedNode.Nodes.Count; g++)
                                                {
                                                    if (treeViewTlcmd.SelectedNode.Nodes[g].Text == mNode.Attributes["name"].Value)
                                                    {
                                                        TreeNode newNode = new TreeNode(mNode.Attributes["name"].Value);
                                                        newNode.Tag = new Packet(maxID, packet.des, applicationId,
                                                                PacketType.TC,
                                                                0,
                                                                serviceType,
                                                                serviceSubType,
                                                                sourceId, packet.data, "");
                                                        Font boldFont = new Font(treeViewTlcmd.Font, FontStyle.Bold);
                                                        newNode.NodeFont = boldFont;
                                                        newNode.ForeColor = System.Drawing.Color.DarkGreen;
                                                        newNode.ToolTipText = packet.des;
                                                        if (packet.des != "")
                                                        {
                                                            newNode.ToolTipText = "Request: " + mNode.Attributes["name"].Value;
                                                            newNode.Text = packet.des;
                                                        }
                                                        treeViewTlcmd.SelectedNode.Nodes[g].Nodes.Add(newNode);

                                                        String dataasstring = DateTime.Now.ToString() + " Creating Request ID#" + maxID + " in database: " + packet.des + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                                                        dataasstring += "\t\t\t from subservice: " + treeViewTlcmd.SelectedNode.Text + Environment.NewLine;
                                                        dataasstring += "\t\t\t Payload: " + packet.data + Environment.NewLine + Environment.NewLine;
                                                        byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                                                        LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log     

                                                        break;
                                                    }

                                                }
                                                return true;

                                            }
                                        }
                                    }
                                }
                            }


                        }
                    }
                    if (this.SaveNode(xNode, dom, serviceType, serviceSubType))
                        return true;
                }
            }
            return false;
        }

        private void buttonDelTC_Click(object sender, EventArgs e)
        {
            // 1. Read XML File from a local path
            string xmlString = File.ReadAllText(pathMyDocuments + Properties.Settings.Default.TC_XML_file, Encoding.UTF8);

            // 2. Create a XML DOM Document and load the data into it.
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xmlString);

            XmlNode inXmlNode = dom.DocumentElement;

            DeleteNode(inXmlNode, dom);

            dom.Save(pathMyDocuments + Properties.Settings.Default.TC_XML_file);


            this.Refresh();
        }

        private bool DeleteNode(XmlNode inXmlNode, XmlDocument dom)
        {
            object pkt = treeViewTlcmd.SelectedNode.Tag;
            if (pkt == null)
                return true;
            Packet packet = (Packet)pkt;

            XmlNode xNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;

                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];

                    if (xNode.LocalName == "packet" && packet.id >= 0)
                    {
                        if (xNode.Attributes["type"].Value == "1")
                        {
                            if (Int16.Parse(xNode.Attributes["id"].Value) == packet.id)
                            {
                                String dataasstring = DateTime.Now.ToString() + " Deleting from database Request ID#" + packet.id + " " + packet.des + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                                dataasstring += "\t\t\t from subservice: " + treeViewTlcmd.SelectedNode.Parent.Text + Environment.NewLine + Environment.NewLine;
                                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                                LogFile.Flush(); //!< espera que se grabe

                                inXmlNode.ChildNodes[i].ParentNode.RemoveChild(xNode);
                                treeViewTlcmd.Nodes.Remove(treeViewTlcmd.SelectedNode);
                                treeViewTlcmd.SelectedNode = null;
                                return true;
                            }
                        }
                    }

                    if (this.DeleteNode(xNode, dom))
                        return true;
                }
            }
            return false;
        }

        private void buttonST14OpenBin_Click(object sender, EventArgs e)
        {
            labelST14Warning.Text = "";
            if (openFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                textBoxST13FileBin.Text = openFileDialogBin.FileName;//!< Extrae el nombre del archivo TLE a cargar del Dialogo de Windows y lo muestra en la GUI
                buttonST13StoreFile.Enabled = true;
                buttonST13StoreDB.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                textBoxRawFile.Text = openFileDialogBin.FileName;//!< Extrae el nombre del archivo TLE a cargar del Dialogo de Windows y lo muestra en la GUI
                buttonLoadSend.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBoxRawFile.Text))//!< Verifica que el archivo exista antes de abrirlo
            {
                byte[] buffer = null;
                using (FileStream fs = new FileStream(textBoxRawFile.Text, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                }

                String dataasstring = DateTime.Now.ToString() + " Tx RAW file: " + textBoxRawFile.Text + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando

                SendCommand(buffer, dataasstring);
            }
        }

        private void buttonST12StoreFile_Click(object sender, EventArgs e)
        {
            labelST14Warning.Text = "";
            if (saveFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                split(saveFileDialogBin.FileName);
                if (labelST14Warning.Text == "")
                    labelST14Warning.Text = "Stored In file " + saveFileDialogBin.FileName;
            }
        }

        private void buttonST12StoreDB_Click(object sender, EventArgs e)
        {
            labelST14Warning.Text = "";
            split("");
            if (labelST14Warning.Text == "")
                labelST14Warning.Text = "Stored In Database";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            labelST14Warning.Text = "";
        }

        private void split(string file)
        {
            if (System.IO.File.Exists(textBoxST13FileBin.Text))//!< Verifica que el archivo exista antes de abrirlo
            {
                byte[] buffer = null;
                using (FileStream fsRead = new FileStream(textBoxST13FileBin.Text, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fsRead.Length];
                    fsRead.Read(buffer, 0, (int)fsRead.Length);
                }
                int position = 0;
                UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST13Seq.Value);

                var size = buffer.Length;
                var maxSize = decimal.ToInt32(numericUpDown2.Value - (Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + Constants.ECSS_CRC_TAIL + 4));
                if (size <= maxSize)
                {
                    labelST14Warning.Text = "Packet shorter than the splitter required";
                    return;
                }

                FileStream fsStore = null;
                if (file != "")
                    fsStore = new FileStream(file, FileMode.Create, FileAccess.Write);

                int parts = decimal.ToInt32(size / maxSize);
                if (size % maxSize > 0)
                    parts++;
                int last_part = size - (parts - 1) * maxSize;
                List<Byte> dataPart = new List<Byte>();
                int indexOffset = 0;
                for (int i = 0; i < maxSize; i++, indexOffset++)
                {
                    dataPart.Add(buffer[indexOffset]);
                }
                UInt16 packetID = decimal.ToUInt16(numericUpDownST12ID.Value);
                if (fsStore != null)
                {
                    int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            buffer.Length + Constants.ECSS_CRC_TAIL - 1;
                    dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                    dataPart.Insert(1, (byte)(applicationId & 0xff));
                    dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                    dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                    dataPart.Insert(4, (byte)(packetDataLength >> 8));
                    dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                    dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                    dataPart.Insert(7, (byte)13);
                    dataPart.Insert(8, (byte)9);
                    dataPart.Insert(9, (byte)(sourceId >> 8));
                    dataPart.Insert(10, (byte)(sourceId & 0xff));

                    dataPart.Insert(11, (byte)(packetID >> 8));
                    dataPart.Insert(12, (byte)(packetID & 0xff));
                    dataPart.Insert(13, 0);
                    dataPart.Insert(14, 0);
                    ushort CRC = calculateCRC(dataPart.ToArray());
                    dataPart.Add((byte)(CRC >> 8));
                    dataPart.Add((byte)(CRC & 0xff));

                    packetSequenceControl++;
                    fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);

                    String dataasstring = DateTime.Now.ToString() + " Creating binary request " + textBoxST13Description.Text + " in file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                    dataasstring += "\t\t\t from service: ST[06] Memory Management, subservice: ST[13,09] Uplink First Part" + Environment.NewLine + Environment.NewLine;
                    byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                    LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                    LogFile.Flush(); //!< espera que se grabe
                }
                else
                {
                    dataPart.Insert(0, (byte)(packetID >> 8));
                    dataPart.Insert(1, (byte)(packetID & 0xff));
                    dataPart.Insert(2, 0);
                    dataPart.Insert(3, 0);
                    object pkt = treeViewTlcmd.SelectedNode.Tag;
                    if (pkt == null)
                        return;
                    Packet packet = (Packet)pkt;
                    packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                    packet.des = textBoxST13Description.Text + "#0";
                    SaveXML(13, 9);

                }

                dataPart.Clear();

                for (int part = 1; part < (parts - 1U); part++)
                {
                    for (int i = 0; i < maxSize; i++, indexOffset++)
                    {
                        dataPart.Add(buffer[indexOffset]);
                    }
                    //message.erase(message.begin(), message.begin() + ECSSMaxFixedOctetMessageSize);
                    //intermediateDownlinkPartReport(largeMessageTransactionIdentifier, part, dataPart);
                    if (fsStore != null)
                    {
                        int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                                buffer.Length + Constants.ECSS_CRC_TAIL - 1;
                        dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                        dataPart.Insert(1, (byte)(applicationId & 0xff));
                        dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                        dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                        dataPart.Insert(4, (byte)(packetDataLength >> 8));
                        dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                        dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                        dataPart.Insert(7, (byte)13);
                        dataPart.Insert(8, (byte)10);
                        dataPart.Insert(9, (byte)(sourceId >> 8));
                        dataPart.Insert(10, (byte)(sourceId & 0xff));
                        packetID = decimal.ToUInt16(numericUpDownST12ID.Value);
                        dataPart.Insert(11, (byte)(packetID >> 8));
                        dataPart.Insert(12, (byte)(packetID & 0xff));
                        dataPart.Insert(13, (byte)(part >> 8));
                        dataPart.Insert(14, (byte)(part & 0xff));
                        ushort CRC = calculateCRC(dataPart.ToArray());
                        dataPart.Add((byte)(CRC >> 8));
                        dataPart.Add((byte)(CRC & 0xff));

                        packetSequenceControl++;

                        fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                        String dataasstring = DateTime.Now.ToString() + " Append binary request " + textBoxST13Description.Text + " into file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                        dataasstring += "\t\t\t from service: ST[06] Memory Management, subservice: ST[13,10] Uplink Intermediate Part" + Environment.NewLine + Environment.NewLine;
                        byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                        LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                        LogFile.Flush(); //!< espera que se grabe
                    }
                    else
                    {
                        dataPart.Insert(0, (byte)(packetID >> 8));
                        dataPart.Insert(1, (byte)(packetID & 0xff));
                        dataPart.Insert(2, (byte)(part >> 8));
                        dataPart.Insert(3, (byte)(part & 0xff));
                        object pkt = treeViewTlcmd.SelectedNode.Tag;
                        if (pkt == null)
                            return;
                        Packet packet = (Packet)pkt;
                        packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                        packet.des = textBoxST13Description.Text + "#" + part;
                        SaveXML(13, 10);

                    }
                    dataPart.Clear();
                }


                for (int i = 0; i < last_part; i++, indexOffset++)
                {
                    dataPart.Add(buffer[indexOffset]);
                }

                //lastDownlinkPartReport(largeMessageTransactionIdentifier, (parts - 1U), dataPart);
                if (fsStore != null)
                {
                    int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            buffer.Length + Constants.ECSS_CRC_TAIL - 1;
                    dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                    dataPart.Insert(1, (byte)(applicationId & 0xff));
                    dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                    dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                    dataPart.Insert(4, (byte)(packetDataLength >> 8));
                    dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                    dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                    dataPart.Insert(7, (byte)13);
                    dataPart.Insert(8, (byte)11);
                    dataPart.Insert(9, (byte)(sourceId >> 8));
                    dataPart.Insert(10, (byte)(sourceId & 0xff));
                    packetID = decimal.ToUInt16(numericUpDownST12ID.Value);
                    dataPart.Insert(11, (byte)(packetID >> 8));
                    dataPart.Insert(12, (byte)(packetID & 0xff));
                    dataPart.Insert(13, (byte)((parts - 1U) >> 8));
                    dataPart.Insert(14, (byte)((parts - 1U) & 0xff));
                    ushort CRC = calculateCRC(dataPart.ToArray());
                    dataPart.Add((byte)(CRC >> 8));
                    dataPart.Add((byte)(CRC & 0xff));

                    packetSequenceControl++;
                    fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);

                    fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                    String dataasstring = DateTime.Now.ToString() + " Append binary request " + textBoxST13Description.Text + " into file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                    dataasstring += "\t\t\t from service: ST[06] Memory Management, subservice: ST[13,11] Uplink Last Part" + Environment.NewLine + Environment.NewLine;
                    byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                    LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                    LogFile.Flush(); //!< espera que se grabe               
                }
                else
                {
                    dataPart.Insert(0, (byte)(packetID >> 8));
                    dataPart.Insert(1, (byte)(packetID & 0xff));
                    dataPart.Insert(2, (byte)((parts - 1U) >> 8));
                    dataPart.Insert(3, (byte)((parts - 1U) & 0xff));
                    object pkt = treeViewTlcmd.SelectedNode.Tag;
                    if (pkt == null)
                        return;
                    Packet packet = (Packet)pkt;
                    packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                    packet.des = textBoxST13Description.Text + "#" + (parts-1);
                    SaveXML(13, 11);

                }
                if (fsStore != null)
                    fsStore.Close();
            }

            return;
        }

        private void buttonST06Add_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBoxST06File.Text))//!< Verifica que el archivo exista antes de abrirlo
            {
                byte[] buffer = null;
                using (FileStream fsRead = new FileStream(textBoxST06File.Text, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fsRead.Length];
                    fsRead.Read(buffer, 0, (int)fsRead.Length);
                }
                int position = 0;
                UInt16 crc = calculateCRC(buffer);

                var dr = memoryUpload.NewRow();
                dr["Offset"] = textBoxST06Memory.Text;
                dr["Path"] = textBoxST06File.Text;
                dr["Length"] = string.Format("{0:x4}", buffer.Length);
                dr["CRC"] = string.Format("{0:x4}", crc);

                memoryUpload.Rows.Add(dr);

                buttonST06StoreFile.Enabled = true;
                buttonST06StoreDB.Enabled = true;
            }

        }

        private void textBoxST06Memory_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxST06Memory.Text, @"^[A-Fa-f0-9]*$") == false)
            {
                labelST06Warning.Text = "Invalid memory offset";
                return;
            }
            labelST06Warning.Text = "";
        }

        private void buttonST06File_Click(object sender, EventArgs e)
        {
            labelST06Warning.Text = "";
            if (openFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                textBoxST06File.Text = openFileDialogBin.FileName;//!< Extrae el nombre del archivo TLE a cargar del Dialogo de Windows y lo muestra en la GUI

                if (Regex.IsMatch(textBoxST06Memory.Text, @"^[A-Fa-f0-9]*$") == false)
                {
                    labelST06Warning.Text = "Invalid memory offset";
                    return;
                }
                buttonST06Add.Enabled = true;
            }
        }

        private void dataGridViewST06_SelectionChanged(object sender, EventArgs e)
        {
            buttonST06Del.Enabled = false;
            if (dataGridViewST06.SelectedRows.Count > 0)
            {
                if (dataGridViewST06.SelectedRows[0].Index < dataGridViewST06.Rows.Count - 1)
                    buttonST06Del.Enabled = true;
            }
        }

        private void buttonST06Del_Click(object sender, EventArgs e)
        {
            if (dataGridViewST06.SelectedRows.Count > 0)
            {
                dataGridViewST06.Rows.RemoveAt(this.dataGridViewST06.SelectedRows[0].Index);
            }
            if (dataGridViewST06.Rows.Count - 1 == 0)
            {
                buttonST06StoreFile.Enabled = false;
                buttonST06StoreDB.Enabled = false;
            }
        }

        private void buttonST06StoreFile_Click(object sender, EventArgs e)
        {
            labelST06Warning.Text = "";
            if (saveFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
               memoryDump(saveFileDialogBin.FileName);
                if (labelST06Warning.Text == "")
                    labelST06Warning.Text = "Stored In file " + saveFileDialogBin.FileName;
            }
        }

        private void buttonST06StoreDB_Click(object sender, EventArgs e)
        {
            labelST06Warning.Text = "";
            memoryDump("");
            if (labelST06Warning.Text == "")
                labelST06Warning.Text = "Stored In Database";
        }

        private void memoryDump(string file)
        {
            List<Byte> dataPart = new List<Byte>();
            UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST06Seq.Value);
            dataPart.Add((byte)(numericUpDownMemID.Value));

            UInt16 count = (UInt16)(dataGridViewST06.Rows.Count - 1);

            dataPart.Add((byte)(count >> 8));
            dataPart.Add((byte)(count & 0xff));

            for (int i = 0; i < dataGridViewST06.Rows.Count - 1; i++)
            {
                if (System.IO.File.Exists(dataGridViewST06.Rows[i].Cells[1].Value.ToString()))//!< Verifica que el archivo exista antes de abrirlo
                {
                    byte[] buffer = null;
                    using (FileStream fsRead = new FileStream(dataGridViewST06.Rows[i].Cells[1].Value.ToString(), FileMode.Open, FileAccess.Read))
                    {
                        buffer = new byte[fsRead.Length];
                        fsRead.Read(buffer, 0, (int)fsRead.Length);
                    }
                    UInt64 offset = Convert.ToUInt64(dataGridViewST06.Rows[i].Cells[0].Value.ToString(), 16);
                    UInt16 length = Convert.ToUInt16(dataGridViewST06.Rows[i].Cells[2].Value.ToString(), 16);
                    UInt16 crc = Convert.ToUInt16(dataGridViewST06.Rows[i].Cells[3].Value.ToString(), 16);

                    dataPart.Add((byte)((offset >> 56) & 0xff));
                    dataPart.Add((byte)((offset >> 48) & 0xff));
                    dataPart.Add((byte)((offset >> 40) & 0xff));
                    dataPart.Add((byte)((offset >> 32) & 0xff));
                    dataPart.Add((byte)((offset >> 24) & 0xff));
                    dataPart.Add((byte)((offset >> 16) & 0xff));
                    dataPart.Add((byte)((offset >> 8) & 0xff));
                    dataPart.Add((byte)(offset & 0xff));
                    dataPart.Add((byte)((length >> 8) & 0xff));
                    dataPart.Add((byte)(length & 0xff));
                    for (int j = 0; j < buffer.Length; j++)
                    {
                        dataPart.Add(buffer[j]);
                    }
                    dataPart.Add((byte)((crc >> 8) | 0xff));
                    dataPart.Add((byte)(crc & 0xff));
                }
                else
                {
                    labelST14Warning.Text = "File not found " + dataGridViewST06.Rows[i].Cells[1].Value.ToString();
                    return;
                }
            }
            if (file != "")
            {
                FileStream fsStore = null;

                fsStore = new FileStream(file, FileMode.Create, FileAccess.Write);
                int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                        dataPart.Count + Constants.ECSS_CRC_TAIL - 1;
                dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                dataPart.Insert(1, (byte)(applicationId & 0xff));
                dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                dataPart.Insert(4, (byte)(packetDataLength >> 8));
                dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                dataPart.Insert(7, (byte)6);
                dataPart.Insert(8, (byte)2);
                dataPart.Insert(9, (byte)(sourceId >> 8));
                dataPart.Insert(10, (byte)(sourceId & 0xff));
                ushort CRC = calculateCRC(dataPart.ToArray());
                dataPart.Add((byte)(CRC >> 8));
                dataPart.Add((byte)(CRC & 0xff));
                fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                if (fsStore != null)
                    fsStore.Close();

                String dataasstring = DateTime.Now.ToString() + " Creating binary request " + textBoxST06Description.Text + " in file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                dataasstring += "\t\t\t from service: ST[06] Memory Management, subservice: ST[06,02] Load Raw Memory Data Areas" + Environment.NewLine + Environment.NewLine;
                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                LogFile.Flush(); //!< espera que se grabe
            }
            else
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt == null)
                    return;
                Packet packet = (Packet)pkt;
                packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                packet.des = textBoxST06Description.Text;
                SaveXML(6, 2);
            }
            return;
        }


        public void CopyTreeNodes(TreeView treeview1, TreeView treeview2)
        {
            TreeNode newTn;
            foreach (TreeNode tn in treeview1.Nodes)
            {
                newTn = (TreeNode)tn.Clone();
                 treeview2.Nodes.Add(newTn);
            }
        }

        private void dataGridViewST11_SelectionChanged(object sender, EventArgs e)
        {
            buttonST11Del.Enabled = false;
            if (dataGridViewST11.SelectedRows.Count > 0)
            {
                if (dataGridViewST11.SelectedRows[0].Index < dataGridViewST11.Rows.Count - 1)
                    buttonST11Del.Enabled = true;
            }
        }

        private void treeViewST11_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonST11Add.Enabled = false;
            if (treeViewST11.SelectedNode != null)
            {
                object pkt = treeViewST11.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        buttonST11Add.Enabled = true;
                    }
                }
            }
        }

        private void buttonST11Add_Click(object sender, EventArgs e)
        {

            if (treeViewST11.SelectedNode != null)
            {
                object pkt = treeViewST11.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        byte[] data = new byte[Constants.ECCS_PRIMARY_HEADER +
                                            Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL];
                        int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL - 1;
                        UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST11Seq.Value);
                        numericUpDownST11Seq.Value += 1;
                        byte ackflags = 0;

                        data[0] = (byte)((applicationId >> 8) | 0x18);
                        data[1] = (byte)(applicationId & 0xff);
                        data[2] = (byte)((packetSequenceControl >> 8) | 0xc0);
                        data[3] = (byte)(packetSequenceControl & 0xff);
                        data[4] = (byte)(packetDataLength >> 8);
                        data[5] = (byte)(packetDataLength & 0xff);

                        data[Constants.ECCS_PRIMARY_HEADER + 0] = (byte)(Constants.ECSSPUSVersion << 4); // Assign the pusVersion = 2
                        data[Constants.ECCS_PRIMARY_HEADER + 0] |= (byte)(ackflags & 0x0F);                 // Spacecraft time reference status
                        data[Constants.ECCS_PRIMARY_HEADER + 1] = packet.serviceType;
                        data[Constants.ECCS_PRIMARY_HEADER + 2] = packet.serviceSubType;
                        data[Constants.ECCS_PRIMARY_HEADER + 3] = (byte)(sourceId >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + 4] = (byte)(sourceId & 0xff);

                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] =
                                            Convert.ToByte(s, 16);

                        ushort CRC = calculateCRC(data);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC & 0xff);

                        var dr = schedulingUpload.NewRow();
                        dr["Time"] = numericUpDownST11Release.Value.ToString();
                        dr["Command"] = treeViewST11.SelectedNode.Text;
                        dr["Description"] = packet.des;
                        dr["RAW"] = BitConverter.ToString(data.ToArray()).Replace("-", string.Empty); ;
                        schedulingUpload.Rows.Add(dr);

                        buttonST11StoreFile.Enabled = true;
                        buttonST11StoreDB.Enabled = true;
                    }
                }
            }
        }

        private void buttonST11Del_Click(object sender, EventArgs e)
        {
            if (dataGridViewST11.SelectedRows.Count > 0)
            {
                dataGridViewST11.Rows.RemoveAt(this.dataGridViewST11.SelectedRows[0].Index);
            }
            if (dataGridViewST11.Rows.Count - 1 == 0)
            {
                buttonST11StoreFile.Enabled = false;
                buttonST11StoreDB.Enabled = false;
            }
        }

        private void buttonST11StoreFile_Click(object sender, EventArgs e)
        {
            labelST11Warning.Text = "";
            if (saveFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                schedulingDump(saveFileDialogBin.FileName);
                if (labelST11Warning.Text == "")
                    labelST11Warning.Text = "Stored In file " + saveFileDialogBin.FileName;
            }
        }

        private void buttonST11StoreDB_Click(object sender, EventArgs e)
        {
            labelST11Warning.Text = "";
            schedulingDump("");
            if (labelST11Warning.Text == "")
                labelST11Warning.Text = "Stored In Database";
        }

        private void schedulingDump(string file)
        {
            List<Byte> dataPart = new List<Byte>();
            UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST11OverallSeq.Value);

            UInt16 count = (UInt16)schedulingUpload.Rows.Count;

            dataPart.Add((byte)(count >> 8));
            dataPart.Add((byte)(count & 0xff));

            for (int i = 0; i < schedulingUpload.Rows.Count; i++)
            {

                    UInt32 time = Convert.ToUInt32(schedulingUpload.Rows[i]["Time"]);
                    string stringData = schedulingUpload.Rows[i]["RAW"].ToString();
                    dataPart.Add((byte)((time >> 24) & 0xff));
                    dataPart.Add((byte)((time >> 16) & 0xff));
                    dataPart.Add((byte)((time >> 8) & 0xff));
                    dataPart.Add((byte)(time & 0xff));
                    foreach (string s in SplitInParts(stringData, 2))
                        dataPart.Add(Convert.ToByte(s, 16));

            }
            if (file != "")
            {
                FileStream fsStore = null;

                fsStore = new FileStream(file, FileMode.Create, FileAccess.Write);
                int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                        dataPart.Count + Constants.ECSS_CRC_TAIL - 1;
                dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                dataPart.Insert(1, (byte)(applicationId & 0xff));
                dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                dataPart.Insert(4, (byte)(packetDataLength >> 8));
                dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                dataPart.Insert(7, (byte)11);
                dataPart.Insert(8, (byte)4);
                dataPart.Insert(9, (byte)(sourceId >> 8));
                dataPart.Insert(10, (byte)(sourceId & 0xff));
                ushort CRC = calculateCRC(dataPart.ToArray());
                dataPart.Add((byte)(CRC >> 8));
                dataPart.Add((byte)(CRC & 0xff));
                fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                if (fsStore != null)
                    fsStore.Close();

                String dataasstring = DateTime.Now.ToString() + " Creating binary request " + textBoxST11Description.Text + " in file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                dataasstring += "\t\t\t from service: ST[11] Time-based Scheduling, subservice: ST[11,04] Insert Activities" + Environment.NewLine + Environment.NewLine;
                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                LogFile.Flush(); //!< espera que se grabe
            }
            else
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt == null)
                    return;
                Packet packet = (Packet)pkt;
                packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                packet.des = textBoxST11Description.Text;
                SaveXML(11, 4);
            }
            return;
        }

        private void treeViewST21_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonST21Add.Enabled = false;
            if (treeViewST21.SelectedNode != null)
            {
                object pkt = treeViewST21.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        buttonST21Add.Enabled = true;
                    }
                }
            }
        }

        private void dataGridViewST21_SelectionChanged(object sender, EventArgs e)
        {
            buttonST21Del.Enabled = false;
            if (dataGridViewST21.SelectedRows.Count > 0)
            {
                if (dataGridViewST21.SelectedRows[0].Index < dataGridViewST21.Rows.Count - 1)
                    buttonST21Del.Enabled = true;
            }
        }

        private void buttonST21Add_Click(object sender, EventArgs e)
        {
            if (treeViewST21.SelectedNode != null)
            {
                object pkt = treeViewST21.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        byte[] data = new byte[Constants.ECCS_PRIMARY_HEADER +
                                            Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL];
                        int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL - 1;
                        UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST21Seq.Value);
                        numericUpDownST21Seq.Value += 1;
                        byte ackflags = 0;

                        data[0] = (byte)((applicationId >> 8) | 0x18);
                        data[1] = (byte)(applicationId & 0xff);
                        data[2] = (byte)((packetSequenceControl >> 8) | 0xc0);
                        data[3] = (byte)(packetSequenceControl & 0xff);
                        data[4] = (byte)(packetDataLength >> 8);
                        data[5] = (byte)(packetDataLength & 0xff);

                        data[Constants.ECCS_PRIMARY_HEADER + 0] = (byte)(Constants.ECSSPUSVersion << 4); // Assign the pusVersion = 2
                        data[Constants.ECCS_PRIMARY_HEADER + 0] |= (byte)(ackflags & 0x0F);                 // Spacecraft time reference status
                        data[Constants.ECCS_PRIMARY_HEADER + 1] = packet.serviceType;
                        data[Constants.ECCS_PRIMARY_HEADER + 2] = packet.serviceSubType;
                        data[Constants.ECCS_PRIMARY_HEADER + 3] = (byte)(sourceId >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + 4] = (byte)(sourceId & 0xff);

                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] =
                                            Convert.ToByte(s, 16);

                        ushort CRC = calculateCRC(data);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC & 0xff);

                        var dr = sequencingUpload.NewRow();
                        dr["Delay"] = numericUpDownST21Delay.Value.ToString();
                        dr["Command"] = treeViewST21.SelectedNode.Text;
                        dr["Description"] = packet.des;
                        dr["RAW"] = BitConverter.ToString(data.ToArray()).Replace("-", string.Empty); ;
                        sequencingUpload.Rows.Add(dr);

                        buttonST21StoreFile.Enabled = true;
                        buttonST21StoreDB.Enabled = true;
                    }
                }
            }
        }

        private void buttonST21Del_Click(object sender, EventArgs e)
        {
            if (dataGridViewST21.SelectedRows.Count > 0)
            {
                dataGridViewST21.Rows.RemoveAt(this.dataGridViewST21.SelectedRows[0].Index);
            }
            if (dataGridViewST21.Rows.Count - 1 == 0)
            {
                buttonST21StoreFile.Enabled = false;
                buttonST21StoreDB.Enabled = false;
            }
        }

        private void buttonST21StoreFile_Click(object sender, EventArgs e)
        {
            labelST21Warning.Text = "";
            if (saveFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                sequencingDump(saveFileDialogBin.FileName);
                if (labelST21Warning.Text == "")
                    labelST21Warning.Text = "Stored In file " + saveFileDialogBin.FileName;
            }
        }

        private void buttonST21StoreDB_Click(object sender, EventArgs e)
        {
            labelST21Warning.Text = "";
            sequencingDump("");
            if (labelST21Warning.Text == "")
                labelST21Warning.Text = "Stored In Database";

        }

        private void sequencingDump(string file)
        {
            List<Byte> dataPart = new List<Byte>();
            UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST21OverallSeq.Value);
            byte[] bytesID = Encoding.ASCII.GetBytes(textBoxST21ID.Text);
            int j = 0;
            for (; j < bytesID.Length; j++)
                dataPart.Add(bytesID[j]);
            for (; j < Properties.Settings.Default.ST21StringSize; j++)
                dataPart.Add(0);
            UInt16 count = (UInt16)sequencingUpload.Rows.Count;

            dataPart.Add((byte)(count >> 8));
            dataPart.Add((byte)(count & 0xff));

            for (int i = 0; i < sequencingUpload.Rows.Count; i++)
            {
                UInt32 delay = Convert.ToUInt32(sequencingUpload.Rows[i]["Delay"]);
                string stringData = sequencingUpload.Rows[i]["RAW"].ToString();
                foreach (string s in SplitInParts(stringData, 2))
                    dataPart.Add(Convert.ToByte(s, 16));

                dataPart.Add((byte)((delay >> 24) & 0xff));
                dataPart.Add((byte)((delay >> 16) & 0xff));
                dataPart.Add((byte)((delay >> 8) & 0xff));
                dataPart.Add((byte)(delay & 0xff));


            }
            if (file != "")
            {
                FileStream fsStore = null;

                fsStore = new FileStream(file, FileMode.Create, FileAccess.Write);
                int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                        dataPart.Count + Constants.ECSS_CRC_TAIL - 1;
                dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                dataPart.Insert(1, (byte)(applicationId & 0xff));
                dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                dataPart.Insert(4, (byte)(packetDataLength >> 8));
                dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                dataPart.Insert(7, (byte)21);
                dataPart.Insert(8, (byte)1);
                dataPart.Insert(9, (byte)(sourceId >> 8));
                dataPart.Insert(10, (byte)(sourceId & 0xff));
                ushort CRC = calculateCRC(dataPart.ToArray());
                dataPart.Add((byte)(CRC >> 8));
                dataPart.Add((byte)(CRC & 0xff));
                fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                if (fsStore != null)
                    fsStore.Close();
                String dataasstring = DateTime.Now.ToString() + " Creating binary request " + textBoxST21Description.Text + " in file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                dataasstring += "\t\t\t from service: ST[21] Request Sequencing, subservice: ST[21,01] Direct Load Request Sequence" + Environment.NewLine + Environment.NewLine;
                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                LogFile.Flush(); //!< espera que se grabe
            }
            else
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt == null)
                    return;
                Packet packet = (Packet)pkt;
                packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                packet.des = textBoxST21Description.Text;
                SaveXML(21, 1);
            }
            return;
        }
        private void treeViewST19_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonST19Add.Enabled = false;
            if (treeViewST19.SelectedNode != null)
            {
                object pkt = treeViewST19.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        buttonST19Add.Enabled = true;
                    }
                }
            }
        }
        private void dataGridViewST19_SelectionChanged(object sender, EventArgs e)
        {
            buttonST19Del.Enabled = false;
            if (dataGridViewST19.SelectedRows.Count > 0)
            {
                if (dataGridViewST19.SelectedRows[0].Index < dataGridViewST19.Rows.Count - 1)
                    buttonST19Del.Enabled = true;
            }
        }
        private void buttonST19Add_Click(object sender, EventArgs e)
        {
            if (treeViewST19.SelectedNode != null)
            {
                object pkt = treeViewST19.SelectedNode.Tag;
                if (pkt != null)
                {
                    Packet packet = (Packet)pkt;

                    if (packet.packetType == PacketType.TC)
                    {
                        byte[] data = new byte[Constants.ECCS_PRIMARY_HEADER +
                                            Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL];
                        int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                                            packet.data.Length / 2 +
                                            Constants.ECSS_CRC_TAIL - 1;
                        UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST19Seq.Value);
                        numericUpDownST19Seq.Value += 1;
                        byte ackflags = 0;

                        data[0] = (byte)((applicationId >> 8) | 0x18);
                        data[1] = (byte)(applicationId & 0xff);
                        data[2] = (byte)((packetSequenceControl >> 8) | 0xc0);
                        data[3] = (byte)(packetSequenceControl & 0xff);
                        data[4] = (byte)(packetDataLength >> 8);
                        data[5] = (byte)(packetDataLength & 0xff);

                        data[Constants.ECCS_PRIMARY_HEADER + 0] = (byte)(Constants.ECSSPUSVersion << 4); // Assign the pusVersion = 2
                        data[Constants.ECCS_PRIMARY_HEADER + 0] |= (byte)(ackflags & 0x0F);                 // Spacecraft time reference status
                        data[Constants.ECCS_PRIMARY_HEADER + 1] = packet.serviceType;
                        data[Constants.ECCS_PRIMARY_HEADER + 2] = packet.serviceSubType;
                        data[Constants.ECCS_PRIMARY_HEADER + 3] = (byte)(sourceId >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + 4] = (byte)(sourceId & 0xff);

                        int i = 0;
                        foreach (string s in SplitInParts(packet.data, 2))
                            data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] =
                                            Convert.ToByte(s, 16);

                        ushort CRC = calculateCRC(data);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC >> 8);
                        data[Constants.ECCS_PRIMARY_HEADER + Constants.ECCS_SECONDARY_TC_HEADER + i++] = (byte)(CRC & 0xff);

                        var dr =eventsUpload.NewRow();
                        dr["EventID"] = numericUpDownST19EventID.Value.ToString();
                        dr["AppID"] = numericUpDownST19AppID.Value.ToString();
                        dr["Command"] = treeViewST19.SelectedNode.Text;
                        dr["Description"] = packet.des;
                        dr["RAW"] = BitConverter.ToString(data.ToArray()).Replace("-", string.Empty); ;
                        eventsUpload.Rows.Add(dr);

                        buttonST19StoreFile.Enabled = true;
                        buttonST19StoreDB.Enabled = true;
                    }
                }
            }
        }

        private void buttonST19Del_Click(object sender, EventArgs e)
        {
            if (dataGridViewST19.SelectedRows.Count > 0)
            {
                dataGridViewST19.Rows.RemoveAt(this.dataGridViewST19.SelectedRows[0].Index);
            }
            if (dataGridViewST19.Rows.Count - 1 == 0)
            {
                buttonST19StoreFile.Enabled = false;
                buttonST19StoreDB.Enabled = false;
            }
        }
        private void buttonST19StoreFile_Click(object sender, EventArgs e)
        {
            labelST19Warning.Text = "";
            if (saveFileDialogBin.ShowDialog() == DialogResult.OK)//!< Si el no hubo error en la seleccion de un archivo TLE desde el Dialogo de apertura de archivo de Windows
            {
                eventDump(saveFileDialogBin.FileName);
                if (labelST19Warning.Text == "")
                    labelST19Warning.Text = "Stored In file " + saveFileDialogBin.FileName;
            }
        }

        private void buttonST19StoreDB_Click(object sender, EventArgs e)
        {
            labelST19Warning.Text = "";
            eventDump("");
            if (labelST19Warning.Text == "")
                labelST19Warning.Text = "Stored In Database";

        }
        private void eventDump(string file)
        {
            List<Byte> dataPart = new List<Byte>();
            UInt16 packetSequenceControl = decimal.ToUInt16(numericUpDownST19OverallSeq.Value);
            UInt16 count = (UInt16)eventsUpload.Rows.Count;

            dataPart.Add((byte)(count >> 8));
            dataPart.Add((byte)(count & 0xff));

            for (int i = 0; i < eventsUpload.Rows.Count; i++)
            {
                UInt16 eventID = Convert.ToUInt16(eventsUpload.Rows[i]["EventID"]);
                dataPart.Add((byte)((eventID >> 8) & 0xff));
                dataPart.Add((byte)(eventID & 0xff));
                UInt16 appID = Convert.ToUInt16(eventsUpload.Rows[i]["AppID"]);
                dataPart.Add((byte)((appID >> 8) & 0xff));
                dataPart.Add((byte)(appID & 0xff));
                string stringData = eventsUpload.Rows[i]["RAW"].ToString();
                foreach (string s in SplitInParts(stringData, 2))
                    dataPart.Add(Convert.ToByte(s, 16));
            }
            if (file != "")
            {
                FileStream fsStore = null;

                fsStore = new FileStream(file, FileMode.Create, FileAccess.Write);
                int packetDataLength = Constants.ECCS_SECONDARY_TC_HEADER +
                        dataPart.Count + Constants.ECSS_CRC_TAIL - 1;
                dataPart.Insert(0, (byte)((applicationId >> 8) | 0x18));
                dataPart.Insert(1, (byte)(applicationId & 0xff));
                dataPart.Insert(2, (byte)((packetSequenceControl >> 8) | 0xc0));
                dataPart.Insert(3, (byte)(packetSequenceControl & 0xff));
                dataPart.Insert(4, (byte)(packetDataLength >> 8));
                dataPart.Insert(5, (byte)(packetDataLength & 0xff));
                dataPart.Insert(6, (byte)(Constants.ECSSPUSVersion << 4));
                dataPart.Insert(7, (byte)19);
                dataPart.Insert(8, (byte)1);
                dataPart.Insert(9, (byte)(sourceId >> 8));
                dataPart.Insert(10, (byte)(sourceId & 0xff));
                ushort CRC = calculateCRC(dataPart.ToArray());
                dataPart.Add((byte)(CRC >> 8));
                dataPart.Add((byte)(CRC & 0xff));
                fsStore.Write(dataPart.ToArray(), 0, dataPart.Count);
                if (fsStore != null)
                    fsStore.Close();

                String dataasstring = DateTime.Now.ToString() + " Creating binary request " + textBoxST19Description.Text + " in file " + file + Environment.NewLine;  //!< crea un string para guardar en el log el comando recibido, le agrega la fecha/hora y el nombre del commando
                dataasstring += "\t\t\t from service: ST[19] Event-action, subservice: ST[19,01] Add Event Action" + Environment.NewLine + Environment.NewLine;
                byte[] infohex = new UTF8Encoding(true).GetBytes(dataasstring); //!< Codifica ese string en UTF8
                LogFile.Write(infohex, 0, infohex.Length); //!< y lo graba en el archivo de log
                LogFile.Flush(); //!< espera que se grabe
            }
            else
            {
                object pkt = treeViewTlcmd.SelectedNode.Tag;
                if (pkt == null)
                    return;
                Packet packet = (Packet)pkt;
                packet.data = BitConverter.ToString(dataPart.ToArray()).Replace("-", string.Empty);
                packet.des = textBoxST19Description.Text;
                SaveXML(19, 1);
            }
            return;
        }

    }
}

