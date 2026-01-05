namespace MusicPianoForms;

public partial class LessonRow : UserControl
{
    public LessonRow()
    {
        InitializeComponent();
    }

    public void Setup(string title, Image image, bool isLocked, EventHandler onClick)
    {
        label.Text = title;
        picture.Image = image;
        button.Enabled = !isLocked;
        button.Click += onClick;
    }
}
