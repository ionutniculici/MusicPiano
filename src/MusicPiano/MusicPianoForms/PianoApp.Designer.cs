namespace MusicPianoForms
{
    partial class PianoApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usernameLabel = new Label();
            usernameText = new TextBox();
            passwordLabel = new Label();
            passwordText = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(86, 38);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(75, 20);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "User";
            // 
            // usernameText
            // 
            usernameText.Location = new Point(86, 76);
            usernameText.Name = "usernameText";
            usernameText.Size = new Size(125, 27);
            usernameText.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(86, 120);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 20);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password";
            // 
            // passwordText
            // 
            passwordText.Location = new Point(86, 158);
            passwordText.Name = "passwordText";
            passwordText.Size = new Size(125, 27);
            passwordText.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(86, 220);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 29);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // PianoApp Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(usernameLabel);
            Controls.Add(usernameText);
            Controls.Add(passwordLabel);
            Controls.Add(passwordText);
            Controls.Add(loginButton);
            Name = "PianoApp";
            Text = "PianoApp";
            ResumeLayout(false);
            PerformLayout();
        }

        private void ChangeLayout()
        {
            noteLabel = new Label();
            noteText = new TextBox();
            playNoteButton = new Button();
            SuspendLayout();
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new Point(86, 38);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new Size(135, 20);
            noteLabel.TabIndex = 0;
            noteLabel.Text = "Please enter a note";
            // 
            // noteText
            // 
            noteText.Location = new Point(86, 76);
            noteText.Name = "noteText";
            noteText.Size = new Size(125, 27);
            noteText.TabIndex = 1;
            // 
            // playNoteButton
            // 
            playNoteButton.Location = new Point(87, 126);
            playNoteButton.Name = "playNoteButton";
            playNoteButton.Size = new Size(94, 29);
            playNoteButton.TabIndex = 2;
            playNoteButton.Text = "Play Note";
            playNoteButton.UseVisualStyleBackColor = true;
            playNoteButton.Click += playNoteButton_Click;
            // 
            // PianoApp Form
            // 
            Controls.Clear();
            Controls.Add(playNoteButton);
            Controls.Add(noteText);
            Controls.Add(noteLabel);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label usernameLabel;
        private TextBox usernameText;
        private Label passwordLabel;
        private TextBox passwordText;
        private Button loginButton;

        private Label noteLabel;
        private TextBox noteText;
        private Button playNoteButton;
    }
}
