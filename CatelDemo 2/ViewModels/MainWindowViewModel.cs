namespace CatelDemo1.ViewModels
{
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        //поле для получения сервиса, которым будем запускать диалоговое окно
        private readonly IUIVisualizerService mIUIVisualizerService;
        //
        private readonly IMessageService mIMessageService;
        //IUIVisualizerService uiVisualizerService = ServiceLocator.Default.ResolveType<IUIVisualizerService>();

        public MainWindowViewModel(IUIVisualizerService _iUIVisualizerService, IMessageService _imessageService)
        {
            //инициализируем и регистрируем сервисы

            mIUIVisualizerService = _iUIVisualizerService;
            mIUIVisualizerService.Register(typeof(DialogViewModel), typeof(DialogView));

            mIMessageService = _imessageService;
        }

        public override string Title { get { return "CatelDemo1"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
        //команда для вызова обработчика клика по кнопке
        public Command ShowDialogCommand
        {
            get
            {
                return new Command(() =>
                {
                    //показываем диалоговое окно при помощи сервиса
                    //mIUIVisualizerService.ShowDialog(new CatelDemo1.ViewModels.DialogViewModel());
                    //uiVisualizerService.Show(new ViewModels.DialogViewModel());

                    //показываем диалоговое окно при помощи сервиса,
                    //ожидаем возвращаемый им результат
                    var dialogViewModel = new CatelDemo1.ViewModels.DialogViewModel();
                    if (mIUIVisualizerService.ShowDialog(dialogViewModel) == true
                        && dialogViewModel.name != null)
                    {
                        mIMessageService.ShowInformationAsync(dialogViewModel.name);
                    }
                    else
                    {
                        mIMessageService.ShowErrorAsync("Error!");
                    }
                });
            }
        }

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
