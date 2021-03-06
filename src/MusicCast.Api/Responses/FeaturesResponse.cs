﻿using System.Collections.Generic;

namespace MusicCast.Responses
{
    public class InputList2
    {
        public string id { get; set; }
        public bool distribution_enable { get; set; }
        public bool rename_enable { get; set; }
        public bool account_enable { get; set; }
        public string play_info_type { get; set; }
    }

    public class System
    {
        public IList<string> func_list { get; set; }
        public int zone_num { get; set; }
        public IList<InputList2> input_list { get; set; }

        public System()
        {
            func_list = new List<string>();
            input_list = new List<InputList2>();
        }
    }

    public class RangeStep
    {
        public string id { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int step { get; set; }
    }

    public class Zone
    {
        public string id { get; set; }
        public IList<string> func_list { get; set; }
        public IList<string> input_list { get; set; }
        public IList<string> link_control_list { get; set; }
        public IList<RangeStep> range_step { get; set; }

        public Zone()
        {
            func_list = new List<string>();
            input_list = new List<string>();
            link_control_list = new List<string>();
            range_step = new List<RangeStep>();
        }
    }

    public class Preset
    {
        public int num { get; set; }
    }

    public class Netusb
    {
        public Preset preset { get; set; }

        public Netusb()
        {
            preset = new Preset();
        }
    }

    public class FeaturesResponse  : BasicResponse
    {
        public System system { get; set; }
        public IList<Zone> zone { get; set; }
        public Netusb netusb { get; set; }

        public FeaturesResponse()
        {
            netusb = new Netusb();
            system = new System();
            zone = new List<Zone>();
        }
    }
}
