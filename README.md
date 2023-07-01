# EFCore_MPS

## Описание
Краткое описание и программная реализация дипломного проекта на тему "Разработка программного средства по управлению материально-производственными запасами (MPS) предприятия на основе метода Agile FDD"

### Методология разработки
Agile FDD - гибкая методология разработки, главной особенностью которой является концентрации на функциональности разрабатываемого программного решения. Agile FDD разделяет процесс разработки на 5 этапов:
![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/21d07e71-976c-459a-8ad6-5ff3fc9c7f33)
1. Создание общей модели
    - определение основных требований стейкхолдеров, проектирование ключевых бизнес-процессов предприятия в модели AS-IS
2. Составление списка функциональных возможностей
    - на основе построенной общей модели и определенных пользовательских требований, строится список функциональных возможностей, которые должен реализовывать программное средство
3. Планирование функций
    - составление плана разработки и разбиение функциональных возможностей на итерации разработки
4. Проектирование функционалных возможностей
    - построение бизнес-процессов в модели TO-BE, проектирование схемы баз данных и построение карты приложения, для функциональных возможностей определенных в каждой итерации
5. Реализация функциональных возможностей

### Создание общей модели
Фрагмент описания ключевых бизнес-процессов в модели AS-IS в нотации SLD

![Зарегистрировать МПЗ-1_2](https://github.com/N1kich/EFCore_MPS/assets/85256461/bc779b9f-d072-4469-b7f0-05b399fcb58c)

![1_2_5](https://github.com/N1kich/EFCore_MPS/assets/85256461/289592ff-4b5a-462c-8d90-21069a7d4f7d)

![2_3(1)](https://github.com/N1kich/EFCore_MPS/assets/85256461/b2c241c3-3c30-4888-8ad9-a18895c6e739)

![2_3](https://github.com/N1kich/EFCore_MPS/assets/85256461/b6f7b1eb-10f4-4521-9eee-d93d3ba1942b)

![3_1](https://github.com/N1kich/EFCore_MPS/assets/85256461/b6995bc3-effa-4609-96df-bd9d87099135)

#### Карта бизнес-процессов AS-IS на этапа составления общей модели

![Зарегистрировать МПЗ-Карта процессов_AS_IS](https://github.com/N1kich/EFCore_MPS/assets/85256461/6088adb9-4341-4441-8d35-91b1e66fb0fb)

### Составление списка функциональных возможностей 

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/dec2b7a7-1e26-49c6-af2f-9d082de1f3e6)

### Планирование функций (1-я итерация)
Составление плана разработки (ранжирование, группировка, распределение функциональных возможностей по итерациям)

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/84f09fe6-6c09-4eff-b1d0-05791f2b68b5)

### Проектирование функциональных возможностей

#### Описание бизнес-процессов TO-BE

![Зарегистрировать МПЗ-1_2 TO-BE](https://github.com/N1kich/EFCore_MPS/assets/85256461/80f5e0f5-d1ba-406c-a7a7-604a1a4999e0)

![Зарегистрировать МПЗ-1 2 3 TO-BE](https://github.com/N1kich/EFCore_MPS/assets/85256461/ce7d0c37-7db4-44fd-9a25-53525edd51c6)

#### Построение схемы баз данных в 3-й НФ

##### Классы данных 

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/0958d53a-0098-42fd-a0b1-05ff55851bb6)

##### Схема базы данных

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/e5597d52-2fbc-4d81-8a4a-88b0b5651de9)

##### Построение карты приложения

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/fafa6309-ab7d-4a24-a9df-7b9144db0ab9)

### Реализация функциональных возможностей (1-я итерация)
#### Описание процесса реализации
Для предоставления данных в удобном для пользователя формате. Средствами MS SQL составляется представление (View) на основе базовых таблиц БД. View - виртуальная таблица, являющаяся результатом выполнения запроса к БД, определенного с помощью оператора SELECT, в момент обращения к представлению.

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/6506ef95-de97-4830-92da-b4b56e13804f)

Стандартные операции обновления и вставки новых записей для объекта представления, основывающимся на нескольких базовых таблицах невозможен без потери данных, поэтому в качестве реализации вышеописанных операций применяются триггеры, срабатывающие вместо операций добавления/обновления, , в данном случае таблицу mps. 

Триггеры обновления и добавления записей представлены ниже:
```sql
ALTER TRIGGER [dbo].[CreateNewMpsObject]
ON [dbo].[RegistrationMpsView]
INSTEAD OF INSERT
AS 
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
    SET NOCOUNT ON;

    INSERT INTO mps.dbo.mps (name_mps, code_mps, price_per_unit_mps, expire_date_mps, amount_mps, arrival_date_mps, total_cost_mps, id_type_mps, id_measurements, id_supplier)
    SELECT
        i.Name,
        i.CodeMps,
        i.PricePerUnit,
        i.ExpireDate,
        i.Quantity,
        i.ArrivalDate,
        i.TotalCost,
        tm.id_type_mps,
        umm.id_measurements,
        sm.id_supplier
    FROM
        inserted AS i
        INNER JOIN mps.dbo.type_mps AS tm ON tm.type_mps = i.MpsType
        INNER JOIN mps.dbo.unit_measurements_mps AS umm ON umm.name_measurements = i.MeasureType
        INNER JOIN mps.dbo.supplier_mps AS sm ON sm.name_company = i.Supplier;
END
```

Триггер обновления данных 

```sql
ALTER TRIGGER [dbo].[UpdateMpsTrigger]
   ON  [dbo].[RegistrationMpsView]
   INSTEAD OF UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [dbo].mps
		SET 
			name_mps = IIF(name_mps != Name, Name, name_mps),
			code_mps = IIF(code_mps != CodeMps, CodeMps, code_mps),
			price_per_unit_mps = IIF( price_per_unit_mps != PricePerUnit, PricePerUnit, price_per_unit_mps),
			id_measurements = IIF(mps.id_measurements != umm.id_measurements, umm.id_measurements, mps.id_measurements),
			id_type_mps = IIF(mps.id_type_mps != tm.id_type_mps, tm.id_type_mps, mps.id_type_mps),
			id_supplier = IIF(mps.id_supplier != sm.id_supplier, sm.id_supplier, mps.id_supplier),
			amount_mps = IIF(amount_mps != Quantity, Quantity, amount_mps),
			expire_date_mps = IIF(expire_date_mps != ExpireDate, ExpireDate, expire_date_mps),
			arrival_date_mps = IIF(arrival_date_mps != ArrivalDate, ArrivalDate, arrival_date_mps),
			total_cost_mps = IIF(total_cost_mps != TotalCost, TotalCost, total_cost_mps)
		FROM 
		inserted AS i
        INNER JOIN mps.dbo.type_mps AS tm ON tm.type_mps = i.MpsType
        INNER JOIN mps.dbo.unit_measurements_mps AS umm ON umm.name_measurements = i.MeasureType
        INNER JOIN mps.dbo.supplier_mps AS sm ON sm.name_company = i.Supplier
		WHERE i.id_mps = mps.id_mps;
END
```

#### Реализация программного средства при помощи технологии WPF
Программное средство выполненено при применении паттерна MVVM, где у каждой страницы есть представление, модель данных (EF Core), и модель-представления

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/b9594610-4a92-45ab-8c8f-faff87cdd048)

Функциональность переключения контента реализована при помощи компонента Frame
```csharp
 public RelayCommand<string> ContentNavigationCommand { get; set; }

        private Uri _contentUri;
        public Uri ContentUri { get { return _contentUri; } set { _contentUri = value; OnPropertyChanged(); } }
        public MainViewModel() 
        {
            ContentNavigationCommand = new RelayCommand<string>(SwitchPage);
        }
        /// <summary>
        /// method to switch pages in frameUI
        /// </summary>
        /// <param name="pageName"></param>
        private void SwitchPage(string pageName)
        {
            switch (pageName)
            {
                case "RegisterMpsPage":
                    ContentUri = new Uri("/View/RegisterMps.xaml", UriKind.Relative);
                    break;
                case "DisposalPage":
                    break;
            }
        }
```

Форма отображения данных представления, DataGrid с кастомными ячейками и функциональность по добавлению и обновлению данных в БД представлена ниже 

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/b40b07c7-827b-48c0-a42c-1b35a1010454)

