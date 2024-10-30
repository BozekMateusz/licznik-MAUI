namespace MauiApp1 { 

    public partial class MainPage : ContentPage {

        private int counterIndex = 1;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnAddCounterClicked(object sender, EventArgs e) {
        
            string enteredName = EnterName.Text?.Trim();
            string counterName = string.IsNullOrEmpty(enteredName) ? $"Counter {counterIndex}" : enteredName;
            AddNewCounter(counterName);
            counterIndex++;
            EnterName.Text = string.Empty;
        }

        private void UpdateCounterLabel(Label countLabel, int count) { 
        
            if(count == 1)
            {
                countLabel.Text = $"Clicked {count} time";
            }
            else{
                countLabel.Text = $"Clicked {count} times";
            }
        }

        private void AddNewCounter(string counterName){

            int count = 0;

            var counterLayout = new StackLayout{
                Orientation = StackOrientation.Horizontal,
                Spacing = 10
            };

            var nameLabel = new Label{

                Text = counterName,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            var counterLabel = new Label{

                Text = $"Clicked {count} times",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            var addButton = new Button
            {
                Text = "+",
            };

            var decreaseButton = new Button
            {
                Text= "-",
            };

            addButton.Clicked += (sender, e) =>{
                count++;
                UpdateCounterLabel(counterLabel, count);
            };

            decreaseButton.Clicked += (sender, e) =>{
                count--;
                UpdateCounterLabel(counterLabel, count);
            };
        
            counterLayout.Children.Add(nameLabel);
            counterLayout.Children.Add(counterLabel);
            counterLayout.Children.Add(addButton);
            counterLayout.Children.Add(decreaseButton);
            CountersContainer.Add(counterLayout);
        
        }
    }
}