using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class ReportInfo
{
    public decimal ReportID { get; set; }
    public string ReportName { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public DateTime SubmitDateTime { get; set; }
    public string ReportProperty { get; set; }
    public int DraftIsShare { get; set; }
    public string ReportRights { get; set; }
    public int Status { get; set; }
    public string WindowsProperty { get; set; }
    public byte[] DocxTemplate { get; set; }

    public String test { get; set; }
}

