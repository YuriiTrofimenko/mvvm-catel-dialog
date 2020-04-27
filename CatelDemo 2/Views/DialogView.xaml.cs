namespace CatelDemo1
{
    using Catel.Windows;
    using ViewModels;

    public partial class DialogView
    {
        public DialogView()
            : this(null) { }

        public DialogView(DialogViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
