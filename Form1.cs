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
            try
            {
                if (!int.TryParse(txtPrivA.Text, out int privA) || privA < 1 || privA > 255 ||
                    !int.TryParse(txtPrivB.Text, out int privB) || privB < 1 || privB > 255)
                {
                    MessageBox.Show("Private keys must be integers between 1 and 255.",
                        "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int pubA = DiffieHellman.ComputePublicValue(privA);
                int pubB = DiffieHellman.ComputePublicValue(privB);
                int sharedA = DiffieHellman.ComputeSharedKey(pubB, privA);
                int sharedB = DiffieHellman.ComputeSharedKey(pubA, privB);

                txtPubA.Text = pubA.ToString();
                txtPubB.Text = pubB.ToString();
                txtSharedKey.Text =
                    $"A: {pubB}^{privA} mod {DiffieHellman.P} = {sharedA}   |   " +
                    $"B: {pubA}^{privB} mod {DiffieHellman.P} = {sharedB}" +
                    (sharedA == sharedB ? "   ✓ match" : "   ✗ MISMATCH");

                _aesKey = KeyTransformer.ToAesKey(sharedA);
                txtAesKey.Text = KeyTransformer.ToDisplayString(_aesKey) +
                                 "   (hex: " + BitConverter.ToString(_aesKey).Replace("-", " ") + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Key computation failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEncryptSend_Click(object sender, EventArgs e)
        {
            try
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
                {
                    byte[] raw = System.Text.Encoding.ASCII.GetBytes(blocks[i]);
                    string hex = BitConverter.ToString(raw).Replace("-", " ");
                    sb.AppendLine($"[{i + 1}] \"{blocks[i]}\"  ->  {hex}");
                }
                txtSubMessages.Text = sb.ToString();

                _lastCipher = AesEncryption.EncryptMessage(blocks, _aesKey);
                txtEncrypted.Text = AesEncryption.ToHex(_lastCipher);

                // Receiver re-derives shared key independently
                int privB = int.Parse(txtPrivB.Text);
                int pubA = int.Parse(txtPubA.Text);
                int sharedAtB = DiffieHellman.ComputeSharedKey(pubA, privB);
                byte[] keyAtB = KeyTransformer.ToAesKey(sharedAtB);

                string decrypted = AesEncryption.DecryptMessage(_lastCipher, keyAtB);
                txtDecrypted.Text = MessageProcessor.Unpad(decrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encryption/decryption failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
