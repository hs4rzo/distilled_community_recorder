using distilled_community_recorder.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.DataFormats;
using System.Timers;//<----

namespace distilled_community_recorder
{
    public partial class FrmMain : Form
    {

        WORING_STATE _state = WORING_STATE.STOP;
        ConfigController _config = new ConfigController();

        ucCameraViewer[] _camViewer = new ucCameraViewer[5];
        string rootPath = GetFolderPath(SpecialFolder.CommonApplicationData);
        string appPath = "";

        //###########################
        private System.Timers.Timer recordingTimer;
        //###########################

        public FrmMain()
        {
            InitializeComponent();
            _config.getConfig();
            appPath = string.Format("{0}\\exc_recorder", rootPath);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            init();
        }

        void init()
        {
            pn_1.Dock = DockStyle.Fill;
            pn_2.Dock = DockStyle.Fill;
            pn_3.Dock = DockStyle.Fill;
            pn_4.Dock = DockStyle.Fill;
            pn_5.Dock = DockStyle.Fill;

            _camViewer[0] = new ucCameraViewer(_config.Config.cam_1_Url);
            _camViewer[0].Dock = DockStyle.Fill;
            pn_1.Controls.Add(_camViewer[0]);

            _camViewer[1] = new ucCameraViewer(_config.Config.cam_2_Url);
            _camViewer[1].Dock = DockStyle.Fill;
            pn_2.Controls.Add(_camViewer[1]);

            _camViewer[2] = new ucCameraViewer(_config.Config.cam_3_Url);
            _camViewer[2].Dock = DockStyle.Fill;
            pn_3.Controls.Add(_camViewer[2]);

            _camViewer[3] = new ucCameraViewer(_config.Config.cam_4_Url);
            _camViewer[3].Dock = DockStyle.Fill;
            pn_4.Controls.Add(_camViewer[3]);

            _camViewer[4] = new ucCameraViewer(_config.Config.cam_5_Url);
            _camViewer[4].Dock = DockStyle.Fill;
            pn_5.Controls.Add(_camViewer[4]);


            _config.getConfig();

            //###########################
            _camViewer[0].Name = _config.Config.cam_prefix + "1";
            _camViewer[1].Name = _config.Config.cam_prefix + "2";
            _camViewer[2].Name = _config.Config.cam_prefix + "3";
            _camViewer[3].Name = _config.Config.cam_prefix + "4";
            _camViewer[4].Name = _config.Config.cam_prefix + "5";
            //###########################

        }

        void playback()
        {
            if (_state == WORING_STATE.STOP)
            {
                btnPlayback.Text = "Stop LiveView";
                _state = WORING_STATE.PLAING;
                btnPlayback.Image = distilled_community_recorder.Properties.Resources.control_stop;
                int numcam = 1;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    viewer.play(viewer.Name);
                }
                btnConfig.Enabled = false;
                lblStatus.Text = "Status: recording...";
                lblStatus.Image = distilled_community_recorder.Properties.Resources.bullet_red;

            }
            else
            {
                _state = WORING_STATE.STOP;
                btnPlayback.Text = "Start LiveView";
                btnPlayback.Image = distilled_community_recorder.Properties.Resources.control_play;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    viewer.stop();

                }
                btnConfig.Enabled = true;
                lblStatus.Text = "Status: stop";
                lblStatus.Image = null;
                //-----------------

            }
        }
        private void SaveVideo(object sender, EventArgs e)
        {
            if (_state == WORING_STATE.PLAING)
            {
                btnPlayback.Text = "Stop LiveView";
                _state = WORING_STATE.PLAING;
                btnPlayback.Image = distilled_community_recorder.Properties.Resources.control_stop;
                int numcam = 1;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    viewer.play(viewer.Name);
                }
                btnConfig.Enabled = false;
                lblStatus.Text = "Status: recording...";
                lblStatus.Image = distilled_community_recorder.Properties.Resources.bullet_red;
            }
        }
        private async void btnPlayback_Click(object sender, EventArgs e)
        {

            playback();


            //###########################  ควบคุมเวลา
            recordingTimer = new System.Timers.Timer((Convert.ToInt16(_config.Config.rec_interval)*60) * 1000);
            recordingTimer.Start();
            recordingTimer.Elapsed += SaveVideo;

        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ucCameraViewer viewer in _camViewer)
            {
                viewer.stop();
            }
        }


        private void btnConfig_Click(object sender, EventArgs e)
        {
            new FrmConfig().ShowDialog();

            /*
            _config.getConfig();
            _camViewer[0].setRstpUrl(_config.Config.cam_1_Url);
            _camViewer[1].setRstpUrl(_config.Config.cam_2_Url);
            _camViewer[2].setRstpUrl(_config.Config.cam_3_Url);
            _camViewer[3].setRstpUrl(_config.Config.cam_4_Url);
            _camViewer[4].setRstpUrl(_config.Config.cam_5_Url);
             */
        }



        //########################### live ไม่ต้องบันทึก
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_state == WORING_STATE.STOP)
            {
                toolStripButton1.Text = "Stop LiveView";
                _state = WORING_STATE.PLAING;
                toolStripButton1.Image = distilled_community_recorder.Properties.Resources.control_stop;
                int numcam = 1;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    viewer.liveview();
                }
                btnConfig.Enabled = false;
                lblStatus.Text = "Status: recording...";
                lblStatus.Image = distilled_community_recorder.Properties.Resources.bullet_red;

            }
            else
            {
                _state = WORING_STATE.STOP;
                toolStripButton1.Text = "Start LiveView";
                toolStripButton1.Image = distilled_community_recorder.Properties.Resources.control_play;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    viewer.stop();

                }
                btnConfig.Enabled = true;
                lblStatus.Text = "Status: stop";
                lblStatus.Image = null;
                //-----------------

            }
        }
    }
}
