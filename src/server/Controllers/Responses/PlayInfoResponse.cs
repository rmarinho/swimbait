﻿namespace Swimbait.Server.Controllers.Responses
{
    public class PlayInfoResponse
    {
            public int response_code { get; set; }
            public string input { get; set; }
            public string playback { get; set; }
            public string repeat { get; set; }
            public string shuffle { get; set; }
            public int play_time { get; set; }
            public int total_time { get; set; }
            public string artist { get; set; }
            public string album { get; set; }
            public string track { get; set; }
            public string albumart_url { get; set; }
            public int albumart_id { get; set; }
            public string usb_devicetype { get; set; }
            public bool auto_stopped { get; set; }
            public int attribute { get; set; }
        
    }
}
