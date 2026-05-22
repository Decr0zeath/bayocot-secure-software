namespace bayocot_secure_software
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // User A
        private System.Windows.Forms.GroupBox grpUserA;
        private System.Windows.Forms.Label lblPrivA;
        private System.Windows.Forms.TextBox txtPrivA;
        private System.Windows.Forms.Label lblPubA;
        private System.Windows.Forms.TextBox txtPubA;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;

        // User B
        private System.Windows.Forms.GroupBox grpUserB;
        private System.Windows.Forms.Label lblPrivB;
        private System.Windows.Forms.TextBox txtPrivB;
        private System.Windows.Forms.Label lblPubB;
        private System.Windows.Forms.TextBox txtPubB;
        private System.Windows.Forms.Label lblDecrypted;
        private System.Windows.Forms.TextBox txtDecrypted;

        // Shared
        private System.Windows.Forms.GroupBox grpShared;
        private System.Windows.Forms.Label lblSharedKey;
        private System.Windows.Forms.TextBox txtSharedKey;
        private System.Windows.Forms.Label lblAesKey;
        private System.Windows.Forms.TextBox txtAesKey;
        private System.Windows.Forms.Label lblSubMessages;
        private System.Windows.Forms.TextBox txtSubMessages;
        private System.Windows.Forms.Label lblEncrypted;
        private System.Windows.Forms.TextBox txtEncrypted;

        // Buttons
        private System.Windows.Forms.Button btnComputeKeys;
        private System.Windows.Forms.Button btnEncryptSend;
        private System.Windows.Forms.Button btnReset;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpUserA = new System.Windows.Forms.GroupBox();
            this.lblPrivA = new System.Windows.Forms.Label();
            this.txtPrivA = new System.Windows.Forms.TextBox();
            this.lblPubA = new System.Windows.Forms.Label();
            this.txtPubA = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();

            this.grpUserB = new System.Windows.Forms.GroupBox();
            this.lblPrivB = new System.Windows.Forms.Label();
            this.txtPrivB = new System.Windows.Forms.TextBox();
            this.lblPubB = new System.Windows.Forms.Label();
            this.txtPubB = new System.Windows.Forms.TextBox();
            this.lblDecrypted = new System.Windows.Forms.Label();
            this.txtDecrypted = new System.Windows.Forms.TextBox();

            this.grpShared = new System.Windows.Forms.GroupBox();
            this.lblSharedKey = new System.Windows.Forms.Label();
            this.txtSharedKey = new System.Windows.Forms.TextBox();
            this.lblAesKey = new System.Windows.Forms.Label();
            this.txtAesKey = new System.Windows.Forms.TextBox();
            this.lblSubMessages = new System.Windows.Forms.Label();
            this.txtSubMessages = new System.Windows.Forms.TextBox();
            this.lblEncrypted = new System.Windows.Forms.Label();
            this.txtEncrypted = new System.Windows.Forms.TextBox();

            this.btnComputeKeys = new System.Windows.Forms.Button();
            this.btnEncryptSend = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // === User A group ===
            this.grpUserA.Text = "User A (Sender)";
            this.grpUserA.Location = new System.Drawing.Point(12, 12);
            this.grpUserA.Size = new System.Drawing.Size(360, 280);

            this.lblPrivA.Text = "Private Key (ASCII decimal):";
            this.lblPrivA.Location = new System.Drawing.Point(15, 30);
            this.lblPrivA.AutoSize = true;

            this.txtPrivA.Location = new System.Drawing.Point(15, 50);
            this.txtPrivA.Size = new System.Drawing.Size(330, 22);

            this.lblPubA.Text = "Public Value:";
            this.lblPubA.Location = new System.Drawing.Point(15, 80);
            this.lblPubA.AutoSize = true;

            this.txtPubA.Location = new System.Drawing.Point(15, 100);
            this.txtPubA.Size = new System.Drawing.Size(330, 22);
            this.txtPubA.ReadOnly = true;

            this.lblMessage.Text = "Message to send:";
            this.lblMessage.Location = new System.Drawing.Point(15, 130);
            this.lblMessage.AutoSize = true;

            this.txtMessage.Location = new System.Drawing.Point(15, 150);
            this.txtMessage.Size = new System.Drawing.Size(330, 110);
            this.txtMessage.Multiline = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.grpUserA.Controls.Add(this.lblPrivA);
            this.grpUserA.Controls.Add(this.txtPrivA);
            this.grpUserA.Controls.Add(this.lblPubA);
            this.grpUserA.Controls.Add(this.txtPubA);
            this.grpUserA.Controls.Add(this.lblMessage);
            this.grpUserA.Controls.Add(this.txtMessage);

            // === User B group ===
            this.grpUserB.Text = "User B (Receiver)";
            this.grpUserB.Location = new System.Drawing.Point(390, 12);
            this.grpUserB.Size = new System.Drawing.Size(360, 280);

            this.lblPrivB.Text = "Private Key (ASCII decimal):";
            this.lblPrivB.Location = new System.Drawing.Point(15, 30);
            this.lblPrivB.AutoSize = true;

            this.txtPrivB.Location = new System.Drawing.Point(15, 50);
            this.txtPrivB.Size = new System.Drawing.Size(330, 22);

            this.lblPubB.Text = "Public Value:";
            this.lblPubB.Location = new System.Drawing.Point(15, 80);
            this.lblPubB.AutoSize = true;

            this.txtPubB.Location = new System.Drawing.Point(15, 100);
            this.txtPubB.Size = new System.Drawing.Size(330, 22);
            this.txtPubB.ReadOnly = true;

            this.lblDecrypted.Text = "Decrypted Message:";
            this.lblDecrypted.Location = new System.Drawing.Point(15, 130);
            this.lblDecrypted.AutoSize = true;

            this.txtDecrypted.Location = new System.Drawing.Point(15, 150);
            this.txtDecrypted.Size = new System.Drawing.Size(330, 110);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.ReadOnly = true;
            this.txtDecrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.grpUserB.Controls.Add(this.lblPrivB);
            this.grpUserB.Controls.Add(this.txtPrivB);
            this.grpUserB.Controls.Add(this.lblPubB);
            this.grpUserB.Controls.Add(this.txtPubB);
            this.grpUserB.Controls.Add(this.lblDecrypted);
            this.grpUserB.Controls.Add(this.txtDecrypted);

            // === Shared group ===
            this.grpShared.Text = "Shared Data & Process";
            this.grpShared.Location = new System.Drawing.Point(12, 340);
            this.grpShared.Size = new System.Drawing.Size(738, 290);

            this.lblSharedKey.Text = "Shared Key:";
            this.lblSharedKey.Location = new System.Drawing.Point(15, 25);
            this.lblSharedKey.AutoSize = true;

            this.txtSharedKey.Location = new System.Drawing.Point(140, 22);
            this.txtSharedKey.Size = new System.Drawing.Size(580, 22);
            this.txtSharedKey.ReadOnly = true;

            this.lblAesKey.Text = "AES-128 Key:";
            this.lblAesKey.Location = new System.Drawing.Point(15, 55);
            this.lblAesKey.AutoSize = true;

            this.txtAesKey.Location = new System.Drawing.Point(140, 52);
            this.txtAesKey.Size = new System.Drawing.Size(580, 22);
            this.txtAesKey.ReadOnly = true;
            this.txtAesKey.Font = new System.Drawing.Font("Consolas", 9F);

            this.lblSubMessages.Text = "Sub-messages:";
            this.lblSubMessages.Location = new System.Drawing.Point(15, 85);
            this.lblSubMessages.AutoSize = true;

            this.txtSubMessages.Location = new System.Drawing.Point(15, 105);
            this.txtSubMessages.Size = new System.Drawing.Size(705, 80);
            this.txtSubMessages.Multiline = true;
            this.txtSubMessages.ReadOnly = true;
            this.txtSubMessages.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtSubMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.lblEncrypted.Text = "Encrypted (hex):";
            this.lblEncrypted.Location = new System.Drawing.Point(15, 195);
            this.lblEncrypted.AutoSize = true;

            this.txtEncrypted.Location = new System.Drawing.Point(15, 215);
            this.txtEncrypted.Size = new System.Drawing.Size(705, 60);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.ReadOnly = true;
            this.txtEncrypted.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.grpShared.Controls.Add(this.lblSharedKey);
            this.grpShared.Controls.Add(this.txtSharedKey);
            this.grpShared.Controls.Add(this.lblAesKey);
            this.grpShared.Controls.Add(this.txtAesKey);
            this.grpShared.Controls.Add(this.lblSubMessages);
            this.grpShared.Controls.Add(this.txtSubMessages);
            this.grpShared.Controls.Add(this.lblEncrypted);
            this.grpShared.Controls.Add(this.txtEncrypted);

            // === Buttons ===
            this.btnComputeKeys.Text = "Compute Keys";
            this.btnComputeKeys.Location = new System.Drawing.Point(12, 300);
            this.btnComputeKeys.Size = new System.Drawing.Size(140, 32);

            this.btnEncryptSend.Text = "Encrypt && Send";
            this.btnEncryptSend.Location = new System.Drawing.Point(160, 300);
            this.btnEncryptSend.Size = new System.Drawing.Size(140, 32);

            this.btnReset.Text = "Reset";
            this.btnReset.Location = new System.Drawing.Point(610, 300);
            this.btnReset.Size = new System.Drawing.Size(140, 32);

            // === Form ===
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 645);
            this.Controls.Add(this.grpUserA);
            this.Controls.Add(this.grpUserB);
            this.Controls.Add(this.btnComputeKeys);
            this.Controls.Add(this.btnEncryptSend);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.grpShared);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Bayocot — Secure Information Exchange";
            this.ResumeLayout(false);
        }
    }
}
