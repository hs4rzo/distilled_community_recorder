using distilled_community_recorder.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;
using CopyFolder;

namespace distilled_community_recorder
{
    public partial class ucCameraViewer : UserControl
    {
        //Mr.k
        FrmConfig frmConfig = new FrmConfig();
         ConfigController _config = new ConfigController();
        CopyFolder.Program _copyFolder = new CopyFolder.Program();       
        //-----------------


        private string _rstpUrl = "";
        private string message = "";
        public WORING_STATE State = WORING_STATE.STOP;

        private VlcControl vlcControl = null!;


        public ucCameraViewer(string rtspUrl)
        {
            InitializeComponent();
            InitializeVlcControl();
            _rstpUrl = rtspUrl;
            
        }

        private void ucCameraViewer_Load(object sender, EventArgs e)
        {
           
        }

        public void setRstpUrl(Uri uri, string rtspUrl)
        {
            _rstpUrl = rtspUrl;
        }


        private void InitializeVlcControl()
        {

            vlcControl = new VlcControl();
            vlcControl.Dock = DockStyle.Fill;              
            panel1.Controls.Add(vlcControl);
            // Set the path to the app libraries
            // TODO: auto download this libs after install or update.             
             //var libDirectory = new DirectoryInfo(@"D:\appLibs"); 
              var libDirectory = new DirectoryInfo("" + Application.StartupPath + @"\appLibs");
            if (!libDirectory.Exists)
            {
                MessageBox.Show("ไม่พบไดเรกทอรี VLC");
                return;
            }
            vlcControl.VlcLibDirectory = libDirectory;
            vlcControl.Playing += OnPlaying;
            vlcControl.Stopped += OnStopped;
            vlcControl.EncounteredError += OnEncounteredError;
            vlcControl.EndReached += OnEndReached;
            vlcControl.EndInit();
        }
     
        public void play(string camname)
        {
            _config.getConfig();
            string txtpath = _config.Config.local_rec_path;
            string destpath = _config.Config.server_rec_path;
            string sitename = _config.Config.cam_site;
            string datename = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            string timename = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            string folderpath = (@txtpath + "\\" + sitename + "\\" + camname + "\\" + datename).Trim();
            string targetfolderpath = (@destpath + "\\" + sitename + "\\" + camname + "\\" + datename).Trim();
            string filename = camname + "_" + datename + "_" + timename + "_.MP4";
            string fullname = (@folderpath + "\\" + filename).Trim();
            try
            {
                if (!Directory.Exists(folderpath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderpath);
                }  else {
                   _copyFolder.CopyAllFilesAndFolders(folderpath, targetfolderpath);                                        
                   // Thread.Sleep(2000);
                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }                   
            var mediaOptions = new string[] {   
               ":sout=#duplicate{dst=display,dst=\"transcode{vcodec=h264,acodec=mpga}:standard{access=file,mux=ts,dst="+fullname+"}\"}",
               ":sout-keep",
               ":file-caching=3000" // ":segment-time=10"              
            };          

            if ( !string.IsNullOrEmpty(_rstpUrl) )
            {
                try{
                    UpdateStatusLabel("Initializing...");
                    vlcControl.Play(new Uri(_rstpUrl), mediaOptions);    // "--rtsp-tcp"
                    return;
                }
                catch (Exception ex)
                {
                    message = "Connect to url FAIL!";
                }
            }
            UpdateStatusLabel("No Source...");
        }


        public void liveview()
        {
          
            if (!string.IsNullOrEmpty(_rstpUrl))
            {
                try
                {                    
                    UpdateStatusLabel("Initializing...");
                    vlcControl.Play(new Uri(_rstpUrl), "--rtsp-tcp");
                    return;
                }
                catch (Exception ex)
                {
                    message = "Connect to url FAIL!";
                }
            }
            UpdateStatusLabel("No Source...");
            return;
        }

        public void stop()
        {
            vlcControl.Stop();
            vlcControl.ResetMedia();
            return;
            /*
            if (State == WORING_STATE.PLAING)
            {
                vlcControl.Stop(); 
            }  
            */
        }         

        private void OnPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            
            UpdateStatusLabel("Stream is playing.");          
            
        }

        private void OnStopped(object sender, VlcMediaPlayerStoppedEventArgs e)
        {
            UpdateStatusLabel("Stream has stopped.");             
            
        }

        private void OnEncounteredError(object sender, VlcMediaPlayerEncounteredErrorEventArgs e)
        {
            UpdateStatusLabel("An error occurred.");              
            
        }

        private void OnEndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            UpdateStatusLabel("Stream has ended.");          
            
        }

        private void UpdateStatusLabel(string message)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.Invoke(new Action(() => lblMessage.Text = message));
            }
            else
            {
                lblMessage.Text = message;
            }
        }

        internal void setRstpUrl(string cam_5_Url)
        {
            throw new NotImplementedException();
        }
    }
}
