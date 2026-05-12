using MusicPianoData;
using MusicPianoLogic;
using MusicPianoResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPianoForms
{
    public partial class PracticeLessonForm : Form
    {
        public PracticeLessonForm(PracticeLessson lesson)
        {
            InitializeComponent();
            AskPracticeQuestion(lesson);
        }

        private void AskPracticeQuestion(PracticeLessson lesson)
        {
            lessonName = new Label();
            question = new Label();
            answerText = new TextBox();
            repeatButton = new Button();
            answerButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // lessonName
            // 
            lessonName.AutoSize = true;
            lessonName.Location = new Point(36, 30);
            lessonName.Name = "lessonName";
            lessonName.Size = new Size(131, 20);
            lessonName.TabIndex = 0;
            lessonName.Text = "Lesson 3 - Practice";
            // 
            // question
            // 
            question.AutoSize = true;
            question.Location = new Point(36, 65);
            question.Name = "question";
            question.Size = new Size(169, 20);
            question.TabIndex = 0;
            question.Text = "Input the notes you hear";
            // 
            // answerText
            // 
            answerText.Location = new Point(40, 103);
            answerText.Name = "answerText";
            answerText.Size = new Size(100, 27);
            answerText.TabIndex = 1;
            // 
            // repeatButton
            // 
            repeatButton.Location = new Point(160, 102);
            repeatButton.Name = "repeatButton";
            repeatButton.Size = new Size(29, 29);
            repeatButton.TabIndex = 2;
            repeatButton.BackgroundImage = Image.FromFile(ImageFiles.GetImagePath("repeat.png"));
            repeatButton.BackgroundImageLayout = ImageLayout.Stretch;
            repeatButton.ImageAlign = ContentAlignment.MiddleCenter;
            repeatButton.UseVisualStyleBackColor = true;
            repeatButton.Click += (sender, e) => PlayNote(lesson);
            // 
            // answerButton
            // 
            answerButton.Location = new Point(150, 160);
            answerButton.Name = "answerButton";
            answerButton.Size = new Size(140, 29);
            answerButton.TabIndex = 2;
            answerButton.Text = "Check Answer";
            answerButton.UseVisualStyleBackColor = true;
            answerButton.Click += (sender, e) => CheckPracticeAnswer(lesson, answerText.Text);
            // 
            // backButton
            // 
            backButton.Location = new Point(40, 160);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += (sender, e) => Close();
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
            Controls.Add(repeatButton);
            Controls.Add(answerButton);
            Controls.Add(backButton);
            Name = "PianoApp";
            Text = "PianoApp";
            ResumeLayout(false);
            PerformLayout();
            PlayNote(lesson);
        }

        private void PlayNote(PracticeLessson lesson)
        {
            var note = lesson.AudioFiles[AppState.currentQuestionIndex];
            Note myNote = new Note();
            var result = myNote.ChooseNote(note);
        }

        private void CheckPracticeAnswer(PracticeLessson lesson, string answer)
        {
            if (answer.Contains(lesson.Answers[AppState.currentQuestionIndex]))
            {
                DialogResult result = MessageBox.Show("Correct!", lesson.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (AppState.currentQuestionIndex == AppState.totalQuestions - 1)
                {
                    AppState.repository.MarkLessonAsComplete(AppState.lessonsStatus, AppState.userId, AppState.currentLessonId);
                    Close();
                }
                else
                {
                    AppState.currentQuestionIndex++;
                    AskPracticeQuestion(lesson);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Wrong answer, try again.", lesson.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
