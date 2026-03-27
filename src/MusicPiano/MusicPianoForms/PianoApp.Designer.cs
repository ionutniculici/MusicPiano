using Microsoft.VisualBasic.ApplicationServices;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using MusicPianoResources;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

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
            button1 = new Button();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(86, 38);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(38, 20);
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
            passwordLabel.Size = new Size(70, 20);
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
            // button1
            // 
            button1.Location = new Point(230, 220);
            button1.Name = "button1";
            button1.Size = new Size(176, 39);
            button1.TabIndex = 3;
            button1.Text = "E&xit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ExitButton_Click;
            // 
            // PianoApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
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

        #endregion
        private Label usernameLabel;
        private TextBox usernameText;
        private Label passwordLabel;
        private TextBox passwordText;
        private Button loginButton;

        private Label certificate;
        private FlowLayoutPanel panel;

        private Label lessonName;
        private Label question;
        private TextBox answerText;
        private Button answerButton;
        private Button backButton;
        private Button repeatButton;

        private PictureBox star1;
        private PictureBox star2;
        private PictureBox star3;
        private Button button1;
    }
}
