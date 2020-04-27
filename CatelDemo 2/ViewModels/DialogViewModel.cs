namespace CatelDemo1.ViewModels
{
    using Catel.MVVM;
    using Catel.Data;
    using System.Threading.Tasks;

    public class DialogViewModel : ViewModelBase
    {

        public string name
        {
            get { return GetValue<string>(nameProperty); }
            set { SetValue(nameProperty, value); }
        }

        public static readonly PropertyData nameProperty = RegisterProperty("name", typeof(string));

        public DialogViewModel()
        {
        }

        public override string Title { get { return "View model title"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
