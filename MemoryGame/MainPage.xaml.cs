using System.Runtime.Versioning;

namespace MemoryGame
{
    public partial class MainPage : ContentPage
    {
        string[] Paths = { "placeholderimgone.png", "placeholderimgtwo.png" };
        string[] BtnNames = { "One", "Two", "Three", "Four", "Five", "Six","Seven","Eight","Nine","Ten","Elev","Tvel" };
        int BtnOneNum;
        int BtnTwoNum;
        string BtnOneSrc;
        string BtnTwoSrc;
        ImageButton BtnOne;
        ImageButton BtnTwo;
        int[] BtnNumbs = new int[12];
        Random rnd = new Random();
        string ImgPath = "";
        public MainPage()
        {
            InitializeComponent();
            for(int i = 0; i < BtnNumbs.Length;i++)
                BtnNumbs[i] = rnd.Next(0, 2);
        }

        private async void OnBtnClicked(object sender, EventArgs e)
        {
            if (ImgPath == "")
            {
                BtnOne = (ImageButton)sender;
                for (int i = 0; i<BtnNames.Length;i++)
                {
                    if (BtnOne.CommandParameter.ToString() == BtnNames[i])
                    {
                        BtnOneNum = i;
                        ImgPath = Paths[BtnNumbs[BtnOneNum]];
                        BtnOne.Source = ImgPath;
                        BtnOneSrc = ImgPath;
                        BtnOne.IsEnabled = false;
                        break;
                    }

                }
            }
            else
            {
                BtnTwo = (ImageButton)sender;
                for (int i = 0; i < BtnNames.Length; i++)
                {
                    if (BtnTwo.CommandParameter.ToString() == BtnNames[i])
                    {
                        BtnTwoNum = i;
                        ImgPath = Paths[BtnNumbs[BtnTwoNum]];
                        BtnTwo.Source = ImgPath;
                        BtnTwoSrc = ImgPath;
                        BtnTwo.IsEnabled = false;
                        BtnTwo.Source = ImgPath;
                        break;
                    }

                }
                if (BtnOneSrc == BtnTwoSrc)
                {
                    await Task.Delay(1000);
                    BtnOne.IsVisible = false;
                    BtnTwo.IsVisible = false;
                    ImgPath = "";
                }
                else
                {
                    BtnOne.IsEnabled = false;
                    BtnTwo.IsEnabled = false;
                    ImgPath = "";
                    await Task.Delay(1000);
                    BtnOne.Source = "placeholderimg.png";
                    BtnTwo.Source = "placeholderimg.png";
                    BtnOne.IsEnabled = true;
                    BtnTwo.IsEnabled = true;
                }
            }
            /*else
            {
                BtnTwo = (ImageButton)sender;
                BtnTwo.Source = "placeholderimgtwo.png";
                for (int i = 0; i < BtnNames.Length; i++)
                {
                    if (BtnTwo.CommandParameter.ToString() == BtnNames[i])
                    {
                        BtnTwoNum = i;
                        ImgPath = Paths[BtnNumbs[BtnOneNum]];
                        BtnTwo.Source = ImgPath;
                        BtnTwo.IsEnabled = false;
                        break;
                    }
                }
                if (BtnOneSrc == BtnTwoSrc)
                {
                    BtnOne.IsVisible = false;
                    BtnTwo.IsVisible = false;
                    ImgPath = "";

                }
                else
                {
                    BtnOne.IsEnabled = false;
                    BtnTwo.IsEnabled = false;
                    ImgPath = "";
                    System.Threading.Thread.Sleep(1000);
                    BtnOne.Source = "placeholderimg.png";
                    BtnTwo.Source= "placeholderimg.png";
                    BtnOne.IsEnabled = true;
                    BtnTwo.IsEnabled = true;
                }
            }*/
        }
    }
}