Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls

Namespace DXSample

    Public Class RepositoryItemCustomImageEdit
        Inherits RepositoryItemImageEdit

        Shared Sub New()
            Call RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Const CustomEditName As String = "CustomImageEdit"

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return CustomEditName
            End Get
        End Property

        Public Shared Sub RegisterCustomEdit()
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomImageEdit), GetType(RepositoryItemCustomImageEdit), GetType(ImageEditViewInfo), New CustomBlobBaseEditPainter(), True, CType(Nothing, System.Drawing.Image)))
        End Sub

        Public Shared Function GetImage(ByVal array As Byte()) As Image
            Return ByteImageConverter.FromByteArray(array)
        End Function
    End Class

    Public Class CustomImageEdit
        Inherits ImageEdit

        Shared Sub New()
            RepositoryItemCustomImageEdit.RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemCustomImageEdit.CustomEditName
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Overloads ReadOnly Property Properties As RepositoryItemCustomImageEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemCustomImageEdit)
            End Get
        End Property
    End Class

    Public Class CustomBlobBaseEditPainter
        Inherits BlobBaseEditPainter

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub DrawGlyphCore(ByVal info As ControlGraphicsInfoArgs, ByVal be As ButtonEditViewInfo)
            Dim info_ As ImageEditViewInfo = TryCast(be, ImageEditViewInfo)
            Dim image As Image = Nothing
            If TypeOf info_.EditValue Is Byte() Then
                image = New Bitmap(RepositoryItemCustomImageEdit.GetImage(TryCast(info_.EditValue, Byte())), info_.ImageSize)
            ElseIf TypeOf info_.EditValue Is Image Then
                image = New Bitmap(CType(info_.EditValue, Image), info_.ImageSize)
            End If

            If image Is Nothing Then
                MyBase.DrawGlyphCore(info, be)
                Return
            End If

            info.Cache.Paint.DrawImage(info.Graphics, image, be.GlyphBounds)
        End Sub
    End Class
End Namespace
