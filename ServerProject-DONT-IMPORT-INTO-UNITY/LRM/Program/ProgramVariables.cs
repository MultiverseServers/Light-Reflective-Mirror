﻿using LightReflectiveMirror.Endpoints;
using Mirror;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace LightReflectiveMirror
{
    partial class Program
    {
        public static Transport transport;
        public static Program instance;
        public static Config conf;
        
        private RelayHandler _relay;
        private MethodInfo _awakeMethod;
        private MethodInfo _startMethod;
        private MethodInfo _updateMethod;
        private MethodInfo _lateUpdateMethod;

        private DateTime _startupTime;
        public static string publicIP;
        private List<int> _currentConnections = new List<int>();
        public Dictionary<int, IPEndPoint> NATConnections = new Dictionary<int, IPEndPoint>();
        private BiDictionary<int, string> _pendingNATPunches = new BiDictionary<int, string>();
        private int _currentHeartbeatTimer = 0;

        private byte[] _NATRequest = new byte[500];
        private int _NATRequestPosition = 0;

        private UdpClient _punchServer;

        private const string CONFIG_PATH = "config.json";
    }
}