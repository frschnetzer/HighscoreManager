using System.Text.RegularExpressions;

namespace Domain.Extentions
{
    public static class HighscoreExtention
    {
        //TODO: Exceptions anzeigen lassen
        public static HighscoreModel Validate(this HighscoreModel item)
        {
            CheckUserName(item.Username);
            CheckGamtetitle(item.Gametitle);
            CheckHighscore(item.Highscore);
            CheckDate(item.Date);
            CheckComment(item.Comment);

            return item;
        }

        public static void CheckUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new Exception("Username can not be empty");
            }

            if (username.Length < 2 || username.Length > 100)
            {
                throw new Exception("Username must be between 2 and 100 letters");
            }

            Regex re = new("[a-zA-Z]+$");

            if (!re.IsMatch(username))
            {
                throw new Exception("Username must only contain letters");
            }
        }

        public static void CheckGamtetitle(string gametitle)
        {
            if (string.IsNullOrEmpty(gametitle))
            {
                throw new Exception("Gametitle can not be empty");
            }

            if (gametitle.Length < 2 || gametitle.Length > 100)
            {
                throw new Exception("Gametitle must be between 2 and 100 letters");
            }
        }

        public static void CheckHighscore(string highscore)
        {
            if (!int.TryParse(highscore, out _))
            {
                throw new Exception("Highscore can not be less than 0");
            }
        }

        public static void CheckDate(DateTime date)
        {
            if (date <= DateTime.Now)
            {
                throw new Exception("Date can't be in the future");
            }
        }

        public static void CheckComment(string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new Exception("Comment can not be empty");
            }

            if (comment.Length < 2)
            {
                throw new Exception("Comment must be greater 2");
            }

        }
    }
}
