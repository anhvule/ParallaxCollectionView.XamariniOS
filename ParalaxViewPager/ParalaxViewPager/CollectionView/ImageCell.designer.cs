// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ParallaxViewPager.iOS
{
    [Register("ImageCell")]
    partial class ImageCell
    {
        [Outlet]
        UIKit.UIButton btnTest { get; set; }

        [Outlet]
        UIKit.UIImageView imageView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (imageView != null)
            {
                imageView.Dispose();
                imageView = null;
            }

            if (btnTest != null)
            {
                btnTest.Dispose();
                btnTest = null;
            }
        }
    }
}
