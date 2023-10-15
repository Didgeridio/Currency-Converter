namespace Currency
{
    public partial class MainPage : ContentPage
    {
        double oneDollarCount = 0;
        double fiftyCentCount = 0;
        double tenCentCount = 0;
        double fiveCentCount = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void Refresh_UI()
        {
            if (oneDollarCount <= 0)
            {
                oneDollarCount = 0;
                oneDollarConvertDown.Opacity = 0.5;
            }
            if (oneDollarCount >= 1)
            {
                oneDollarConvertDown.Opacity = 1;
            }
            if (fiftyCentCount <= 0)
            {
                fiftyCentCount = 0;
                fiftyCentConvertDown.Opacity = 0.5;
                fiftyCentConvertUp.Opacity = 0.5;
            }
            if (fiftyCentCount >= 1)
            {
                if (fiftyCentCount >= 2)
                {
                    fiftyCentConvertUp.Opacity = 1;
                    fiftyCentConvertDown.Opacity = 1;
                }
                else
                {
                    fiftyCentConvertDown.Opacity = 1;
                    fiftyCentConvertUp.Opacity = 0.5;
                }
            }
            if (tenCentCount <= 0)
            {
                tenCentCount = 0;
                tenCentConvertDown.Opacity = 0.5;
                tenCentConvertUp.Opacity = 0.5;
            }
            if (tenCentCount >= 1)
            {
                if (tenCentCount >= 5)
                {
                    tenCentConvertUp.Opacity = 1;
                    tenCentConvertDown.Opacity = 1;
                }
                else
                {
                    tenCentConvertDown.Opacity = 1;
                    tenCentConvertUp.Opacity = 0.5;
                }
            }
            if (fiveCentCount <= 0)
            {
                fiveCentCount= 0;
                fiveCentConvertDown.Opacity = 0.5;
                fiveCentConvertUp.Opacity = 0.5;
            }
            if (fiveCentCount >= 2)
            {
                fiveCentConvertUp.Opacity = 1;
            }
            oneDollarAmount.Text = "(" + Convert.ToString(oneDollarCount) + ")";
            oneDollarTotal.Text = "$ " + Convert.ToString(oneDollarCount);
            fiftyCentAmount.Text = "(" + Convert.ToString(fiftyCentCount) + ")";
            if (fiftyCentCount > 1)
            {
                fiftyCentTotal.Text = "$" + (fiftyCentCount / 2.0).ToString("0.00") + "c";
            }
            else
            {
                fiftyCentTotal.Text = Convert.ToString(fiftyCentCount * 50) + "c";
            }
            tenCentAmount.Text = "(" + Convert.ToString(tenCentCount) + ")";
            if (tenCentCount > 9)
            {
                tenCentTotal.Text = "$" + (tenCentCount / 10.0).ToString("0.00") + "c";
            }
            else
            {
                tenCentTotal.Text = Convert.ToString(tenCentCount * 10) + "c";
            }
            fiveCentAmount.Text = "(" + Convert.ToString(fiveCentCount) + ")";
            if (fiveCentCount > 19)
            {
                fiveCentTotal.Text = "$" + (fiveCentCount / 20.0).ToString("0.00") + "c";
            }
            else
            {
                fiveCentTotal.Text = Convert.ToString(fiveCentCount * 5) + "c";
            }
            totalLabel.Text = "$" + (oneDollarCount +
               (fiftyCentCount / 2) +
               (tenCentCount / 10) +
               (fiveCentCount / 20)).ToString("0.00") + "c"; 
        }
        private void OneDollarPlusButton_Clicked(object sender, EventArgs e)
        {
            oneDollarCount++;
            Refresh_UI();
        }
        private void OneDollarMinusButton_Clicked(object sender, EventArgs e)
        {
            oneDollarCount--;
            Refresh_UI();
        }

        private void FiftyCentPlusButton_Clicked(object sender, EventArgs e)
        {
            fiftyCentCount++;
            Refresh_UI();
        }

        private void FiftyCentMinusButton_Clicked(object sender, EventArgs e)
        {
            fiftyCentCount--;
            Refresh_UI();
        }

        private void TenCentPlusButton_Clicked(object sender, EventArgs e)
        {
            tenCentCount++;
            Refresh_UI();
        }

        private void TenCentMinusButton_Clicked(object sender, EventArgs e)
        {
            tenCentCount--;
            Refresh_UI();
        }

        private void FiveCentPlusButton_Clicked(object sender, EventArgs e)
        {
            fiveCentCount++;
            Refresh_UI();
        }

        private void FiveCentMinusButton_Clicked(object sender, EventArgs e)
        {
            fiveCentCount--;
            Refresh_UI();
        }

        private void OneDollarConvertDown_Clicked(object sender, EventArgs e)
        {
            if(oneDollarCount - 1 >= 0)
            {
                oneDollarCount--;
                fiftyCentCount += 2;
                Refresh_UI();
            }
        }

        private void FiftyCentConvertDown_Clicked(object sender, EventArgs e)
        {
            if(fiftyCentCount - 1 >= 0)
            {
                fiftyCentCount --;
                tenCentCount += 5;
                Refresh_UI();
            }
        }

        private void FiftyCentConvertUp_Clicked(object sender, EventArgs e)
        {
            if(fiftyCentCount - 2 >= 0)
            {
                fiftyCentCount -= 2;
                oneDollarCount ++;
                Refresh_UI();
            }
        }

        private void TenCentConvertDown_Clicked(object sender, EventArgs e)
        {
            if(tenCentCount - 1 >= 0)
            {
                tenCentCount --;
                fiveCentCount += 2;
                Refresh_UI();
            }
        }

        private void TenCentConvertUp_Clicked(object sender, EventArgs e)
        {
            if(tenCentCount - 5 >= 0)
            {
                tenCentCount -= 5;
                fiftyCentCount ++;
                Refresh_UI();
            }
        }

        private void FiveCentConvertUp_Clicked(object sender, EventArgs e)
        {
            if(fiveCentCount - 2 >= 0)
            {
                fiveCentCount -= 2;
                tenCentCount ++;
                Refresh_UI();
            }
        }
    }
}