namespace WeightCalcMaddendw;

public partial class BMIResultPage : ContentPage
{
    double bmi;
    string gender;
    string category;

    public BMIResultPage(double bmiValue, string userGender)
    {
        InitializeComponent();

        bmi = bmiValue;
        gender = userGender;

        BmiValueLabel.Text = bmi.ToString("F1");

        category = GetBMICategory(bmi, gender);
        CategoryLabel.Text = $"Category: {category}";
    }

    private string GetBMICategory(double bmi, string gender)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi < 25)
            return "Normal";
        else if (bmi < 30)
            return "Overweight";
        else
            return "Obese";
    }

    private async void OnRecommendationsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new RecommendationsPage(category, gender)
        );
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}