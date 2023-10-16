using System.Runtime.Versioning;

namespace MemoryGame
{
    public partial class MainPage : ContentPage
    {
        string[] Paths = { "placeholderimgone.png", "placeholderimgtwo.png", "placeholderimgthree.png" };
        string[] BtnNames = { "One", "Two", "Three", "Four", "Five", "Six"};
        int BtnOneNum;
        int BtnTwoNum;
        string BtnOneSrc;
        string BtnTwoSrc;
        ImageButton BtnOne;
        ImageButton BtnTwo;
        int[] BtnNumbs = new int[6];
        Random rnd = new Random();
        string ImgPath = "";
        
        public MainPage()
        {
            InitializeComponent();
            NewRandom();
        }
        public void NewRandom()
        {
            int BtnTypeA = 0;
            int BtnTypeB = 0;
            int BtnTypeC = 0;
            for (int i = 0; i < BtnNumbs.Length; i++)
            {
                //BtnNumbs[i]
                One.Source = "placeholderimg.png";
                One.IsEnabled = true;
                One.IsVisible = true;
                Two.Source = "placeholderimg.png";
                Two.IsEnabled = true;
                Two.IsVisible = true;
                Three.Source = "placeholderimg.png";
                Three.IsEnabled = true;
                Three.IsVisible = true;
                Four.Source = "placeholderimg.png";
                Four.IsEnabled = true;
                Four.IsVisible = true;
                Five.Source = "placeholderimg.png";
                Five.IsEnabled = true;
                Five.IsVisible = true;
                Six.Source = "placeholderimg.png";
                Six.IsEnabled = true;
                Six.IsVisible = true;
                int a = rnd.Next(0, 3);
                if (BtnTypeA < 2 && a == 0)
                {
                    BtnNumbs[i] = a;
                    BtnTypeA++;
                }
                else if (BtnTypeB < 2 && a == 1)
                {
                    BtnNumbs[i] = a;
                    BtnTypeB++;
                }
                else if (BtnTypeC < 2 && a == 2)
                {
                    BtnNumbs[i] = a;
                    BtnTypeC++;
                }
                else
                    i--;
            }
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
                    await Task.Delay(500);
                    BtnOne.IsVisible = false;
                    BtnTwo.IsVisible = false;
                    ImgPath = "";
                    
                }
                else
                {
                    BtnOne.IsEnabled = false;
                    BtnTwo.IsEnabled = false;
                    ImgPath = "";
                    await Task.Delay(500);
                    BtnOne.Source = "placeholderimg.png";
                    BtnTwo.Source = "placeholderimg.png";
                    BtnOne.IsEnabled = true;
                    BtnTwo.IsEnabled = true;
                    
                    
                }
                if (One.IsVisible == false && One.IsVisible == Two.IsVisible && One.IsVisible == Three.IsVisible && One.IsVisible == Four.IsVisible && One.IsVisible == Five.IsVisible && One.IsVisible == Six.IsVisible)
                {
                    Victory.Text = "WYGRALES!";
                    SemanticScreenReader.Announce(Victory.Text);
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