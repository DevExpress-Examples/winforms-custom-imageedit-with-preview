using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
     
        private void OnLoad(object sender, EventArgs e) {
            gridControl1.DataSource = GetData();

            customEdit1.Image = SystemIcons.Shield.ToBitmap();
        }

        private static DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Icon", typeof(Image));
            dt.Columns.Add("IconName");
            dt.Rows.Add(SystemIcons.Application.ToBitmap(), "Application");
            dt.Rows.Add(SystemIcons.Asterisk.ToBitmap(), "Asterisk");
            dt.Rows.Add(SystemIcons.Error.ToBitmap(), "Error");
            dt.Rows.Add(SystemIcons.Exclamation.ToBitmap(), "Exclamation");
            dt.Rows.Add(SystemIcons.Hand.ToBitmap(), "Hand");
            dt.Rows.Add(SystemIcons.Information.ToBitmap(), "Information");
            dt.Rows.Add(SystemIcons.Question.ToBitmap(), "Question");
            return dt;
        }
    }
}