![image](https://github.com/N1kich/EFCore_MPS/assets/85256461/514540e2-a580-408a-9d5c-54bff4c4af0c)

Механизм открытия диалоговых окон реализован при помощи интерфейса и реализующего его класса DialogService

```csharp
  interface IDialogService
    {
        public void ShowDialog(string nameWindow, Action<string,object> callback);
        void ShowDialog(string v);
    }

 class DialogService : IDialogService
    {
       
        /// <summary>
        /// Represents functionality to open dialog window with different xaml-markup
        /// </summary>
        /// <param name="nameWindow"></param>
        /// <param name="callback"></param>
        public void ShowDialog(string nameWindow, Action<string, object> callback)
        {
            var dialog = new DialogWindow();

            EventHandler closeEventHandler= null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString(), dialog.ObjectToDbSave);
                dialog.Closed -= closeEventHandler;
            };

            dialog.Closed += closeEventHandler;

            var type = Type.GetType($"EFCore_MPS.DialogWindows.{nameWindow}");

            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
             
        }

        public void ShowDialog(string v)
        {
            throw new NotImplementedException();
        }
    }
```

Код ViewModel страницы по добавлению новых записей о МПЗ представлен ниже
```csharp
public RelayCommand OpenRegistrationWindowCommand { get; set; }
        public RelayCommand UpdateMpsCommand { get; set; }

        public RelayCommand SearchMpsCommand { get; set; }

        public RelayCommand DisplayAllMpsCommand { get; set; }

        readonly IDialogService _dialogService = new DialogService();

        public List<string> MpsTypeList { get; set; }
        
        public List<string> MpsMeasureList { get; set; }
        public List<string> SupplierList { get; set; }

        RegistrationMpsView _selectedMps;
        public RegistrationMpsView SelectedMps
        {
            get { return _selectedMps; }
            set { _selectedMps = value; OnPropertyChanged(); }
        }

        string _mpsCodeToFind;
        public string MpsCodeToFind
        {
            get { return _mpsCodeToFind; }
            set { _mpsCodeToFind = value; OnPropertyChanged(); }
        }

        ObservableCollection<RegistrationMpsView> _registeredMps;
        public ObservableCollection<RegistrationMpsView> RegisteredMps
        {
            get { return _registeredMps; }
            set { _registeredMps = value; OnPropertyChanged(); }
        }

        public RegisterViewModel()
        {
            
            OpenRegistrationWindowCommand = new RelayCommand(ExecuteShowDialog);
            SearchMpsCommand = new RelayCommand(SearchMps);
            UpdateMpsCommand = new RelayCommand(UpdateSelectedMps);
            DisplayAllMpsCommand = new RelayCommand(DisplayAllMps);

            InitialiazeDataCollections();

        }

        /// <summary>
        /// Execute dialogWindow, and handle dialog results
        /// </summary>
        void ExecuteShowDialog()
        {
            _dialogService.ShowDialog("CreateRegisterMps", (result,mpsToRegister) =>
            {
                
                if (result.ToString() == "True")
                {
                    AddNewMps((RegistrationMpsView)mpsToRegister);                    
                }
            });
        }

        /// <summary>
        /// Initialize dataCollection from DB
        /// </summary>
        void InitialiazeDataCollections()
        {
            using (var dbContext = new MpsContext())
            {
                _registeredMps = new ObservableCollection<RegistrationMpsView>(dbContext.RegistrationMpsViews.ToList());
                MpsTypeList = dbContext.TypeMps.Select(x => x.TypeMps).ToList();
                MpsMeasureList = dbContext.UnitMeasurementsMps.Select(x => x.NameMeasurements).ToList();
                SupplierList = dbContext.SupplierMps.Select(x => x.NameCompany).ToList();
            }
        }
        /// <summary>
        /// add new mps record to DB and observable collection
        /// </summary>
        /// <param name="mpsToRegister"></param>
        void AddNewMps(RegistrationMpsView mpsToRegister)
        {
            using (var dbContext = new MpsContext())
            {
                IncrementMpsId(mpsToRegister);

                dbContext.RegistrationMpsViews.Add(mpsToRegister);
                dbContext.SaveChanges();

                _registeredMps.Add(dbContext.RegistrationMpsViews.OrderBy(x => x.IdMps).Last());
            }
        }

        /// <summary>
        /// To prevent ConcurrencyException increment mps_id manually
        /// </summary>
        /// <param name="newMps"></param>
        void IncrementMpsId(RegistrationMpsView newMps)
        {
            newMps.IdMps = ++_registeredMps.Last().IdMps;
        }
        /// <summary>
        /// Display all mps
        /// </summary>
        void DisplayAllMps()
        {
            _registeredMps.Clear();
            AddDataFromDbToCollection();
        }

        /// <summary>
        /// Add data from DBSet to ObservableCollection
        /// </summary>
        void AddDataFromDbToCollection()
        {
            using (var dbContext = new MpsContext())
            {
                foreach (var item in dbContext.RegistrationMpsViews)
                {
                    _registeredMps.Add(item);
                }
            }
        }

        /// <summary>
        /// Search mps by code
        /// </summary>
        void SearchMps()
        {
            var foundMps = _registeredMps.FirstOrDefault(x => x.CodeMps == _mpsCodeToFind);

            _registeredMps.Clear();
            _registeredMps.Add(foundMps);

        }
        /// <summary>
        /// Update modified mps object to DB
        /// </summary>
        void UpdateSelectedMps()
        {
            using (var dbContext = new MpsContext())
            {
                dbContext.Update(_selectedMps);
                dbContext.SaveChanges();
            }
        }

    }
```












