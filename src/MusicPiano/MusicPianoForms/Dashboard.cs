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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
        }

        private void DisplayLessons(List<UserLesson> lessonsStatus, Dictionary<int, UserLesson> lessonsStatusDict)
        {
            certificate = new Label();
            star1 = new PictureBox();
            star2 = new PictureBox();
            star3 = new PictureBox();
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
            if (completedLessons < 3)
            {
                certificate.Enabled = false;
            }
            else if (completedLessons < 6)
            {
                certificate.Text = "Beginner";
            }
            else if (completedLessons < 9)
            {
                certificate.Text = "Intermediate";
            }
            else
            {
                certificate.Text = "Advanced";
            }
            if (completedLessons > 2)
            {
                // 
                // star1
                // 
                star1.Location = new Point(105, 10);
                star1.Size = new Size(20, 20);
                star1.Name = "star1";
                star1.TabIndex = 0;
                star1.BackgroundImage = Image.FromFile(ImageFiles.GetImagePath("star.png"));
                star1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (completedLessons > 5)
            {
                // 
                // star2
                // 
                star2.Location = new Point(127, 10);
                star2.Size = new Size(20, 20);
                star2.Name = "star2";
                star2.TabIndex = 0;
                star2.BackgroundImage = Image.FromFile(ImageFiles.GetImagePath("star.png"));
                star2.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (completedLessons > 8)
            {
                certificate.Text = "Advanced";
                // 
                // star3
                // 
                star3.Location = new Point(149, 10);
                star3.Size = new Size(20, 20);
                star3.Name = "star2";
                star3.TabIndex = 0;
                star3.BackgroundImage = Image.FromFile(ImageFiles.GetImagePath("star.png"));
                star3.BackgroundImageLayout = ImageLayout.Stretch;
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
            // TODO: UserRank
            if (completedLessons > 2)
            {
                Controls.Add(star1);
            }
            if (completedLessons > 5)
            {
                Controls.Add(star2);
            }
            if (completedLessons > 8)
            {
                Controls.Add(star3);
            }
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
            TheoryLessonForm theoryLesson = new TheoryLessonForm(lesson);
            Hide();
            theoryLesson.FormClosed += (s, args) =>
            {
                DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
                Show();
            };
            theoryLesson.Show();
        }

        private void StartPracticeLesson(PracticeLessson lesson)
        {
            PracticeLessonForm practiceLesson = new PracticeLessonForm(lesson);
            Hide();
            practiceLesson.FormClosed += (s, args) =>
            {
                DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
                Show();
            };
            practiceLesson.Show();
        }
    }
}
