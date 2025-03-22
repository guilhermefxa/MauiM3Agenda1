using MauiM3Agenda1.Helpers;

namespace MauiM3Agenda1
{
    public partial class App : Application
    {
        // Declara uma variável estática para armazenar a instância do SQLiteDatabaseHelper.
        // Essa abordagem implementa o padrão Singleton, garantindo que apenas uma instância seja criada.
        static SQLiteDatabaseHelper _db;

        // Propriedade pública estática para acessar a instância do SQLiteDatabaseHelper.
        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Verifica se a instância ainda não foi criada.
                if (_db == null)
                {
                    // Cria o caminho completo para o arquivo do banco de dados.
                    // O arquivo será armazenado na pasta de dados locais da aplicação.
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    // Inicializa a instância do SQLiteDatabaseHelper passando o caminho do banco de dados.
                    _db = new SQLiteDatabaseHelper(path);
                }
                // Retorna a instância já criada ou recém-inicializada.
                return _db;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}