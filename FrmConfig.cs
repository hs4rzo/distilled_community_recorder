using distilled_community_recorder.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace distilled_community_recorder
{
    public partial class FrmConfig : Form
    {




        ConfigController _config = new ConfigController();
        ConfigModel _configModel = new ConfigModel();
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            get_config();
        }

        public void get_config()
        {
            _config.getConfig();
            binding_config(_config.Config);
        }

        public void binding_config(ConfigModel model)
        {
            txtUrl1.Text = model.cam_1_Url;
            txtUrl2.Text = model.cam_2_Url;
            txtUrl3.Text = model.cam_3_Url;
            txtUrl4.Text = model.cam_4_Url;
            txtUrl5.Text = model.cam_5_Url;
            txtRecInterval.Text = model.rec_interval.ToString();
            chkSendFile.Checked = model.send_to_server;
            txtRecPath.Text = model.local_rec_path;
            txtServerPath.Text = model.server_rec_path;

            txtsite.Text = model.cam_site;
            txtcam_prefix.Text = model.cam_prefix;
            label12.Text = model.cam_site;
            if (!string.IsNullOrEmpty(model.cam_site))
                label14.Text = model.cam_site.Substring(0, 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _configModel.cam_1_Url = txtUrl1.Text;
            _configModel.cam_2_Url = txtUrl2.Text;
            _configModel.cam_3_Url = txtUrl3.Text;
            _configModel.cam_4_Url = txtUrl4.Text;
            _configModel.cam_5_Url = txtUrl5.Text;
            _configModel.cam_1_Url = txtUrl1.Text;

            _configModel.rec_interval = Convert.ToInt32(txtRecInterval.Text);
            _configModel.send_to_server = chkSendFile.Checked;

            _configModel.local_rec_path = txtRecPath.Text;
            _configModel.server_rec_path = txtServerPath.Text;

            //-------------------
            string sitename = "WorkSite";
            string camname = "cam";
            if (!string.IsNullOrEmpty(txtsite.Text))
                sitename = txtsite.Text;
            if (!string.IsNullOrEmpty(txtcam_prefix.Text))
                camname = txtcam_prefix.Text;

            _configModel.cam_site = sitename;
            _configModel.cam_prefix = camname;


            _config.writeConfig(_configModel);
            MessageBox.Show("Config Saved.");
            this.Close();
        }

        private void btnBrowseRec_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtRecPath.Text = op.SelectedPath;
            }
        }

        private void btnBrowseServ_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog op = new FolderBrowserDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtServerPath.Text = op.SelectedPath;
            }
        }

        private void btnExportSetting_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Save JSON File",
                DefaultExt = "json"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonString = JsonSerializer.Serialize(_config.Config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, jsonString);
                MessageBox.Show("Export successfully.", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnImportConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Import JSON config File",
                DefaultExt = "json"
            };

            if (op.ShowDialog() == DialogResult.OK)
            {
                string jsonString = File.ReadAllText(op.FileName);

                var model = JsonSerializer.Deserialize<ConfigModel>(jsonString);
                if (model != null)
                {
                    binding_config(model);
                }
                MessageBox.Show("Import successfully.", "Import File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            preview frmpreview = new preview();
            frmpreview.url = txtUrl1.Text;
            frmpreview.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            preview frmpreview = new preview();
            frmpreview.url = txtUrl2.Text;
            frmpreview.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            preview frmpreview = new preview();
            frmpreview.url = txtUrl3.Text;
            frmpreview.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            preview frmpreview = new preview();
            frmpreview.url = txtUrl4.Text;
            frmpreview.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            preview frmpreview = new preview();
            frmpreview.url = txtUrl5.Text;
            frmpreview.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsite_TextChanged(object sender, EventArgs e)
        {
            label14.Text = txtsite.Text.Substring(0, 1);
            label12.Text = txtsite.Text;
        }

        private void FrmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain frmMain = new FrmMain();
            frmMain.Refresh();
            Refresh();
            frmMain.Hide();
            frmMain.Show();
        }
    }
}
