using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distilled_community_recorder.Libs
{
    public class ConfigModel
    {
        public string cam_1_Url { get; set; } = null!;
        public string cam_2_Url { get; set; } = null!;
        public string cam_3_Url { get; set; } = null!;
        public string cam_4_Url { get; set; } = null!;
        public string cam_5_Url { get; set; } = null!;
        public int rec_interval { get; set; }
        public bool send_to_server { get; set; }
        public string local_rec_path { get; set; } = null!;
        public string server_rec_path { get; set; } = null!;

        public string cam_prefix { get; set; } = null!;

        public string cam_site { get; set; } = null!;
    }
}
