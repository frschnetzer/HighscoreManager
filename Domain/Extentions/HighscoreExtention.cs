using System.Text.RegularExpressions;

namespace Domain.Extentions
{
    public static class HighscoreExtention
    {
        /// <summary>
        /// Validation method to check if every item in the model is correct and valid.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>return the item</returns>
        public static HighscoreModel Validate(this HighscoreModel item)
        {
            CheckUserName(item.Username);
            CheckGamtetitle(item.Gametitle);
            CheckHighscore(item.Highscore);
            CheckDate(item.Date);
            CheckComment(item.Comment);

            return item;
        }

        /// <summary>
        /// Checks username if not null, empty or has a length from 2 to 100 letters and only contains letters.
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Checks if the Gametitle is not null, empty or has a length of 2 to 100 letters.
        /// </summary>
        /// <param name="gametitle"></param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Checks if Highscore is a number.
        /// </summary>
        /// <param name="highscore"></param>
        /// <exception cref="Exception"></exception>
        public static void CheckHighscore(string highscore)
        {
            if (!int.TryParse(highscore, out _))
            {
                throw new Exception("Highscore can not be less than 0");
            }
        }

        /// <summary>
        /// Checks if Date is not in the future.
        /// </summary>
        /// <param name="date"></param>
        /// <exception cref="Exception"></exception>
        public static void CheckDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new Exception("Date can't be in the future");
            }
        }

        /// <summary>
        /// Checks if comment is not null or empty.
        /// </summary>
        /// <param name="comment"></param>
        /// <exception cref="Exception"></exception>
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
