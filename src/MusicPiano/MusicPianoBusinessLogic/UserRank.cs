using MusicPianoData;

namespace MusicPianoBusinessLogic;

/// <summary>
/// For every three lessons, the user receives one star
/// </summary>
public class UserRank
{
    public UserRankEnum DetermineRankForUser(UserLesson[] lessons)
    {
        int completedLessons = 0;
        /*for (int i = 0; i < lessons.Length; i++)
        {
            if (lessons[i].IsCompleted)
            {
                completedLessons++;
            }
        }*/

        completedLessons = lessons.Count(it=>it.IsCompleted);
        //completedLessons = lessons.Where(a=>a.IsCompleted).Count();


        if (completedLessons > 8)
        {
            return UserRankEnum.ADVANCED;
        }
        else if (completedLessons > 5)
        {
            return UserRankEnum.INTERMEDIATE;
        }
        else if (completedLessons > 2)
        {
            return UserRankEnum.BEGINNER;
        }
        else if (completedLessons >= 0)
        {
            return UserRankEnum.STARTER;
        }
        return UserRankEnum.NONE;
    }
}
