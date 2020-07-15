namespace FlashCard
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using DataAccess;

    using Telerik.WinControls.UI;

    /// <summary>
    /// The QA.
    /// </summary>
    public partial class QA : RadForm
    {
        private readonly QuestionHelper questionHelper = new QuestionHelper();

        #region Ctor/Init

        private static List<T> QuestionShuffle<T>(IEnumerable<T> original)
        {
            Random random = new Random();

            return original.OrderBy(x => random.NextDouble()).ToList();
        }

        public QA(List<DomainDto> domains)
        {
            this.InitializeComponent();
            this.InitializeAfterComponent(domains);
        }

        private void InitializeAfterComponent(List<DomainDto> domains)
        {
            // Get Question list from DB and randomize values
            this.questionHelper.questions = QuestionShuffle(GetDB.GetQuestion(domains));
            this.questionHelper.wrongQuestions = QuestionShuffle(GetDB.GetAllWrongQuestions());

            // Randomize Answers
            this.questionHelper.questions.ForEach(question => question.Answers = QuestionShuffle(question.Answers));
            this.questionHelper.wrongQuestions.ForEach(
                question => question.Answers = QuestionShuffle(question.Answers));

            // Drag and drop
            new RadItemDragDropManager(
                this.answerCorrectList,
                this.answerCorrectList.Items,
                this.answerAreaListControl,
                this.answerAreaListControl.Items);

            this.answerAreaListControl.Items.AddRange(this.questionHelper.NextNormal());

            this.SetFormLabels();
        }

        private void SetFormLabels()
        {
            if (this.SuicideSwitch.Value)
            {
                this.questionOfAllLbl.Text = this.questionHelper.wrongQuestions.Count.ToString();
                this.questionCurrentLbl.Text = this.questionHelper.CurrentSuinceIndex.ToString();
                this.questionTextLbl.Text = this.questionHelper.currentWrongQuestion.Question;
            }
            else
            {
                this.questionOfAllLbl.Text = this.questionHelper.questions.Count.ToString();
                this.questionCurrentLbl.Text = this.questionHelper.CurrentIndex.ToString();
                this.questionTextLbl.Text = this.questionHelper.currentQuestion.Question.Replace("\n", string.Empty);
            }
        }

        #endregion

        private void SuinceModeFormColors()
        {
            if (this.SuicideSwitch.Value)
            {
                this.BackColor = Color.LightSlateGray;
                this.questionTextLbl.ForeColor = Color.White;
                this.suicideLbl.ForeColor = Color.White;
                this.radLabel8.ForeColor = Color.White;
                this.questionCurrentLbl.ForeColor = Color.White;
                this.radLabel1.ForeColor = Color.White;
                this.questionOfAllLbl.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                this.questionTextLbl.ForeColor = Color.Black;
                this.suicideLbl.ForeColor = Color.Black;
                this.radLabel8.ForeColor = Color.DarkGray;
                this.questionCurrentLbl.ForeColor = Color.DarkGray;
                this.radLabel1.ForeColor = Color.DarkGray;
                this.questionOfAllLbl.ForeColor = Color.DarkGray;
            }
        }

        private void SuicideSwitch_ValueChanged(object sender, EventArgs e)
        {
            this.answerCorrectList.Items.Clear();
            this.answerAreaListControl.Items.Clear();

            if (this.SuicideSwitch.Value)
            {
                // Get Question list from DB and randomize values
                this.questionHelper.wrongQuestions = new List<QuestionDto>();
                this.questionHelper.wrongQuestions = QuestionShuffle(GetDB.GetAllWrongQuestions());

                // Randomize Answers
                this.questionHelper.wrongQuestions.ForEach(
                    question => question.Answers = QuestionShuffle(question.Answers));

                if (this.questionHelper.wrongQuestions.Count > 0)
                {
                    this.questionHelper.CurrentSuinceIndex = 0;
                    this.answerAreaListControl.Items.AddRange(this.questionHelper.NextSuinceMode());
                }
                else
                {
                    this.SuicideSwitch.Value = false;

                    this.answerCorrectList.Items.Clear();
                    this.answerAreaListControl.Items.Clear();

                    this.questionHelper.CurrentIndex--;
                    this.answerAreaListControl.Items.AddRange(this.questionHelper.NextNormal());

                    MessageBox.Show(
                        @"There are no incorrect answers to questions.",
                        @"Message",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else
            {
                this.questionHelper.CurrentIndex--;
                this.answerAreaListControl.Items.AddRange(this.questionHelper.NextNormal());
            }

            this.SetFormLabels();
            this.SuinceModeFormColors();
        }

        private void NormalNext()
        {
            if (this.answerCorrectList.Items.Count != this.questionHelper.questions
                    .ElementAt(this.questionHelper.CurrentIndex - 1).Answers.Count)
            {
                MessageBox.Show(
                    @"Wrong: please, daging drop all answers",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            this.questionHelper.LogAnswers(
                this.questionHelper.questions.ElementAt(this.questionHelper.CurrentIndex - 1).Answers,
                this.answerCorrectList,
                "Normal");

            this.answerCorrectList.Items.Clear();
            this.answerAreaListControl.Items.Clear();

            var items = this.questionHelper.NextNormal();

            if (items != null)
            {
                this.answerAreaListControl.Items.AddRange(items);
            }
            else
            {
                this.questionHelper.CurrentIndex++;
                this.ShowRating();
            }
        }

        private void SuicideNext()
        {
            if (this.answerCorrectList.Items.Count != this.questionHelper.wrongQuestions
                    .ElementAt(this.questionHelper.CurrentSuinceIndex - 1).Answers.Count)
            {
                MessageBox.Show(
                    @"Wrong: please, daging drop all answers",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            this.questionHelper.LogAnswers(
                this.questionHelper.wrongQuestions.ElementAt(this.questionHelper.CurrentSuinceIndex - 1).Answers,
                this.answerCorrectList,
                "Suicide");

            this.answerCorrectList.Items.Clear();
            this.answerAreaListControl.Items.Clear();

            var items = this.questionHelper.NextSuinceMode();

            if (items != null)
            {
                this.answerAreaListControl.Items.AddRange(items);
            }
            else
            {
                MessageBox.Show(
                    @"You answered all the incorrectly answered questions",
                    @"Disable suicide mode",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.SuicideSwitch.Value = false;
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            // Suince or normal next
            if (this.SuicideSwitch.Value)
            {
                this.SuicideNext();
            }
            else
            {
                this.NormalNext();
            }

            this.SetFormLabels();
        }

        #region Move To Left/Right & Up/Down

        private void MoveToTargetListBox(RadListControl sourceListBox, RadListControl targetListBox)
        {
            if (sourceListBox.Items.Count == 0)
            {
                return;
            }

            if (sourceListBox.SelectedItem == null)
            {
                return;
            }

            RadListDataItem item = sourceListBox.SelectedItem;
            sourceListBox.Items.Remove(item);
            targetListBox.Items.Add(item);
        }

        private void MoveUp(RadListControl listBox)
        {
            if (listBox.Items.Count < 2)
            {
                return;
            }

            if (listBox.SelectedItem == null)
            {
                return;
            }

            if (listBox.SelectedIndex == 0)
            {
                return;
            }

            RadListDataItem item = listBox.SelectedItem;
            int index = listBox.SelectedIndex;
            listBox.Items.Remove(item);
            listBox.Items.Insert(index - 1, item);
            listBox.SelectedItem = item;
        }

        private void MoveDown(RadListControl listBox)
        {
            if (listBox.Items.Count < 2)
            {
                return;
            }

            if (listBox.SelectedItem == null)
            {
                return;
            }

            if (listBox.SelectedIndex == listBox.Items.Count - 1)
            {
                return;
            }

            RadListDataItem item = listBox.SelectedItem;
            int index = listBox.SelectedIndex;
            listBox.Items.Remove(item);
            listBox.Items.Insert(index + 1, item);
            listBox.SelectedItem = item;
        }

        private void MoveToLeftBtn_Click(object sender, EventArgs e)
        {
            // ResetAnswerItems();
            this.MoveToTargetListBox(this.answerAreaListControl, this.answerCorrectList);
        }

        private void MoveToRightBtn_Click(object sender, EventArgs e)
        {
            // ResetAnswerItems();
            this.MoveToTargetListBox(this.answerCorrectList, this.answerAreaListControl);
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            // ResetAnswerItems();

            // moves up SelectedItem in answerCorrectList  
            this.MoveUp(this.answerCorrectList);
            this.ClassificationAnswers();
        }

        private void DownBtn_Click(object sender, EventArgs e)
        {
            // ResetAnswerItems();

            // moves down SelectedItem in answerCorrectList 
            this.MoveDown(this.answerCorrectList);
            this.ClassificationAnswers();
        }

        private void ClassificationAnswers()
        {
            // classification
            var index = 64;

            foreach (var radListDataItem in this.answerCorrectList.Items)
            {
                radListDataItem.Text = $"({(char)++index}) {radListDataItem.Text.Substring(3)}";
            }
        }

        #endregion

        private void ExitBtn1_Click(object sender, EventArgs e)
        {
            if (this.questionHelper.questions.Count == this.questionHelper.CurrentIndex)
            {
                this.NormalNext();
            }
            else
            {
                this.ShowRating();
            }
        }

        private void ShowRating()
        {
            this.Enabled = false;

            var shadow = new Form
                             {
                                 MinimizeBox = false,
                                 MaximizeBox = false,
                                 ControlBox = false,
                                 Text = string.Empty,
                                 FormBorderStyle = FormBorderStyle.None,
                                 Size = this.Size,
                                 BackColor = Color.Black,
                                 Opacity = 0.3
                             };

            shadow.Show();
            shadow.Location = this.Location;
            shadow.Enabled = false;

            RatingModalForm modal = new RatingModalForm(
                this.questionHelper.WrongAnweredCount,
                this.questionHelper.questions.Count,
                this.questionHelper.CurrentIndex);

            modal.Size = new Size(600, 400);
            modal.StartPosition = FormStartPosition.CenterScreen;

            modal.FormClosing += (se, e) =>
                {
                    shadow.Close();
                    this.Enabled = true;
                };

            modal.Location = new Point(
                shadow.Left + ((shadow.Width - modal.Width) / 2),
                shadow.Top + ((shadow.Height - modal.Height) / 2));

            modal.ShowDialog();

            this.DialogResult = DialogResult.OK;
        }
    }
}