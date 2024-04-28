using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Runtime.Versioning;
using static Android.Resource;
using Activity = Android.App.Activity;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

namespace TripExpenseManager
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GlobalLayoutUtil.AssistActivity(this);
        }
    }

    public class GlobalLayoutUtil
    {
        private bool isImmersed = false;
       private View mChildOfContent;
       private FrameLayout.LayoutParams frameLayoutParams;
       private int usableHeightPrevious = 0;

        public static void AssistActivity(Activity activity)
        {
            _ = new GlobalLayoutUtil(activity);
        }

        public GlobalLayoutUtil(Activity activity)
        {       
            FrameLayout content = (FrameLayout)activity.FindViewById(Id.Content);
            mChildOfContent = content.GetChildAt(0);
            mChildOfContent.ViewTreeObserver.GlobalLayout += (s, o) => PossiblyResizeChildOfContent();
            frameLayoutParams = (FrameLayout.LayoutParams)mChildOfContent?.LayoutParameters;
        }

        private void PossiblyResizeChildOfContent()
        {
            int usableHeightNow = ComputeUsableHeight();
            if (usableHeightNow != usableHeightPrevious)
            {
                int usableHeightSansKeyboard = mChildOfContent.RootView.Height;
                int heightDifference = usableHeightSansKeyboard - usableHeightNow;

                if (heightDifference < 0)
                {
                    usableHeightSansKeyboard = mChildOfContent.RootView.Width;
                    heightDifference = usableHeightSansKeyboard - usableHeightNow;
                }

                if (heightDifference > usableHeightSansKeyboard / 4)
                {
                    frameLayoutParams.Height = usableHeightSansKeyboard - heightDifference;
                }
                else
                {
                    frameLayoutParams.Height = usableHeightNow;
                }
            }

            mChildOfContent.RequestLayout();
            usableHeightPrevious = usableHeightNow;
        }

        private int ComputeUsableHeight()
        {
            Rect rect = new Rect();
            mChildOfContent.GetWindowVisibleDisplayFrame(rect);
            if (isImmersed)
            {
                return rect.Bottom;
            }
            else
            {
                return rect.Bottom - rect.Top;
            }
        }

        private int GetNavigationBarHeight(Context context)
        {
            int result = 0;
            Resources resources = context.Resources;
            int resourceId = resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                result = resources.GetDimensionPixelSize(resourceId);
            }
            return result;
        }       
    }
}
