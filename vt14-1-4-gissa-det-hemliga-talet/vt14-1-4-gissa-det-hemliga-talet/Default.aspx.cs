using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vt14_1_4_gissa_det_hemliga_talet {
    public partial class Default : System.Web.UI.Page {
        private SecretNumber secretNumber {
            get {
                var s = Session["secretNumber"] as SecretNumber;
                if (s != null) {
                    return s;
                } else {
                    secretNumber = new SecretNumber();
                    return secretNumber;
                }
            }
            set {
                Session["secretNumber"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void GuessButton_Click(object sender, EventArgs e) {
            if (IsValid) {
                var guess = int.Parse(Guess.Text);
                var outcome = secretNumber.MakeGuess(guess);

                switch (outcome) {
                    case Outcome.Correct:
                        Guess.Enabled = false;
                        GuessButton.Enabled = false;
                        Result.Text = String.Format("Grattis du klarade det på {0} försök!", secretNumber.Count);
                        Done.Visible = true;
                        break;

                    case Outcome.High:
                        Result.Text = String.Format("För högt.");
                        break;

                    case Outcome.Low:
                        Result.Text = String.Format("För lågt.");
                        break;

                    case Outcome.NoMoreGuesses:
                        Guess.Enabled = false;
                        GuessButton.Enabled = false;
                        Fail.Text = String.Format(Fail.Text, secretNumber.Number);
                        HaveFailed.Visible = true;
                        Done.Visible = true;
                        break;

                    case Outcome.PreviousGuess:
                        Result.Text = String.Format("Du har redan gissat på talet {0}.", guess);
                        break;
                }

                HaveGuessed.Visible = true;
                OldGuesses.Text = String.Join(", ", secretNumber.PreviousGuesses);
            }
        }

        protected void Restart_Click(object sender, EventArgs e) {
            secretNumber.Initialize();
        }
    }
}