﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Author: Eddy Meivogel
 * Website: www.eddymeivogel.com
 */
namespace QServer.Network
{
    public struct PacketDatas
    {
        public const string PACKET_HEADER = "^";
        public const string PACKET_SPLIT = "*";
        public const string PACKET_CHAT = "Chat";
        public const string LOGIN_PACKET = "Login";
        public const string PACKET_ERROR = "Error";
        public const string PACKET_GAME_CREATE = "GaCreate";
        public const string PACKET_GAME_SEL = "GaSel";
        public const string PACKET_GAME_START = "GaStart";
        public const string PACKET_GAME_DESTROY = "GaKill";
        public const string PACKET_GET_GAME_ROOM = "GaGetRoom";
    }
}
