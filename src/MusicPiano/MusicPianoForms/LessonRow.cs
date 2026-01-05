namespace MusicPianoForms;

public partial class LessonRow : UserControl
{
    public LessonRow()
    {
        InitializeComponent();
    }

    public void Setup(string title, Image image, bool isLocked, Action<MusicPianoLogic.Lesson, MusicPianoData.Lesson> onClick, MusicPianoLogic.Lesson lesson, MusicPianoData.Lesson lessonDb)
    {
        label.Text = title;
        picture.Image = image;
        button.Enabled = !isLocked;
        button.Click += (sender, e) => onClick(lesson, lessonDb);
    }
}
