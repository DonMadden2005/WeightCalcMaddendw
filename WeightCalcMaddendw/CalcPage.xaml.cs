using System;

namespace WeightCalcMaddendw;

public partial class CalcPage : ContentPage
{
    string selectedGender = "Male";

    public CalcPage()
    {
        InitializeComponent();
        MaleFrame.BorderColor = Colors.Blue;
    }

    private void MaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Male";
        MaleFrame.BorderColor = Colors.Blue;
        FemaleFrame.BorderColor = Colors.Transparent;
    }

    private void FemaleTapped(object sender, EventArgs e)
    {
        selectedGender = "Female";
        FemaleFrame.BorderColor = Colors.Pink;
        MaleFrame.BorderColor = Colors.Transparent;
    }

    private void SliderChanged(object sender, ValueChangedEventArgs e)
    {
        HeightLabel.Text = ((int)HeightSlider.Value).ToString();
        WeightLabel.Text = ((int)WeightSlider.Value).ToString();
    }

    private async void CalculateBMI_Clicked(object sender, EventArgs e)
    {
        double weight = WeightSlider.Value;
        double height = HeightSlider.Value;

        if (height == 0)
        {
            await DisplayAlert("Error", "Height must be greater than zero.", "OK");
            return;
        }

        double bmi = (weight * 703) / (height * height);

        string status = GetBMIStatus(bmi);
        string recommendation = GetRecommendation(status);

        string result =
            $"Your calculated BMI results are:\n\n" +
            $"Gender: {selectedGender}\n" +
            $"BMI: {bmi:F1}\n" +
            $"Health Status: {status}\n" +
            $"Recommendations:\n{recommendation}";

        await DisplayAlert("BMI Results", result, "OK");
    }

    private string GetBMIStatus(double bmi)
    {
        if (selectedGender == "Male")
        {
            if (bmi < 18.5) return "Underweight";
            if (bmi < 25) return "Normal weight";
            if (bmi < 30) return "Overweight";
            return "Obese";
        }
        else
        {
            if (bmi < 18) return "Underweight";
            if (bmi < 24) return "Normal weight";
            if (bmi < 29) return "Overweight";
            return "Obese";
        }
    }

    private string GetRecommendation(string status)
    {
        switch (status)
        {
            case "Underweight":
                return "Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). " +
                       "Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";

            case "Normal weight":
                return "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active " +
                       "with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";

            case "Overweight":
                return "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises " +
                       "(e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";

            case "Obese":
                return "Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). " +
                       "Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. " +
                       "Avoid sugary drinks and maintain a consistent sleep schedule.";

            default:
                return "";
        }
    }
}