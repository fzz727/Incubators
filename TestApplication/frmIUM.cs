using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class frmIUM : Form
    {
        public frmIUM()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            String sql = @"
                          select distinct ddate From
                         (
                         select [date] ddate, stationid,[temper] data From [dbo].[AutoStationData] where stationid in ( SELECT stationid FROM [t_AutoStationInfo] WHERE sType=1 )
                         union
                         select [date], stationid,T1 data from [dbo].[t_Awsgl_Data] where stationid in ( 'A1026','A1027','A1056','A1058','A1063','A1075','A1210','A1211','A1262',
                         'A1269','A1325','A1326','A1413','A1414','A1420','A1512','A1565','A1564','A1055','A1062','A1412','A1467')
                         ) t where data<>33799 order by ddate
";

            DataTable date = OR.SQLHelper.Query(sql).Tables[0];



            sql = @"
                         select t.*, a.Lon, a.Lat From
                         (
                         select [date] ddate, stationid,[temper] data From [dbo].[AutoStationData] where stationid in ( SELECT stationid FROM [t_AutoStationInfo] WHERE sType=1 )
                         union
                         select [date], stationid,T1 data from [dbo].[t_Awsgl_Data] where stationid in ( 'A1026','A1027','A1056','A1058','A1063','A1075','A1210','A1211','A1262',
                         'A1269','A1325','A1326','A1413','A1414','A1420','A1512','A1565','A1564','A1055','A1062','A1412','A1467')
                         ) t inner join [dbo].[t_AutoStationInfo] a on t.stationId = a.StationID where data<>33799 
                         order by [ddate],stationid
                         ";
            DataTable dt = OR.SQLHelper.Query(sql).Tables[0];


            for (int i = 0; i < date.Rows.Count; i++)
            {
                DateTime d = DateTime.Parse(date.Rows[i][0].ToString());

                DataRow[] rows = dt.Select(" ddate='" + d.ToString() + "'");

                String folder = @"D:\Projects\ium\JavaServer\data\src\d6T3\Tempure\";

                String file = folder + d.ToString("yyyyMMddHH") + ".000";

                StringBuilder content = new StringBuilder();

                for (int j = 0; j < rows.Length; j++)
                {

                    content.AppendFormat("{0} {1} {2} {3} {4}\r\n",
                        rows[j]["StationId"].ToString(),
                        rows[j]["Lon"].ToString(),
                        rows[j]["Lat"].ToString(),
                        "0",
                        rows[j]["data"].ToString());

                }

                System.IO.File.WriteAllText(file, content.ToString());

            }

        }
    }
}
