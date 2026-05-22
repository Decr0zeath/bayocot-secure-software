namespace bayocot_secure_software
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.btnComputeKeys.Click += BtnComputeKeys_Click;
            this.btnEncryptSend.Click += BtnEncryptSend_Click;
            this.btnReset.Click += BtnReset_Click;
        }

        private void BtnComputeKeys_Click(object sender, EventArgs e)
        {
            // TODO: Diffie-Hellman (Commit 2)
        }

        private void BtnEncryptSend_Click(object sender, EventArgs e)
        {
            // TODO: chunk, pad, encrypt, decrypt (Commits 4-6)
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtPrivA.Clear();
            txtPubA.Clear();
            txtPrivB.Clear();
            txtPubB.Clear();
            txtMessage.Clear();
            txtSharedKey.Clear();
            txtAesKey.Clear();
            txtSubMessages.Clear();
            txtEncrypted.Clear();
            txtDecrypted.Clear();
        }
    }
}
