using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vt14_1_4_gissa_det_hemliga_talet {
    public class SecretNumber {
        public const int MaxNumberOfGuesses = 7;

        private int _number;
        private List<int> _previousGuesses;

        /// <summary>
        /// Controlls if a guess can be made or not.
        /// </summary>
        public bool CanMakeGuess {
            get {
                return Outcome != Outcome.NoMoreGuesses && Outcome != Outcome.Correct;
            }
        }

        /// <summary>
        /// Holds the number of guesses.
        /// </summary>
        public int Count {
            get {
                return _previousGuesses.Count;
            }
        }

        /// <summary>
        /// Holds the secret number, returns null if not allowed to read.
        /// </summary>
        public int? Number {
            get {
                if (CanMakeGuess) {
                    return null;
                }
                return _number;
            }
        }

        /// <summary>
        /// Holds the current outcome.
        /// </summary>
        public Outcome Outcome {
            get;
            private set;
        }

        /// <summary>
        /// Holds the guessed numbers, returns a ReadOnlyCollection so it can't be modified.
        /// </summary>
        public IEnumerable<int> PreviousGuesses {
            get {
                return new ReadOnlyCollection<int>(_previousGuesses);
            }
        }

        public SecretNumber() {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }

        /// <summary>
        /// Initializes SecretNumber to a clean state.
        /// </summary>
        public void Initialize() {
            Random random = new Random();
            _number = random.Next(1, 101);

            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        /// <summary>
        /// Make a guess at the secret number and handles all inner game logic.
        /// </summary>
        /// <param name="guess">The number to guess</param>
        /// <returns>The outcome</returns>
        public Outcome MakeGuess(int guess) {
            if (guess > 100 || guess < 1) {
                throw new ArgumentOutOfRangeException("guess is not between 1 and 100");
            }

            if (Count >= MaxNumberOfGuesses) {
                Outcome = Outcome.NoMoreGuesses;
                return Outcome;
            } else if (_previousGuesses.Contains(guess)) {
                Outcome = Outcome.PreviousGuess;
                return Outcome;
            } else if (guess < _number) {
                Outcome = Outcome.Low;
            } else if (guess > _number) {
                Outcome = Outcome.High;
            } else {
                Outcome = Outcome.Correct;
                return Outcome;
            }

            _previousGuesses.Add(guess);

            return Outcome;
        }
    }

    public enum Outcome {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
}
