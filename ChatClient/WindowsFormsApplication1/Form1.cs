﻿using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace ChatClient
{
    public partial class frmChatClient : Form
    {
        TcpClient MessagesSocket = new TcpClient();
        NetworkStream MessagesStream = default(NetworkStream);
        string returnedMessageData = null;
        string returnedUserData = null;
        string oneUsersData = null;
        string broadCastList = null;
        int length;
        int lengthOfPacketCode = 3;

        public frmChatClient()
        {
            InitializeComponent();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string broadCastList;
            broadCastList = GetBroadcastList();
            byte[] outStream = Encoding.ASCII.GetBytes(txtSendMessage.Text + "m$m" + broadCastList + "b$c");
            MessagesStream.Write(outStream, 0, outStream.Length);
            MessagesStream.Flush();
            txtSendMessage.Clear();
        }
        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            LoopConnect();
        }

        private void getMessage()
        {
            string unEditedDataFromServer = null;
            string messageData = null;
            int length;
            while (MessagesSocket.Connected)
            {
                MessagesStream = MessagesSocket.GetStream();
                byte[] inStream = new byte[65536];
                MessagesStream.Read(inStream, 0, inStream.Length);
                unEditedDataFromServer = Encoding.ASCII.GetString(inStream);

                if (unEditedDataFromServer.IndexOf("m$m") < 0)
                {
                    returnedMessageData = unEditedDataFromServer;
                }
                else
                {
                    messageData = unEditedDataFromServer.Substring(0, unEditedDataFromServer.IndexOf("m$m"));
                    returnedMessageData = "" + messageData;
                }
                if (unEditedDataFromServer.IndexOf("u$u") >= 0)
                {
                    length = unEditedDataFromServer.IndexOf("u$u");
                    length = length - unEditedDataFromServer.IndexOf("m$m");
                    returnedUserData = unEditedDataFromServer.Substring(unEditedDataFromServer.IndexOf("m$m") + lengthOfPacketCode, length - lengthOfPacketCode);
                }
                UpdateGUI();
            }
        }

        private void UpdateGUI()
        {
            object key = new object();
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(UpdateGUI));
            else if (this.InvokeRequired != true && returnedUserData == null)
                txtChatWindow.Text = txtChatWindow.Text + Environment.NewLine + " >> " + returnedMessageData;
            else
            {
                txtChatWindow.Text = txtChatWindow.Text + Environment.NewLine + " >> " + returnedMessageData;
                lock (key)
                {
                    UpdateUserList();
                }
            }
        }

        private void LoopConnect()
        {
            int attempts = 0;

            while (!MessagesSocket.Connected)
            {
                try
                {
                    attempts++;
                    MessagesSocket.Connect("10.2.20.25", 12000);
                }
                catch (SocketException)
                {
                    txtChatWindow.Clear();
                    txtChatWindow.AppendText("Connection attempts: " + attempts.ToString());
                }
            }
            txtChatWindow.Clear();
            returnedMessageData = "Conected to Chat Server ...";
            UpdateGUI();
            MessagesStream = MessagesSocket.GetStream();
            btnConnectToServer.Visible = false;
            txtUserName.Visible = false;
            lblSetUserName.Visible = false;
            lblConnectedUsers.Visible = true;
            btnSendMessage.Visible = true;
            txtSendMessage.Visible = true;
            byte[] outStreamMessage = Encoding.ASCII.GetBytes(txtUserName.Text + "m$m");
            MessagesStream.Write(outStreamMessage, 0, outStreamMessage.Length);
            MessagesStream.Flush();
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }

        private void UpdateUserList()
        {

                List<string> connectedUsers = new List<string>();
                bool inList = false;

                while (returnedUserData.IndexOf("/u/") > 0)
                {
                    length = returnedUserData.Length;
                    length = length - returnedUserData.IndexOf("/u/");
                    oneUsersData = returnedUserData.Substring(0, returnedUserData.IndexOf("/u/"));
                    connectedUsers.Add(oneUsersData);
                    returnedUserData = returnedUserData.Substring(returnedUserData.IndexOf("/u/") + lengthOfPacketCode, (returnedUserData.Length - (returnedUserData.IndexOf("/u/") + lengthOfPacketCode)));
                }

                for (int i = 0; i < connectedUsers.Count; i++)
                {
                    foreach (string item in chkListConnectedUsers.Items)
                    {
                        if (connectedUsers[i] == item)
                        {
                            inList = true;
                        }
                    }

                    if (inList == false)
                    {
                        chkListConnectedUsers.Items.Add(connectedUsers[i]);
                        inList = false;
                        for (int a = 0; a < chkListConnectedUsers.Items.Count; a++)
                            if (chkListConnectedUsers.Items[a].Equals(connectedUsers[i]))
                            {
                                chkListConnectedUsers.SetItemChecked(a, true);
                            }
                    }
                }
            
        }
        public string GetBroadcastList()
        {
            broadCastList = "";
            foreach (string item in chkListConnectedUsers.CheckedItems)
            {
                broadCastList = broadCastList + item + "b/c";
            }
            return broadCastList;
        }
    }
}

