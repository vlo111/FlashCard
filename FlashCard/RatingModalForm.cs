namespace FlashCard
{
    using System;
    using System.Windows.Forms;

    public partial class RatingModalForm : Telerik.WinControls.UI.RadForm
    {
        public RatingModalForm(int wrong, int count, int currentIndex)
        {
            this.InitializeComponent();

            int normalScore = 0;

            string testMsg;

            int correctlyAmswer = currentIndex - 1;

            if (wrong == 0)
            {
                normalScore = correctlyAmswer * 100 / count;
            }
            else
            {
                normalScore = (count - (wrong + (count - correctlyAmswer))) * 100 / count;
            }

            if (normalScore <= 0)
            {
                testMsg = @"Abysmal";
            }
            else if (normalScore > 0 && normalScore < 10)
            {
                testMsg = @"Awful";
            }
            else if (normalScore >= 10 && normalScore < 20)
            {
                testMsg = @"Bad";
            }
            else if (normalScore >= 20 && normalScore < 30)
            {
                testMsg = @"Poor";
            }
            else if (normalScore >= 30 && normalScore < 40)
            {
                testMsg = @"Mediocre";
            }
            else if (normalScore >= 40 && normalScore < 50)
            {
                testMsg = @"Fair";
            }
            else if (normalScore >= 50 && normalScore < 60)
            {
                testMsg = @"Good";
            }
            else if (normalScore >= 60 && normalScore < 70)
            {
                testMsg = @"Great";
            }
            else if (normalScore >= 70 && normalScore < 80)
            {
                testMsg = @"Excellent";
            }
            else if (normalScore >= 80 && normalScore <= 99)
            {
                testMsg = @"Amazing";
            }
            else
            {
                testMsg = @"Phenomenal";
            }

            this.RatingMessageLbl.Text = testMsg;
            this.radRating1.Value = normalScore;
            this.scoreNormalLbl.Text = this.scoreNormalLbl.Text.Replace("70", normalScore.ToString());
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}