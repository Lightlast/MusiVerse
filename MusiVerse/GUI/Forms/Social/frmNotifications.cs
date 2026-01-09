using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmNotifications : Form
    {
        private Panel _pnlNotifications;
        private int _currentUserID;

        public frmNotifications()
        {
            InitializeComponent();
            SetupUI();
            LoadNotifications();
        }

        private void SetupUI()
        {
            this.Text = "?? Thông báo";
            this.Size = new Size(700, 600);
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
                Text = "?? Thông báo",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 140, 0),
                Location = new Point(20, 15),
                AutoSize = true
            };

            Button btnClearAll = new Button
            {
                Text = "Xóa t?t c?",
                Location = new Point(580, 15),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClearAll.FlatAppearance.BorderSize = 0;
            btnClearAll.Click += (s, e) => ClearAllNotifications();

            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClearAll);

            // Notifications panel
            _pnlNotifications = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                AutoScroll = true,
                Padding = new Padding(0)
            };

            this.Controls.Add(_pnlNotifications);
            this.Controls.Add(pnlHeader);
        }

        private void LoadNotifications()
        {
            try
            {
                _pnlNotifications.Controls.Clear();

                // TODO: Load actual notifications from database
                // For now, show sample notifications

                List<(string type, string message, DateTime date)> notifications = new List<(string, string, DateTime)>
                {
                    ("like", "Nguy?n V?n A ?ã thích bài vi?t c?a b?n", DateTime.Now.AddHours(-2)),
                    ("comment", "Tr?n Th? B bình lu?n: 'Bài vi?t hay quá!'", DateTime.Now.AddHours(-5)),
                    ("follow", "Lê Minh C b?t ??u theo dõi b?n", DateTime.Now.AddHours(-1)),
                    ("share", "Ph?m V?n D ?ã chia s? bài vi?t c?a b?n", DateTime.Now.AddDays(-1)),
                    ("like", "Hoàng Th? E ?ã thích bài vi?t c?a b?n", DateTime.Now.AddDays(-2))
                };

                if (notifications.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "B?n không có thông báo nào",
                        Font = new Font("Segoe UI", 14),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(200, 200)
                    };
                    _pnlNotifications.Controls.Add(lblEmpty);
                    return;
                }

                int yPos = 10;
                foreach (var notif in notifications)
                {
                    Panel notifCard = CreateNotificationCard(notif.type, notif.message, notif.date);
                    notifCard.Location = new Point(15, yPos);
                    _pnlNotifications.Controls.Add(notifCard);
                    yPos += notifCard.Height + 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i");
            }
        }

        private Panel CreateNotificationCard(string type, string message, DateTime date)
        {
            Panel card = new Panel
            {
                Size = new Size(650, 70),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            // Icon based on type
            string icon;
            if (type == "like")
                icon = "??";
            else if (type == "comment")
                icon = "??";
            else if (type == "follow")
                icon = "??";
            else if (type == "share")
                icon = "??";
            else
                icon = "??";

            Label lblIcon = new Label
            {
                Text = icon,
                Location = new Point(15, 15),
                Font = new Font("Arial", 20),
                AutoSize = true
            };

            Label lblMessage = new Label
            {
                Text = message,
                Location = new Point(70, 10),
                Size = new Size(540, 35),
                Font = new Font("Segoe UI", 10),
                AutoSize = false
            };

            Label lblDate = new Label
            {
                Text = GetTimeAgo(date),
                Location = new Point(70, 45),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            Button btnDismiss = new Button
            {
                Text = "?",
                Location = new Point(610, 20),
                Size = new Size(30, 30),
                BackColor = Color.White,
                ForeColor = Color.Gray,
                Font = new Font("Arial", 12),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnDismiss.FlatAppearance.BorderSize = 0;
            btnDismiss.Click += (s, e) => _pnlNotifications.Controls.Remove(card);

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblMessage);
            card.Controls.Add(lblDate);
            card.Controls.Add(btnDismiss);

            return card;
        }

        private void ClearAllNotifications()
        {
            var confirm = MessageBox.Show(
                "B?n có ch?c mu?n xóa t?t c? thông báo?",
                "Xác nh?n",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                _pnlNotifications.Controls.Clear();
                Label lblEmpty = new Label
                {
                    Text = "Không có thông báo nào",
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(250, 200)
                };
                _pnlNotifications.Controls.Add(lblEmpty);
            }
        }

        private string GetTimeAgo(DateTime date)
        {
            TimeSpan timeSpan = DateTime.Now - date;

            if (timeSpan.TotalSeconds < 60)
                return "v?a xong";
            else if (timeSpan.TotalMinutes < 60)
                return $"{(int)timeSpan.TotalMinutes} phút tr??c";
            else if (timeSpan.TotalHours < 24)
                return $"{(int)timeSpan.TotalHours} gi? tr??c";
            else if (timeSpan.TotalDays < 7)
                return $"{(int)timeSpan.TotalDays} ngày tr??c";
            else
                return date.ToString("dd/MM/yyyy");
        }
    }
}
