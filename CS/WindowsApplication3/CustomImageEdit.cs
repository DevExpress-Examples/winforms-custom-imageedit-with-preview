using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using System.IO;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;

namespace DXSample {
    public class RepositoryItemCustomImageEdit : RepositoryItemImageEdit
    {
        static RepositoryItemCustomImageEdit() { RegisterCustomEdit(); }

        public RepositoryItemCustomImageEdit() { }

        public const string CustomEditName = "CustomImageEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomImageEdit), typeof(RepositoryItemCustomImageEdit),
              typeof(ImageEditViewInfo), new CustomBlobBaseEditPainter(), true, null));
        }

        public static Image GetImage(byte[] array)
        {
            return ByteImageConverter.FromByteArray(array);
        }
    }

    public class CustomImageEdit : ImageEdit {
        static CustomImageEdit() { RepositoryItemCustomImageEdit.RegisterCustomEdit(); }

        public CustomImageEdit() {  }

        public override string EditorTypeName
        {
            get {
                return RepositoryItemCustomImageEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomImageEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomImageEdit; }
        }
    }

    public class CustomBlobBaseEditPainter : BlobBaseEditPainter
    {
        public CustomBlobBaseEditPainter() : base() { }
        protected override void DrawGlyphCore(ControlGraphicsInfoArgs info, ButtonEditViewInfo be)
        {
            ImageEditViewInfo info_ = be as ImageEditViewInfo;
            Image image = null;
            if (info_.EditValue is byte[])
                image = new Bitmap(RepositoryItemCustomImageEdit.GetImage(info_.EditValue as byte[]), info_.ImageSize);
            else if (info_.EditValue is Image)
                image = new Bitmap((Image)info_.EditValue, info_.ImageSize);
            if (image == null)
            {
                base.DrawGlyphCore(info, be);
                return;
            }
            info.Cache.Paint.DrawImage(info.Graphics, image, be.GlyphBounds);
        }
    }
}