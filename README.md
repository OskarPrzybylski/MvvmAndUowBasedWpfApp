# MvvmAndUowBasedWpfApp
## Short description
Wpf application based on MVVM and Unit Of Work pattern. MahApps.Metro([link](https://github.com/MahApps/MahApps.Metro)) added to project in case of modern UI.
## How to add new entity?
1. Just add entity class in Entities folder.

~~~~
public class YourEntity : DbEntity{

//your properites

}
~~~~

2. Create repository for your entity.

~~~~
public class YourEntitiesRepository : GenericRepository<YourEntity>{

//Add here your methods

}
~~~~

3. Add DbSet in DatabaseContext.cs.

~~~~
DbSet<YourEntity> Yourentities {get; set;}
~~~~

4. Add repository field and property in UnitOfWork.cs.

~~~~
public YourEntitiesRepository YourEntitiesRepository
        {
            get
            {
                if (this._yourEntitiesRepository == null)
                {
                    this._yourEntitiesRepository = new YourEntitiesRepository(_databaseContext);
                }

                return _yourEntitiesRepository;
            }
        }
~~~~

5. Done! :)

## How to add new View? 

1. Add new window in Views folder ( Window (WPF) )

2. In YourWindowWindow.xaml.cs class should inherit from: MetroWindow

~~~~
public partial class YourWindowWindow : MetroWindow
    {
        public YourWindowWindow()
        {
            InitializeComponent();
        }
    }
~~~~

3. In YourWindowWindow.xaml add line: DataContext="{Binding YourWindow, Source={StaticResource Locator}}" and xmlns:Controls="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro"

~~~~
<Controls:MetroWindow x:Class="MvvmAndUowBasedWpfApp.Views.YourWindowWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MvvmAndUowBasedWpfApp"
        xmlns:Controls="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro"
        mc:Ignorable="d"
        Title="YourWindowWindow" Height="450" Width="800"
        DataContext="{Binding Main, Source={StaticResource Locator}}">
    <Grid>
        
    </Grid>
</Controls:MetroWindow>
~~~~

Your main class here should be also of type: Controls:MetroWindow 

4. Add YourWindowViewModel.cs in ViewModels folder.

~~~~
public class YourWindowViewModel : ViewModelBase
    {
        public YourWindowViewModel()
        {
            
        }
    }
~~~~

5. Add new property in Locator:
~~~~
public YourWindowViewModel YourWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<YourWindowViewModel>();
            }
        }
~~~~

6. Done! :)

## How to use binding in this project? 

1. Add new field and property in YourWindowViewModel.cs
~~~~
private string password;
public string Password
                     {
                        get
                        {
                                return password;
                        }
                        set
                        {
                                if (value != password)
                                {
                                        password = value;
                                        RaisePropertyChanged("Password");
                                }
                        }
                     }   
~~~~

2. Bind it in yourWindowWindow.xaml with this line:
~~~~
{Binding Password,Mode=TwoWay}
~~~~

3. Done! :)
## How to create commands in this project? 

1. Create new property in yourWindowViewModel.cs
~~~~
public RelayCommand YourCommand { get; private set; }
~~~~

2. Initialize your property in constructor with function:
~~~~
YourCommand = new RelayCommand(() => YourFunction());
~~~~

3. Bind it in YourWindowWindow.xaml with this line:
~~~~
Command='{Binding YourCommand}'
~~~~

4. Done! :)
