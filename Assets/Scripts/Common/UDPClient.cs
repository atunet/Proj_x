using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;

public class UDPClient
{
    internal static Byte HEAD_LEN = 4;
    internal static Byte MSG_ID_LEN = 2;
    internal static Byte SEQUENCE_LEN = 4;


    private String m_serverIP = null;
    private int m_serverPort = 0;
    private Socket m_socket = null;
    private UInt32 s_seqNO = 0;


    public UDPClient (string ip_, int port_)
    {   
        m_serverIP = ip_;
        m_serverPort = port_;
    }

}
