using System;
using Android.Content;
using Android.Runtime;
using OneRM.Android.Renderer;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace OneRM.Android.Renderer
{
    public class CustomLabelRenderer : Xamarin.Forms.Platform.Android.FastRenderers.LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {

        }

        [Obsolete]
        public CustomLabelRenderer(IntPtr handle, JniHandleOwnership transfer)
        {

        }
    }
}