namespace MusicPianoForms
{
    partial class LessonRow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picture = new PictureBox();
            label = new Label();
            button = new Button();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Location = new Point(3, 5);
            picture.Margin = new Padding(0);
            picture.Name = "picture";
            picture.Size = new Size(30, 30);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(39, 10);
            label.Name = "label";
            label.Size = new Size(94, 20);
            label.TabIndex = 1;
            label.Text = "Lesson name";
            // 
            // button
            // 
            button.Location = new Point(395, 6);
            button.Name = "button";
            button.Size = new Size(94, 29);
            button.TabIndex = 2;
            button.Text = "Start lesson";
            button.UseVisualStyleBackColor = true;
            // 
            // LessonRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button);
            Controls.Add(label);
            Controls.Add(picture);
            Margin = new Padding(0);
            Name = "LessonRow";
            Size = new Size(500, 40);
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picture;
        private Label label;
        private Button button;
    }
}
