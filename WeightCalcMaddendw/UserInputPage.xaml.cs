namespace WeightCalcMaddendw;

public partial class UserInputPage : ContentPage
{
    string selectedGender = "";

    public UserInputPage()
    {
        InitializeComponent();
    }

    private void OnWeightChanged(object sender, ValueChangedEventArgs e)
    {
        WeightLabel.Text = $"{Math.Round(e.NewValue)} lbs";
    }

    private void OnHeightChanged(object sender, ValueChangedEventArgs e)
    {
        HeightLabel.Text = $"{Math.Round(e.NewValue)} in";
    }

    private void OnMaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Male";
        MaleImage.Opacity = 1;
        FemaleImage.Opacity = 0.5;
    }

    private void OnFemaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Female";
        FemaleImage.Opacity = 1;
        MaleImage.Opacity = 0.5;
    }

    private async void OnCalculateClicked(object sender, EventArgs e)
    {
        double weight = WeightSlider.Value;
        double height = HeightSlider.Value;

        if (height == 0 || selectedGender == "")
        {
            await DisplayAlert("Error", "Please select gender and valid height.", "OK");
            return;
        }

        double bmi = (weight / (height * height)) * 703;

        await Navigation.PushAsync(
            new BMIResultPage(bmi, selectedGender)
        );
    }
}