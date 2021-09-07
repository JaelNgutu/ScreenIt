using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641


namespace ScreenIT_Lite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        private MediaCapture mCap;

        bool isPressing = false;

        Point Origin = new Point();

        Brush brushColor = new SolidColorBrush(Colors.Red);
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

           
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            if (btnRecord.IsChecked.HasValue && btnRecord.IsChecked.Value)
            {
                // Initialization - Set the current screen as input
                var scrCaptre = ScreenCapture.GetForCurrentView();

                mCap = new MediaCapture();
                await mCap.InitializeAsync(new MediaCaptureInitializationSettings
                {
                    VideoSource = scrCaptre.VideoSource,
                    AudioSource = scrCaptre.AudioSource,
                });

                // Start Recording to a File and set the Video Encoding Quality
                var file = await GetScreenRecVdo();
                await mCap.StartRecordToStorageFileAsync(MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto), file);
            }
            else
            {
                await StopRecording();
            }
        }

        private async Task StopRecording()
        {
            // Stop recording and dispose resources
            if (mCap != null)
            {
                await mCap.StopRecordAsync();
                mCap.Dispose();
                mCap = null;
            }
        }


        //Create File for Recording on Phone/Storage
        private static async Task<StorageFile> GetScreenRecVdo(CreationCollisionOption creationCollisionOption = CreationCollisionOption.GenerateUniqueName)
        {
            return await KnownFolders.SavedPictures.CreateFileAsync("ScreenRecording.mp4", creationCollisionOption);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
        }

       
        private void Pressed(object sender, PointerRoutedEventArgs e)
        {
            isPressing = true;

            Origin = e.GetCurrentPoint(MainCanvas).Position;
        }

        private void Moved(object sender, PointerRoutedEventArgs e)
        {
            if (isPressing == true)
            {
                Point p2 = e.GetCurrentPoint(MainCanvas).Position;

                if (FindDistance(Origin, p2) > 10)
                {
                    Line Line1 = new Line();
                    Line1.X1 = Origin.X;
                    Line1.Y1 = Origin.Y;

                    Line1.X2 = p2.X;
                    Line1.Y2 = p2.Y;

                    Line1.StrokeThickness = 5;
                    Line1.Stroke = (brushColor);

                    MainCanvas.Children.Add(Line1);

                    Origin = p2;
                }
            }
        }

        public double FindDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void Released(object sender, PointerRoutedEventArgs e)
        {
            isPressing = false;
        }

        


    }
}
