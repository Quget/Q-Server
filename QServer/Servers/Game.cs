﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QServer.Network;

namespace QServer.Servers
{
    class Game:Server
    {
        private GameRoom gameRoom;
        public Game(GameRoom gameRoom):base()
        {
            this.gameRoom = gameRoom;
        }
        protected override void client_received(Client sender, string[] packetStrings)
        {
            switch (packetStrings[0])
            {
                case PacketDatas.PACKET_CHAT:
                    DoChat(sender, packetStrings);
                    break;
                case PacketDatas.PACKET_GAME_STOP:
                    GameStop(sender, packetStrings);
                    break;
                case PacketDatas.PACKET_GAME_POS:
                    DoSendPos(sender,packetStrings);
                    break;

                case PacketDatas.PACKET_GAME_IMAGE_START:

                    break;
                case PacketDatas.PACKET_GAME_IMAGE:
                    DoSendImage(sender, packetStrings);
                    break;
                case PacketDatas.PACKET_GAME_IMAGE_END:
                    DoSendImage(sender, packetStrings);
                    break;
                default:
                    Eutils.WriteLine("[Gameroom InGame {1}] Error wrong packet! {0}",Eutils.MESSSAGE_TYPE.ERROR, packetStrings[1], gameRoom.gameRoomName);
                    break;
            }
        }

        private void DoSendImage(Client sender, string[] packetStrings)
        {
            SendToAll(packetStrings[1]);
        }

        private void DoSendPos(Client sender, string[] packetStrings)
        {
            SendToAll(packetStrings[1]);
        }
        private void GameStop(Client sender, String[] packetStrings)
        {
            for(int i = 0; i < clients.Count; i++)
            {
                gameRoom.AddClient(clients[i]);
            }
            RemoveAllClients();
        }
        private void DoChat(Client sender, String[] packetStrings)
        {
            string chatPackage = PacketDatas.PACKET_CHAT + PacketDatas.PACKET_SPLIT + sender.userName + ": " + packetStrings[1];
            for (int c = 0; c < clients.Count; c++)
            {
                clients[c].Send(chatPackage);
            }
        }
    }
}
