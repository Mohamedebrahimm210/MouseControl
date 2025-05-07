using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseControl
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        private const uint ES_CONTINUOUS = 0x80000000;
        private const uint ES_DISPLAY_REQUIRED = 0x00000002;

        private CancellationTokenSource _cts;
        private Random _random = new Random();
        private int countdownSeconds = 120; // 2 minutes
        private Label lblTimer;
        private System.Windows.Forms.Timer uiTimer;


        public Form1()
        {
            InitializeComponent();
            uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 1000; // 1 second interval
            uiTimer.Tick += UiTimer_Tick;

            lblTimer = new Label
            {
                Location = new Point(50, 70),
                Size = new Size(250, 30),
                Text = "Timer: Ready"
            };

            this.Controls.Add(lblTimer);


            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;

            // Try to set a custom icon if available
            try
            {
                if (System.IO.File.Exists("appicon.ico"))
                    this.Icon = new Icon("appicon.ico");
            }
            catch
            {
                // Ignore invalid icon
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //countdownSeconds = 120;
            uiTimer.Start(); // Start UI countdown

            if (_cts != null)
            {
                MessageBox.Show("Mouse movement is already running.");
                return;
            }

            _cts = new CancellationTokenSource();
            StartMouseMover(_cts.Token);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            uiTimer.Stop();
            lblTimer.Text = "Timer: Stopped";

            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
                MessageBox.Show("Mouse movement stopped.");
            }
        }
        
        private async void StartMouseMover(CancellationToken token)
        {
            MessageBox.Show("Mouse movement started. It will move every 2 minutes.");

            while (!token.IsCancellationRequested)
            {
                SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED);

                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                int x = _random.Next(0, screenWidth);
                int y = _random.Next(0, screenHeight);
                SetCursorPos(x, y);

                try
                {
                    await Task.Delay(TimeSpan.FromMinutes(2), token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }

            SetThreadExecutionState(ES_CONTINUOUS);
        }

        //private int countdownSeconds = 120; // 2 minutes in seconds
        private void UiTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;

            TimeSpan timeLeft = TimeSpan.FromSeconds(countdownSeconds);
            lblTimer.Text = $"Next move in: {timeLeft:mm\\:ss}";

            if (countdownSeconds <= 0)
            {
                countdownSeconds = 120; // reset
            }
        }
    }
}
