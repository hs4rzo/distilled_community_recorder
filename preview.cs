using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace distilled_community_recorder
{
    public partial class preview : Form
    {
        public string url;     

        private VlcControl _camera;
      
        public preview()
        {
            InitializeComponent();
            InitializeVlcControl(); 
        }
        private void InitializeVlcControl()
        {
            _camera = new VlcControl();
            _camera.Dock = DockStyle.Fill;
            panel1.Controls.Add(_camera);
            var libDirectory = new DirectoryInfo("" + Application.StartupPath + @"\appLibs");
            if (!libDirectory.Exists)
            {
                MessageBox.Show("ไม่พบไดเรกทอรี VLC");
                return;
            }
            _camera.VlcLibDirectory = libDirectory;
            _camera.Playing += OnPlaying;
            _camera.Stopped += OnStopped;
            _camera.EncounteredError += OnEncounteredError;
            _camera.EndReached += OnEndReached;
            _camera.EndInit();
        }
        private void preview_Load(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    _camera.Play(new Uri(url), "--rtsp-tcp");   //"--rtsp-tcp" <-- สำหรับ live แบบไม่ต้องบันทึก
                 }
                catch (Exception ex)
                {
                    statusLabel.Text = "Connect to url FAIL!";
                }
            }
        }

        void _camera_CameraStateChanged(string message)
        {
            InvokeThread(() =>
            {
                if (statusLabel.InvokeRequired)
                {
                    statusLabel.Invoke(new Action(() => statusLabel.Text = message));
                }
                else
                {
                    statusLabel.Text = message;
                }
            });           

        }

    
        void InvokeThread(Action action)
        {
            BeginInvoke(action);
        }


        private void OnPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            _camera_CameraStateChanged("Stream is playing.");
        }

        private void OnStopped(object sender, VlcMediaPlayerStoppedEventArgs e)
        {
            _camera_CameraStateChanged("Stream has stopped.");
        }

        private void OnEncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            _camera_CameraStateChanged("An error occurred.");
        }

        private void OnEndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            _camera_CameraStateChanged("Stream has ended.");
        }

    }
}
