using Emgu.CV;
using VirtualCameraOutput;
using VirtualCameraOutput.Extensions;

namespace WinFormsApp2
{
    public partial class VideoOutputTest : Form
    {
        private VirtualOutput _virtualOutput;
        private VideoCapture _videoCapture;
        private Mat _currentFrame;
        private int _fps;
        private int _totalFrames;
        private int _currentFrameNumber;
        private bool _isPlaying;
        private string _fileName;
        private int _speed = 100;
        public VideoOutputTest()
        {
            InitializeComponent();
            speedBox.Text = _speed.ToString();
        }

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";
            dlg.InitialDirectory = @"C:\";
            dlg.Title = "Please select a video file.";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _isPlaying = false;
                _videoCapture = new VideoCapture(dlg.FileName);
                _totalFrames = Convert.ToInt32(_videoCapture.Get(Emgu.CV.CvEnum.CapProp.FrameCount));
                _fps = Convert.ToInt32(_videoCapture.Get(Emgu.CV.CvEnum.CapProp.Fps));
                if (_virtualOutput != null)
                {
                    _virtualOutput.Close();
                    _virtualOutput.Dispose();
                }
                _virtualOutput = new VirtualOutput(Convert.ToInt32(_videoCapture.Get(Emgu.CV.CvEnum.CapProp.FrameWidth)), Convert.ToInt32(_videoCapture.Get(Emgu.CV.CvEnum.CapProp.FrameHeight)),_fps,FourCC.FOURCC_24BG);
                _currentFrameNumber = 0;
                _currentFrame = _videoCapture.QueryFrame();
                pictureBox.Image = _currentFrame.ToBitmap();
                trackBar.Minimum = 0;
                trackBar.Maximum = _totalFrames - 1;
                trackBar.Value = 0;
                _fileName = Path.GetFileName(dlg.FileName);
                this.Text = String.Format("{0} | totalFrames:{1} | fps:{2}", _fileName, _totalFrames, _fps);
            }
        }

        private async void Btn_Play_Click(object sender, EventArgs e)
        {
            await PlayVideo();
        }

        private async Task PlayVideo()
        {
            if (_videoCapture == null || _isPlaying)
                return;

            _isPlaying = true;
            while (_isPlaying && _currentFrameNumber < _totalFrames)
            {
                Bitmap bmp = GetVideoFrame(_currentFrameNumber);
                pictureBox.Image = bmp;
                trackBar.Value = _currentFrameNumber;
                _currentFrameNumber++;
                if (_virtualOutput != null && _virtualOutput.Running)
                    _virtualOutput.Send(bmp.ToArray());

                await Task.Delay(_speed / _fps);
            }
        }

        private void StopVideo()
        {
            _isPlaying = false;
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            StopVideo();
        }

        private void Btn_ApplySpeed_Click(object sender, EventArgs e)
        {
            try
            {
                _speed = Int32.Parse(speedBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Only integers!");
            }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            _isPlaying = false;
            _currentFrameNumber = trackBar.Value;
            Bitmap bmp = GetVideoFrame(_currentFrameNumber);
            pictureBox.Image = bmp;
            if (_virtualOutput != null && _virtualOutput.Running)
                _virtualOutput.Send(bmp.ToArray());
        }

        private Bitmap GetVideoFrame(int frameNumber)
        {
            _videoCapture.Set(Emgu.CV.CvEnum.CapProp.PosFrames, frameNumber);
            _videoCapture.Read(_currentFrame);
            return _currentFrame.ToBitmap();
        }

    }
}