using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmDirectMessages : Form
    {
        private Panel _pnlConversations;
        private Panel _pnlMessages;
        private int _currentUserID;

        public frmDirectMessages()
        {
            InitializeComponent();
            SetupUI();
            LoadConversations();
        }

        private void SetupUI()
        {
            this.Text = "💬 Tin nhắn trực tiếp";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Header
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(20)
            };

            Label lblTitle = new Label
            {
                Text = "💬 Tin nhắn trực tiếp",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 150, 136),
                Location = new Point(20, 15),
                AutoSize = true
            };

            pnlHeader.Controls.Add(lblTitle);

            // Main content panel with two columns
            Panel pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245)
            };

            // Left panel - Conversations list
            _pnlConversations = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(280, 600),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                Dock = DockStyle.Left
            };

            // Right panel - Messages
            _pnlMessages = new Panel
            {
                Location = new Point(280, 0),
                Size = new Size(700, 600),
                BackColor = Color.FromArgb(245, 245, 245),
                Dock = DockStyle.Fill
            };

            // Message input panel
            Panel pnlInput = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            TextBox txtMessage = new TextBox
            {
                Name = "txtMessage",
                Location = new Point(15, 15),
                Size = new Size(550, 50),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button btnSend = new Button
            {
                Text = "📤 Gửi",
                Location = new Point(575, 15),
                Size = new Size(100, 50),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.Click += (s, e) => SendMessage(txtMessage);

            pnlInput.Controls.Add(txtMessage);
            pnlInput.Controls.Add(btnSend);

            _pnlMessages.Controls.Add(pnlInput);

            pnlContent.Controls.Add(_pnlMessages);
            pnlContent.Controls.Add(_pnlConversations);

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlHeader);
        }

        private void LoadConversations()
        {
            _pnlConversations.Controls.Clear();

            // TODO: Load actual conversations from database
            // For now, add sample conversations

            for (int i = 1; i <= 5; i++)
            {
                Panel convCard = new Panel
                {
                    Size = new Size(260, 70),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(0, 0, 0, 5),
                    Cursor = Cursors.Hand
                };

                Label lblName = new Label
                {
                    Text = $"Người dùng {i}",
                    Location = new Point(15, 10),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = true
                };

                Label lblPreview = new Label
                {
                    Text = "Tin nhắn gần nhất...",
                    Location = new Point(15, 35),
                    Size = new Size(230, 25),
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.Gray,
                    AutoSize = false
                };

                convCard.Controls.Add(lblName);
                convCard.Controls.Add(lblPreview);
                convCard.Click += (s, e) => SelectConversation(i);

                _pnlConversations.Controls.Add(convCard);
            }
        }

        private void SelectConversation(int conversationID)
        {
            LoadMessages(conversationID);
        }

        private void LoadMessages(int conversationID)
        {
            // Clear existing controls except footer
            while (_pnlMessages.Controls.Count > 1)
            {
                _pnlMessages.Controls.RemoveAt(0);
            }

            Panel pnlMessagesContent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(15)
            };

            int yPos = 10;

            // Sample messages
            for (int i = 1; i <= 5; i++)
            {
                Panel msgCard = new Panel
                {
                    Size = new Size(600, 50),
                    Location = new Point(0, yPos),
                    BackColor = i % 2 == 0 ? Color.FromArgb(200, 230, 255) : Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label lblMessage = new Label
                {
                    Text = $"Tin nhắn {i}: Xin chào bạn!",
                    Location = new Point(15, 15),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true
                };

                msgCard.Controls.Add(lblMessage);
                pnlMessagesContent.Controls.Add(msgCard);
                yPos += 60;
            }

            _pnlMessages.Controls.Add(pnlMessagesContent);
        }

        private void SendMessage(TextBox txtMessage)
        {
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn", "Thông báo");
                return;
            }

            // TODO: Save message to database
            MessageBox.Show("Tin nhắn được gửi!", "Thành công");
            txtMessage.Clear();
        }
    }
}
