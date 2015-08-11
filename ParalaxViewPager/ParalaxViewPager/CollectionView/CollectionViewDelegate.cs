using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;
using System.Collections.ObjectModel;

namespace ParallaxViewPager.iOS
{
    public class CollectionViewDelegate  : UICollectionViewDelegate
    {
        private const int SPEED_SCROLLING = 120;

        private UIPageControl _pageControl;

        private List<Item> _models;

        public EventHandler OnItemSelected { get; set; }

        public EventHandler OnPageChanged { get; set; }

        public virtual List<Item> Models
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                _models = value;
            }
            get
            {
                return _models;
            }
        }

        public CollectionViewDelegate(UIPageControl pageControl)
            : base()
        {
            _pageControl = pageControl;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (OnItemSelected != null)
            {
                OnItemSelected(indexPath.Row - 1, null);
            }
        }

        public override void Scrolled(UIScrollView swipeView)
        {
            ScrollInfinitely(swipeView);

            SetCurrentPage(swipeView);

            foreach (UICollectionViewCell item in ((UICollectionView)swipeView).VisibleCells)
            {
                ImageCell cell = (ImageCell)item;
                cell.ImageOffset = new CGPoint((swipeView.ContentOffset.X - cell.Frame.X) / swipeView.Frame.Width * SPEED_SCROLLING, 0);
            }
        }

        private int SetCurrentPage(UIScrollView _swipeView)
        {
            var page = (int)(_swipeView.ContentOffset.X / _swipeView.Frame.Size.Width) - 1;
            if (page < 0)
            {
                page = 0;
            }

            _pageControl.CurrentPage = page;
            return page;
        }

        private void ScrollInfinitely(UIScrollView scrollView)
        {
            if (Models == null)
            {
                return;
            }

            UICollectionView collectionView = ((UICollectionView)scrollView);
            nfloat contentOffsetWhenFullyScrolledRight = collectionView.Frame.Size.Width * ((Models.Count + 2) - 1);

            if (scrollView.ContentOffset.X == contentOffsetWhenFullyScrolledRight)
            {
                NSIndexPath newIndexPath = NSIndexPath.FromItemSection(1, 0);
                collectionView.ScrollToItem(newIndexPath, UICollectionViewScrollPosition.Left, false);
            }
            else if (scrollView.ContentOffset.X == 0)
            {
                NSIndexPath newIndexPath = NSIndexPath.FromItemSection((Models.Count + 2) - 2, 0);
                collectionView.ScrollToItem(newIndexPath, UICollectionViewScrollPosition.Left, false);
            }
        }
    }
}
