Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports DevExpress.XtraEditors

Namespace DXSample

    Public Partial Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Overloads Sub OnLoad(ByVal sender As Object, ByVal e As EventArgs)
            gridControl1.DataSource = GetData()
            customEdit1.Image = SystemIcons.Shield.ToBitmap()
        End Sub

        Private Shared Function GetData() As DataTable
            Dim dt As DataTable = New DataTable()
            dt.Columns.Add("Icon", GetType(Image))
            dt.Columns.Add("IconName")
            dt.Rows.Add(SystemIcons.Application.ToBitmap(), "Application")
            dt.Rows.Add(SystemIcons.Asterisk.ToBitmap(), "Asterisk")
            dt.Rows.Add(SystemIcons.Error.ToBitmap(), "Error")
            dt.Rows.Add(SystemIcons.Exclamation.ToBitmap(), "Exclamation")
            dt.Rows.Add(SystemIcons.Hand.ToBitmap(), "Hand")
            dt.Rows.Add(SystemIcons.Information.ToBitmap(), "Information")
            dt.Rows.Add(SystemIcons.Question.ToBitmap(), "Question")
            Return dt
        End Function
    End Class
End Namespace
