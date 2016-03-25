using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyTap
{
    public partial class MonkeyTapPage
    {
        const int sequenceTime = 750;       // in msec
        protected const int flashDuration = 250;

        const double offLuminosity = 0.4;   // somewhat dimmer
        const double onLuminosity = 0.75;   // much brighter

        BoxView[] boxViews;
        Color[] colors = { Color.Red, Color.Blue, Color.Yellow, Color.Green };
        List<int> sequence = new List<int>();
        int sequenceIndex;
        bool awaitingTaps;
        bool gameEnded;
        Random random = new Random();

        public MonkeyTapPage()
        {
            InitializeComponent();
            boxViews = new BoxView[] { boxview0, boxview1, boxview2, boxview3 };
            InitializeBoxViewColors();
        }

        void InitializeBoxViewColors()
        {
            for (int index = 0; index < 4; index++)
                boxViews[index].Color = colors[index].WithLuminosity(offLuminosity);
        }

        protected void OnStartGameButtonClicked(object sender, EventArgs args)
        {
            gameEnded = false;
            startGameButton.IsVisible = false;
            InitializeBoxViewColors();
            sequence.Clear();
            StartSequence();
        }

        void StartSequence()
        {
            sequence.Add(random.Next(4));
            sequenceIndex = 0;
            Device.StartTimer(TimeSpan.FromMilliseconds(sequenceTime), OnTimerTick);
        }

        bool OnTimerTick()
        {
            if (gameEnded)
                return false;

            FlashBoxView(sequence[sequenceIndex]);
            sequenceIndex++;
            awaitingTaps = sequenceIndex == sequence.Count;
            sequenceIndex = awaitingTaps ? 0 : sequenceIndex;
            return !awaitingTaps;
        }

        protected virtual void FlashBoxView(int index)
        {
            boxViews[index].Color = colors[index].WithLuminosity(onLuminosity);
            Device.StartTimer(TimeSpan.FromMilliseconds(flashDuration), () =>
                {
                    if (gameEnded)
                        return false;

                    boxViews[index].Color = colors[index].WithLuminosity(offLuminosity);
                    return false;
                });
        }

        protected void OnBoxViewTapped(object sender, EventArgs args)
        {
            if (gameEnded)
                return;

            if (!awaitingTaps)
            {
                EndGame();
                return;
            }

            BoxView tappedBoxView = (BoxView)sender;
            int index = Array.IndexOf(boxViews, tappedBoxView);

            if (index != sequence[sequenceIndex])
            {
                EndGame();
                return;
            }

            FlashBoxView(index);

            sequenceIndex++;
            awaitingTaps = sequenceIndex < sequence.Count;

            if (!awaitingTaps)
                StartSequence();
        }

        protected virtual void EndGame()
        {
            gameEnded = true;

            for (int index = 0; index < 4; index++)
                boxViews[index].Color = Color.Gray;

            startGameButton.Text = "Try again?";
            startGameButton.IsVisible = true;
        }
    }
}
