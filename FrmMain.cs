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
using System.Timers;
using System.Text.Json;
using System.Diagnostics;
using System.Reflection;//<----

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
        private System.Timers.Timer controlbuttontimer;
        private int startwaittimer = 15;   // 15 วิ   
        CopyFolder.Program _copyFolder = new CopyFolder.Program();
        
        //###########################

        public FrmMain()
        {
            InitializeComponent();
            _config.getConfig();
            appPath = string.Format("{0}\\exc_recorder", rootPath);

            controlbuttontimer = new System.Timers.Timer(startwaittimer * 1000);

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            if (Convert.ToInt32(_config.Config.rec_interval) < 1 || string.IsNullOrEmpty(_config.Config.cam_site.ToString()) || string.IsNullOrEmpty(_config.Config.cam_prefix.ToString()))
            {

                string jsonString = File.ReadAllText(Application.StartupPath + @"config.json");
                var model = JsonSerializer.Deserialize<ConfigModel>(jsonString);
                if (model != null)
                {
                    FrmConfig frmConfig = new FrmConfig();
                    ConfigModel _configModel = new ConfigModel();

                    _configModel.cam_1_Url = model.cam_1_Url;
                    _configModel.cam_2_Url = model.cam_2_Url;
                    _configModel.cam_3_Url = model.cam_3_Url;
                    _configModel.cam_4_Url = model.cam_4_Url;
                    _configModel.cam_5_Url = model.cam_5_Url;

                    _configModel.rec_interval = Convert.ToInt32(model.rec_interval);
                    _configModel.send_to_server = model.send_to_server;

                    _configModel.local_rec_path = model.local_rec_path;
                    _configModel.server_rec_path = model.server_rec_path;

                    //-------------------
                    string camsite = "WorkSite";
                    string camprefix = "Cam";
                    if (!string.IsNullOrEmpty(model.cam_site))
                        camsite = model.cam_site;
                    if (!string.IsNullOrEmpty(model.cam_prefix))
                        camprefix = model.cam_prefix;

                    _configModel.cam_site = camsite.ToString();
                    _configModel.cam_prefix = camprefix.ToString();

                    _config.writeConfig(_configModel);
                    // frmConfig.ShowDialog();
                    MessageBox.Show("First install import Config sucess.");

                }

            }

            init();          
            info();
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

            this.Text += " Version: " +Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }
        void info()
        {
            infosite.Text = _config.Config.cam_site.ToString();
            infoprefix.Text = _config.Config.cam_prefix.ToString();
            infointerval.Text = _config.Config.rec_interval.ToString();
            infolocal.Text = _config.Config.local_rec_path.ToString();
            if (infolocal.Text.Split(':')[0].ToString().Length == 1)
                infolocal.Text += Infodrive(infolocal.Text.Split(':')[0].ToString());

            infoserver.Text = _config.Config.server_rec_path.ToString();
            if (infoserver.Text.Split(':')[0].ToString().Length == 1)
                infoserver.Text += Infodrive(infoserver.Text.Split(':')[0].ToString());

            if (!string.IsNullOrEmpty(infointerval.Text))
                recordingTimer = new System.Timers.Timer((Convert.ToInt16(infointerval.Text) * 60) * 1000);  //เวลาบันทึก ไม่ควรน้อยกว่าเวลา ดีเลย์ ควบคุมปุ่ม
            else
                recordingTimer = new System.Timers.Timer((10 * 60) * 1000);  //เวลาบันทึก ไม่ควรน้อยกว่าเวลา ดีเลย์ ควบคุมปุ่ม

        }

        private void SaveVideo(object sender, EventArgs e)
        {

            btnConfig.Enabled = false;
            btnPlayback.Enabled = false;
            btnReccord.Enabled = false;
            btnlive.Enabled = false;

            infolocal.Text = _config.Config.local_rec_path.ToString();
            if (infolocal.Text.Split(':')[0].ToString().Length == 1)
                infolocal.Text += Infodrive(infolocal.Text.Split(':')[0].ToString());

            infoserver.Text = _config.Config.server_rec_path.ToString();
            if (infoserver.Text.Split(':')[0].ToString().Length == 1)
                infoserver.Text += Infodrive(infoserver.Text.Split(':')[0].ToString());



            foreach (ucCameraViewer viewer in _camViewer)
            {
                viewer.stop();
                Thread.Sleep(500);
            }
            foreach (ucCameraViewer viewer in _camViewer)
            {
                Task.Run(() =>
                {
                    viewer.play(viewer.Name);
                });
            }

            waittimer(true);

            //  btnConfig.Enabled = false;
            // lblStatus.Text = "Status: recording...";
            //  lblStatus.Image = distilled_community_recorder.Properties.Resources.bullet_red;
            // }
        }
        private void btnPlayback_Click(object sender, EventArgs e)
        {
            // ห้ามกระทำปุ่มชั่วขณะ
            btnConfig.Enabled = false;
            btnPlayback.Enabled = false;
            btnReccord.Enabled = false;
            btnlive.Enabled = false;


            if (_state == WORING_STATE.STOP)
            {           

                if (recordingTimer.Enabled == true)
                    recordingTimer.Stop();
                if (controlbuttontimer.Enabled == true)
                    controlbuttontimer.Stop();


                btnPlayback.Text = "Stop record";
                _state = WORING_STATE.PLAING;
                btnPlayback.Image = distilled_community_recorder.Properties.Resources.bullet_red;
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    Task.Run(() =>
                    {
                        viewer.play(viewer.Name);
                    });

                }
                lblStatus.Text = "Status: recording...";
                lblStatus.Image = distilled_community_recorder.Properties.Resources.bullet_red;

                //###########################  ควบคุมเวลา การบันทึก
                recordingTimer.Start();
                recordingTimer.Elapsed += SaveVideo;

            }
            else
            {
                if (recordingTimer.Enabled == true)
                    recordingTimer.Stop();
                foreach (ucCameraViewer viewer in _camViewer)
                {
                    _state = WORING_STATE.STOP;
                    btnPlayback.Text = "Start record";
                    btnPlayback.Image = distilled_community_recorder.Properties.Resources.control_play;
                    Task.Run(() =>
                    {
                        viewer.stop();
                    });
                    lblStatus.Text = "Status: stop";
                    lblStatus.Image = null;
                    //-----------------                      
                }

            }
            //###########################  ควบคุมเวลา ปุ่ม
            waittimer(true);
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
            this.Hide();
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

            if (recordingTimer.Enabled == true)
                recordingTimer.Stop();



            if (_state == WORING_STATE.STOP)
            {

                foreach (ucCameraViewer viewer in _camViewer)
                {
                    Task.Run(() =>
                    {
                        viewer.liveview();
                    });
                }
                btnlive.Image = distilled_community_recorder.Properties.Resources.live;
                btnlive.Text = "Stop LiveView";
                _state = WORING_STATE.PLAING;
                lblStatus.Text = "Status: Live...";
                waittimer(false);
            }
            else
            {

                foreach (ucCameraViewer viewer in _camViewer)
                {
                    Task.Run(() =>
                    {
                        viewer.stop();
                    });
                }
                btnlive.Image = distilled_community_recorder.Properties.Resources.control_play;
                btnlive.Text = "Start LiveView";
                _state = WORING_STATE.STOP;
                lblStatus.Text = "Status: stop";
                lblStatus.Image = null;
                waittimer(false);
                //-----------------
            }
        }

        private void waittimer(bool rec)
        {

            controlbuttontimer.Start();
            if (rec == true)
            {
                controlbuttontimer.Elapsed += controlbuttonrec;
            }
            else
            {
                toolStrip1.Enabled = false;
                controlbuttontimer.Elapsed += controlbutton;
            }
        }
        private void controlbuttonrec(object sender, EventArgs e)
        {

            if (btnPlayback.Text == "Stop record")
            {
                btnPlayback.Enabled = true;
            }
            else
            {
                btnConfig.Enabled = true;
                btnPlayback.Enabled = true;
                btnReccord.Enabled = true;
                btnlive.Enabled = true;
            }
            controlbuttontimer.Stop();

        }
        private void controlbutton(object sender, EventArgs e)
        {
            toolStrip1.Enabled = true;
            if (btnlive.Text == "Stop LiveView")
            {
                btnConfig.Enabled = false;
                btnPlayback.Enabled = false;
                btnReccord.Enabled = false;
            }
            if (btnlive.Text == "Start LiveView")
            {
                btnConfig.Enabled = true;
                btnPlayback.Enabled = true;
                btnReccord.Enabled = true;
            }
            controlbuttontimer.Stop();

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_config.Config.local_rec_path))
                Process.Start("explorer.exe", @_config.Config.local_rec_path);
            else
                Process.Start("explorer.exe");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_config.Config.server_rec_path))
                Process.Start("explorer.exe", @_config.Config.server_rec_path);
            else
                Process.Start("explorer.exe");
        }



        private string Infodrive(string driveinfo)
        {

            // ระบุไดรฟ์ที่ต้องการตรวจสอบ 

            DriveInfo drive = new DriveInfo(driveinfo);

            // ตรวจสอบว่าไดรฟ์มีอยู่จริงและเป็นไดรฟ์แบบ Fixed (ฮาร์ดดิสก์)      if (drive.IsReady && drive.DriveType == DriveType.Fixed)
            if (drive.IsReady)
            {
                // คำนวณพื้นที่ว่างทั้งหมดเป็น byte
                long totalFreeSpace = drive.TotalFreeSpace;

                // คำนวณพื้นที่ทั้งหมดของไดรฟ์เป็น byte
                long totalSize = drive.TotalSize;

                // คำนวณเปอร์เซ็นต์พื้นที่ว่าง
                double freeSpacePercentage = (double)totalFreeSpace / totalSize * 100;

                // แสดงผลลัพธ์

                return $"\r\nพื้นที่ว่างของไดรฟ์ {driveinfo}: {freeSpacePercentage:F2}%";

            }
            else
            {
                return $"\r\nไม่สามารถเข้าถึงไดรฟ์ {driveinfo}: ได้";
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
