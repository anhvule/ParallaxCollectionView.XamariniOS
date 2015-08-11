using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using System.Collections.ObjectModel;

namespace ParallaxViewPager.iOS
{
    public class CollectionViewSource : UICollectionViewDataSource
    {
        protected List<Item> _models;
        protected UICollectionView _collectionView;


        // Set up Item List to make scrolling infinitely
        // Reference: http://adoptioncurve.net/archives/2013/07/building-a-circular-gallery-with-a-uicollectionview/
        public virtual List<Item> Models
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                if (_models != null)
                {
                    _models.Clear();
                }

                if (value.Count > 1)
                {
                    _models.Add(value[value.Count - 1]);
                    foreach (var campaign in value)
                    {
                        _models.Add(campaign);
                    }

                    _models.Add(value[0]);
                }
                else if (value.Count == 1)
                {
                    _models.Add(value[0]);
                }

                _collectionView.ReloadData();
            }
            get
            {
                return _models;
            }
        }

        public CollectionViewSource(UICollectionView collectionView)
        {
            _collectionView = collectionView;
            _models = new List<Item>();
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return _models.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            ImageCell cell = (ImageCell)collectionView.DequeueReusableCell(ImageCell.Key, indexPath);
            if (cell == null)
            {
                cell = ImageCell.Create();
            }

            cell.Vm = _models[indexPath.Row];
            cell.ImageName = _models[indexPath.Row].ImageUrl;

            // To make sure no space between cells
            if (((UICollectionViewFlowLayout)collectionView.CollectionViewLayout).ItemSize.Width != collectionView.Frame.Width)
            {
                ((UICollectionViewFlowLayout)collectionView.CollectionViewLayout).ItemSize = new CGSize(collectionView.Frame.Width, collectionView.Frame.Height);
                cell.Frame = new CGRect(cell.Frame.X, cell.Frame.Y, collectionView.Frame.Width, collectionView.Frame.Height);
            }

            cell.ImageOffset = new CGPoint((collectionView.ContentOffset.X - cell.Frame.X) / collectionView.Frame.Width * 120, 0);

            return (ImageCell)cell;
        }
    }
}

