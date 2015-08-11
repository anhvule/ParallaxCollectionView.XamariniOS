
using System;

using Foundation;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using CoreLocation;
using System.Linq;

namespace ParallaxViewPager.iOS
{
    public partial class CollectionViewController : UIViewController
    {
        private NSTimer _timer;
        private bool _areConstraintsUpdated = false;

        public CollectionViewController()
            : base("CollectionViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DecorateControls();

            BindData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ScrollSwipeViewTo1st();
        }

        private void DecorateControls()
        {
            var flowLayout = new UICollectionViewFlowLayout()
            {
                HeaderReferenceSize = new CGSize(0, 0),
                SectionInset = new UIEdgeInsets(0, 0, 0, 0),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal,
                MinimumInteritemSpacing = 0,
                MinimumLineSpacing = 0
            };

            swipeView.CollectionViewLayout = flowLayout;
            swipeView.PagingEnabled = true;
            swipeView.ShowsHorizontalScrollIndicator = false;
            swipeView.BackgroundColor = UIColor.White;

            swipeView.DataSource = new CollectionViewSource(swipeView);

            var nib = UINib.FromName(ImageCell.Key, null);
            swipeView.RegisterNibForCell(nib, ImageCell.Key);

            swipeView.Delegate = new CollectionViewDelegate(pageControl);

            if (pageControl != null)
            {
                pageControl.CurrentPageIndicatorTintColor = UIColor.Red;
                pageControl.PageIndicatorTintColor = UIColor.White;
                View.BringSubviewToFront(pageControl);
            }
        }

        private void BindData()
        {
            var products = ItemFactory.Create();
            var source = (CollectionViewSource)swipeView.DataSource;
            source.Models = products;

            var del = (CollectionViewDelegate)swipeView.Delegate;
            del.Models = products;
            pageControl.Pages = products.Count;
        }

        private void ScrollSwipeViewTo1st()
        {
            // Scroll swipe view to 1st position.
            _timer = NSTimer.CreateScheduledTimer(0.1, delegate(NSTimer obj)
                {
                    swipeView.ScrollRectToVisible(new CGRect((1) * swipeView.Frame.Size.Width, 0, swipeView.Frame.Size.Width, swipeView.Frame.Size.Height), false);
                    _timer.Invalidate();
                    _timer = null;
                });
        }
    }
}

