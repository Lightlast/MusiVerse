using MusiVerse.BLL.Services;
using MusiVerse.DTO.Models;
using System;
using System.Windows.Forms;

namespace MusiVerse.GUI.Forms.Social
{
    public partial class frmEditComment : Form
    {
        private Comment _comment;
        private CommentService _commentService;

        public frmEditComment(Comment comment)
        {
            InitializeComponent();
            _comment = comment;
            _commentService = new CommentService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadCommentData();
        }

        private void LoadCommentData()
        {
            txtContentEdit.Text = _comment.Content;
            txtContentEdit.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string content = txtContentEdit.Text.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("N?i dung bình lu?n không ???c tr?ng", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContentEdit.Focus();
                return;
            }

            try
            {
                _comment.Content = content;
                var result = _commentService.UpdateComment(_comment);

                if (result.Item1)
                {
                    MessageBox.Show(result.Item2, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Item2, "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("L?i: " + ex.Message, "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
