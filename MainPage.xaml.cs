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
            UpdateButtonOpacity(oneDollarConvertDown, oneDollarCount, 1.0);
            UpdateButtonOpacity(fiftyCentConvertDown, fiftyCentCount, 1.0);
            UpdateButtonOpacity(fiftyCentConvertUp, fiftyCentCount, 2.0);
            UpdateButtonOpacity(tenCentConvertDown, tenCentCount, 1.0);
            UpdateButtonOpacity(tenCentConvertUp, tenCentCount, 5.0);
            UpdateButtonOpacity(fiveCentConvertUp, fiveCentCount, 2.0);

            UpdateCoinAmount(oneDollarAmount, oneDollarCount);
            UpdateCoinAmount(fiftyCentAmount, fiftyCentCount);
            UpdateCoinAmount(tenCentAmount, tenCentCount);
            UpdateCoinAmount(fiveCentAmount, fiveCentCount);

            UpdateCoinTotal(oneDollarTotal, oneDollarCount, 1.0, 1.0);
            UpdateCoinTotal(fiftyCentTotal, fiftyCentCount, 2.0, 50);
            UpdateCoinTotal(tenCentTotal, tenCentCount, 10.0, 10);
            UpdateCoinTotal(fiveCentTotal, fiveCentCount, 20.0, 5);

            UpdateTotalLabel();
        }

        private void UpdateButtonOpacity(Button button, double coinCount, double threshold)
        {
            button.Opacity = coinCount <= 0.0 ? 0.5 : coinCount >= threshold ? 1.0 : 0.5;
        }

        private void UpdateCoinAmount(Label label, double coinCount)
        {
            label.Text = $"({coinCount.ToString("0")})";
        }

        private void UpdateCoinTotal(Label label, double coinCount, double divisor, double multiplier)
        {
            double total = coinCount / divisor;
            label.Text = total >= 1.0 ? $"${total.ToString("0.00")}c" : $"{(coinCount * multiplier).ToString()}c";
        }

        private void UpdateTotalLabel()
        {
            double totalValue = oneDollarCount + (fiftyCentCount / 2.0) + (tenCentCount / 10.0) + (fiveCentCount / 20.0);
            totalLabel.Text = $"${totalValue.ToString("0.00")}c";
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