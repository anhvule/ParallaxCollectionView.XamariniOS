
using System;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ParallaxViewPager.iOS
{
    public partial class ImageCell : UICollectionViewCell
    {
        private bool _isInited = false;
        private UIImage _image;
        private string _imageUrl;
        private CGPoint _imageOffset;

        public static readonly UINib Nib = UINib.FromName("ImageCell", NSBundle.MainBundle);
        public static readonly NSString Key = new NSString("ImageCell");

        public string ImageName
        {
            get
            {
                return _imageUrl;
            }

            set
            {
                _imageUrl = value;

                if (imageView != null)
                {
                    imageView.Image = UIImage.FromFile(value);
                }
            }
        }

        // Change Image Frame to make parallax effect
        public CGPoint ImageOffset
        {
            get
            {
                return _imageOffset;
            }

            set
            {
                _imageOffset = value;
                imageView.Frame = new CGRect(value.X, value.Y, imageView.Frame.Width, imageView.Frame.Height);
            }
        }

        public Item Vm { get; set; }


        public ImageCell(IntPtr handle)
            : base(handle)
        {
        }

        public static ImageCell Create()
        {
            return (ImageCell)Nib.Instantiate(null, null)[0];
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (!_isInited)
            {
                imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
                imageView.ClipsToBounds = false;

                _isInited = true;
            }

        }
    }
}

