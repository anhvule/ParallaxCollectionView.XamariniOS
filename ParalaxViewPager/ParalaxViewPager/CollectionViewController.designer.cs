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
    [Register("CollectionViewController")]
    partial class CollectionViewController
    {
        [Outlet]
        UIKit.UIPageControl pageControl { get; set; }

        [Outlet]
        UIKit.UICollectionView swipeView { get; set; }

        [Outlet]
        UIKit.UILabel txtCampaignDes { get; set; }

        [Outlet]
        UIKit.UILabel txtCampaignTitle { get; set; }

        [Outlet]
        UIKit.UILabel txtHeader { get; set; }

        [Outlet]
        UIKit.UIView viewHeader { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (pageControl != null)
            {
                pageControl.Dispose();
                pageControl = null;
            }

            if (swipeView != null)
            {
                swipeView.Dispose();
                swipeView = null;
            }

            if (txtHeader != null)
            {
                txtHeader.Dispose();
                txtHeader = null;
            }

            if (viewHeader != null)
            {
                viewHeader.Dispose();
                viewHeader = null;
            }

            if (txtCampaignTitle != null)
            {
                txtCampaignTitle.Dispose();
                txtCampaignTitle = null;
            }

            if (txtCampaignDes != null)
            {
                txtCampaignDes.Dispose();
                txtCampaignDes = null;
            }
        }
    }
}
