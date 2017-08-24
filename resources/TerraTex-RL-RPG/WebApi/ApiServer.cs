using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TerraTex_RL_RPG.WebApi
{
    public class ApiServer
    {
        public class Test : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                TestFunc(this, e.Data);
            }

            public void SendMsg(string msg)
            {
                Send(msg);
            }
        }

        public ApiServer()
        {
            HttpServer ws = new HttpServer(1234);
            ws.AddWebSocketService<Test>("/Test");
            ws.Start();
        }

        static void TestFunc(Test bav, string msg)
        {
            bav.SendMsg("asd 123");
        }
    }
}