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
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(86, 38);
            usernameLabel.Name = "usernameLabel";
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
            // PianoApp
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

        private void DisplayLessons(List<UserLesson> lessonsStatus, Dictionary<int, UserLesson> lessonsStatusDict)
        {
            certificate = new Label();
            panel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // certificate
            // 
            certificate.AutoSize = true;
            certificate.Location = new Point(7, 10);
            certificate.Name = "certificate";
            certificate.TabIndex = 0;
            int completedLessons = lessonsStatus
                            .Where(ul => ul.IsCompleted)
                            .Count();
            if (completedLessons > 8)
            {
                certificate.Text = "Advanced ***";
            }
            else if (completedLessons > 5)
            {
                certificate.Text = "Intermediate **";
            }
            else if (completedLessons > 2)
            {
                certificate.Text = "Beginner *";
            }
            else
            {
                certificate.Enabled = false;
            }
            //
            // panel
            //
            int rowHeight = 0;
            foreach (var lessonStatus in lessonsStatus)
            {
                LessonRow lessonRow = new LessonRow();
                MusicPianoData.Lesson lesson = lessonStatus.IdLessonNavigation;
                StringBuilder lessonText = new StringBuilder();
                Image image;
                if (lessonsStatusDict[lesson.Id].IsCompleted)
                {
                    image = Image.FromFile(ImageFiles.GetImagePath("completed.png"));
                }
                else if (lessonsStatusDict[lesson.Id].IsUnlocked)
                {
                    image = Image.FromFile(ImageFiles.GetImagePath("unlocked.png"));
                }
                else
                {
                    image = Image.FromFile(ImageFiles.GetImagePath("locked.png"));
                }
                lessonText.Append(lesson.Name);
                lessonText.Append(" - ");
                lessonText.Append(lesson.Description);
                lessonRow.Location = new Point(0, rowHeight);
                lessonRow.Margin = new Padding(0);
                lessonRow.Size = new Size(500, 40);
                string tempString = lessonText.ToString().Replace("&", "&&");
                MusicPianoLogic.Lesson currentLesson = AppState.lessonList.FirstOrDefault(l => l.Title == lesson.Name);
                lessonRow.Setup(tempString, image, !lessonsStatusDict[lesson.Id].IsUnlocked, StartLesson, currentLesson, lesson);
                lessonRow.TabIndex = 0;
                rowHeight += 40;
                panel.Controls.Add(lessonRow);
            }
            panel.Location = new Point(0, 30);
            panel.Margin = new Padding(0);
            panel.Name = "panel";
            panel.Size = new Size(500, 400);
            panel.TabIndex = 1;
            // 
            // PianoApp
            // 
            Controls.Clear();
            Controls.Add(certificate);
            Controls.Add(panel);
            ResumeLayout(false);
            PerformLayout();
        }

        private void StartLesson(MusicPianoLogic.Lesson lesson, MusicPianoData.Lesson lessonDb)
        {
            AppState.currentLessonId = lessonDb.Id;
            if (lessonDb.IsTheoretical)
            {
                StartTheoryLesson((TheoryLesson)lesson);
            }
            else
            {
                StartPracticeLesson((PracticeLessson)lesson);
            }
        }

        private void StartTheoryLesson(TheoryLesson lesson)
        {
            AppState.totalQuestions = lesson.Questions.Count();
            AppState.currentQuestionIndex = 0;
            AskTheoryQuestion(lesson);
        }

        private void AskTheoryQuestion(TheoryLesson lesson)
        {
            lessonName = new Label();
            question = new Label();
            answerText = new TextBox();
            answerButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // lessonName
            // 
            lessonName.AutoSize = true;
            lessonName.Location = new Point(36, 30);
            lessonName.Name = "lessonName";
            lessonName.TabIndex = 0;
            lessonName.Text = lesson.Title + " - " + lesson.Description;
            // 
            // question
            // 
            question.AutoSize = true;
            question.Location = new Point(36, 65);
            question.Name = "question";
            question.TabIndex = 0;
            question.Text = lesson.Questions[AppState.currentQuestionIndex];
            // 
            // answerText
            // 
            answerText.Location = new Point(40, 103);
            answerText.Name = "answerText";
            answerText.Size = new Size(250, 27);
            answerText.TabIndex = 1;
            // 
            // answerButton
            // 
            answerButton.Location = new Point(150, 160);
            answerButton.Name = "answerButton";
            answerButton.Size = new Size(140, 29);
            answerButton.TabIndex = 2;
            answerButton.Text = "Check Answer";
            answerButton.UseVisualStyleBackColor = true;
            answerButton.Click += (sender, e) => CheckTheoryAnswer(lesson, answerText.Text);
            // 
            // backButton
            // 
            backButton.Location = new Point(40, 160);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += (sender, e) => DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
            // 
            // PianoApp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Clear();
            Controls.Add(lessonName);
            Controls.Add(question);
            Controls.Add(answerText);
            Controls.Add(answerButton);
            Controls.Add(backButton);
            Name = "PianoApp";
            Text = "PianoApp";
            ResumeLayout(false);
            PerformLayout();
        }

        private void CheckTheoryAnswer(TheoryLesson lesson, string answer)
        {
            if (answer.Contains(lesson.Answers[AppState.currentQuestionIndex]))
            {
                DialogResult result = MessageBox.Show("Correct!", lesson.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (AppState.currentQuestionIndex == AppState.totalQuestions - 1)
                {
                    AppState.repository.MarkLessonAsComplete(AppState.lessonsStatus, AppState.userId, AppState.currentLessonId);
                    DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
                }
                else
                {
                    AppState.currentQuestionIndex++;
                    AskTheoryQuestion(lesson);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Wrong answer, try again.", lesson.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartPracticeLesson(PracticeLessson lesson)
        {

            SuspendLayout();
            // 
            // certificate
            // 
            certificate.AutoSize = true;
            certificate.Location = new Point(7, 10);
            certificate.Name = "certificate";
            certificate.TabIndex = 0;
            // 
            // PianoApp
            // 
            Controls.Clear();
            Controls.Add(certificate);
            Controls.Add(panel);
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
    }
}
