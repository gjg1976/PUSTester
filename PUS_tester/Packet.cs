using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUS_tester
{
	static class Constants//! Clase que contiene las constantes utilizadas para el calculo de offset y tamanos de los paquetes de comandos y telemetrias
	{
		public const int ECSSPUSVersion = 2;
		public const int ECCS_PRIMARY_HEADER = 6;
		public const int ECCS_SECONDARY_TC_HEADER = 5;
		public const int ECCS_SECONDARY_TM_HEADER = 7;
		public const int ECCS_TIME_HEADER = 4;
		public const int ECSS_CRC_TAIL = 2;
	}
	public enum PacketType
	{
		TM = 0, ///< Telemetry
		TC = 1,  ///< Telecommand
		TCT = 2, ///< Telecommand Template
		SPC = 255 ///< SpecialGUI
	};

	public class Packet
    {
		/**
		 * The destination APID of the message
		 *
		 * Maximum value of 2047 (5.4.2.1c)
		 */
		public ushort applicationId = 0;
		// As specified in CCSDS 133.0-B-1 (TM or TC)
		public PacketType packetType = PacketType.TM;
		public bool secondaryHeaderFlag = true;
		public byte sequenceFlags = 3;
		public ushort packetSequenceCount = 0;
		public ushort packet_length = 0;
		public byte pusVersion = 2;
		public byte ack = 0;
		public byte scTimeRef = 0;
		public byte serviceType = 0;
		public byte serviceSubType = 0;
		public ushort sourceId = 0;
		public byte packetSubCounter = 0;
		public ushort destiantionId = 0;
		public string data;
		public ushort crc = 0;
		public string template = "";
		public string des = "";
		public short id = -1;

		public Packet(short pkt_id, string description, ushort apid, PacketType pkttype, byte pkt_ack, byte srvtype,
			  byte srvsubtype, ushort srcid, string pkt_data)
        {
			des = description;
			applicationId = apid;
			packetType = pkttype;
			secondaryHeaderFlag = true;
			sequenceFlags = 3;

			ack = pkt_ack;

			serviceType = srvtype;
			serviceSubType = srvsubtype;
			sourceId = srcid;
			data = pkt_data;

			id = pkt_id;
			//ushort packet_length = 0;
			//ushort crc = 0;

		}
		public Packet(short pkt_id, string description, ushort apid, PacketType pkttype, byte pkt_ack, byte srvtype,
			  byte srvsubtype, ushort srcid, string pkt_data, string template_form)
		{
			des = description;
			applicationId = apid;
			packetType = pkttype;
			secondaryHeaderFlag = true;
			sequenceFlags = 3;

			ack = pkt_ack;

			serviceType = srvtype;
			serviceSubType = srvsubtype;
			sourceId = srcid;
			data = pkt_data;

			template = template_form;
			id = pkt_id;
		}
		public Packet(ushort apid, PacketType pkttype, byte srvtype,
				byte srvsubtype, ushort srcid, string template_form)
		{
			applicationId = apid;
			packetType = pkttype;
			secondaryHeaderFlag = true;
			sequenceFlags = 3;

			serviceType = srvtype;
			serviceSubType = srvsubtype;
			sourceId = srcid;
			template = template_form;


			data = "";

		}
	}
}
