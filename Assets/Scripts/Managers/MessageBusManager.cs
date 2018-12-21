using NATS.Client;
using NATSTesting.Core;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace NATSTesting.Managers
{
    public class MessageBusManager : MonoBehaviourSingleton<MessageBusManager>
    {
        public Text messages;
        public string defaultNATSUrl = "nats://demo.nats.io:4222";
        private ConnectionFactory connectionFactory;
        private Options connectionOptions;
        private IConnection connection;

        void Awake()
        {
            SetupMessageBus();
        }

        private void Initialize()
        {
            connectionFactory = new ConnectionFactory();
            connectionOptions = ConnectionFactory.GetDefaultOptions();
            connectionOptions.Url = defaultNATSUrl;
            connectionOptions.Secure = false;
        }

        private bool OpenConnection()
        {
            Initialize();

            try
            {
                connection = connectionFactory.CreateConnection(connectionOptions);
            }
            catch (Exception e)
            {
                messages.text = e.ToString();
                return false;
            }
            return true;
        }

        private void CloseConnection()
        {
            if (connection != null) {
                connection.Close();
            }
        }

        private void SetupMessageBus()
        {
            if (OpenConnection())
            {
                // Setup an event handler to process incoming messages.
                // An anonymous delegate function is used for brevity.
                EventHandler<MsgHandlerEventArgs> messageHandler = (sender, args) =>
                {
                    Debug.Log(args.Message);
                    messages.text = $"Subject: {args.Message.Subject} | PayLoad: {Encoding.UTF8.GetString(args.Message.Data)}";
                };

                IAsyncSubscription subscriber = connection.SubscribeAsync("PinBallGroup", messageHandler);
                connection.Publish("PinBallGroup", Encoding.UTF8.GetBytes("Let us bring pinball back"));
            }
        }
        
        void OnApplicationQuit()
        {
            CloseConnection();
        }
    }

}