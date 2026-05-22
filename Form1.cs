namespace bayocot_secure_software
{
    public partial class Form1 : Form
    {
        private byte[] _aesKey;
        private byte[] _lastCipher;

        public Form1()
        {
            InitializeComponent();
            this.btnComputeKeys.Click += BtnComputeKeys_Click;
            this.btnEncryptSend.Click += BtnEncryptSend_Click;
            this.btnReset.Click += BtnReset_Click;
            
        }

        private void BtnComputeKeys_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPrivA.Text, out int privA) ||
                !int.TryParse(txtPrivB.Text, out int privB))
            {
                MessageBox.Show("Enter integer private keys for both users.",
                    "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pubA = DiffieHellman.ComputePublicValue(privA);
            int pubB = DiffieHellman.ComputePublicValue(privB);

            int sharedFromA = DiffieHellman.ComputeSharedKey(pubB, privA);
            int sharedFromB = DiffieHellman.ComputeSharedKey(pubA, privB);

            txtPubA.Text = pubA.ToString();
            txtPubB.Text = pubB.ToString();
            txtSharedKey.Text = $"A computes: {pubB}^{privA} mod {DiffieHellman.P} = {sharedFromA}    " +
                                $"B computes: {pubA}^{privB} mod {DiffieHellman.P} = {sharedFromB}";

            // Store the AES key for later use
            _aesKey = KeyTransformer.ToAesKey(sharedFromA);
            txtAesKey.Text = KeyTransformer.ToDisplayString(_aesKey);
        }

        private void BtnEncryptSend_Click(object sender, EventArgs e)
        {
            if (_aesKey == null)
            {
                MessageBox.Show("Compute the keys first.", "No key",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Enter a message to send.", "No message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var blocks = MessageProcessor.Chunk(txtMessage.Text);

            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < blocks.Count; i++)
                sb.AppendLine($"[{i + 1}] \"{blocks[i]}\"");
            txtSubMessages.Text = sb.ToString();

            byte[] cipher = AesEncryption.EncryptMessage(blocks, _aesKey);
            txtEncrypted.Text = AesEncryption.ToHex(cipher);

            // Hold for the receiver side (Commit 6)
            _lastCipher = cipher;

            // === Receiver side ===
            // In a real exchange this would happen on User B's machine using their
            // own copy of the shared key. We re-derive it here just to be explicit.
            int privB = int.Parse(txtPrivB.Text);
            int pubA = int.Parse(txtPubA.Text);
            int sharedAtB = DiffieHellman.ComputeSharedKey(pubA, privB);
            byte[] keyAtB = KeyTransformer.ToAesKey(sharedAtB);

            string decrypted = AesEncryption.DecryptMessage(_lastCipher, keyAtB);
            txtDecrypted.Text = MessageProcessor.Unpad(decrypted);
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
            _aesKey = null;
            _lastCipher = null;
        }
    }
}
