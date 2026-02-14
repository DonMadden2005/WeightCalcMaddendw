namespace WeightCalcMaddendw;

public partial class RecommendationsPage : ContentPage
{
    public RecommendationsPage(string category, string gender)
    {
        InitializeComponent();

        RecommendationLabel.Text = GetRecommendations(category, gender);
    }

    private string GetRecommendations(string category, string gender)
    {
        if (category == "Underweight")
            return $"{gender}: Increase calorie intake and strength training.";
        else if (category == "Normal")
            return $"{gender}: Maintain balanced diet and regular exercise.";
        else if (category == "Overweight")
            return $"{gender}: Increase cardio and monitor calorie intake.";
        else
            return $"{gender}: Consult a healthcare provider and adopt structured diet and exercise plan.";
    }

    private async void OnBackToResultsClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnBackToInputClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}