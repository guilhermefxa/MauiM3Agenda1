using SQLite;

namespace MauiM3Agenda1.Models
{
    public class Produto
    {
        // Campo privado para armazenar a descrição do produto
        private string _descricao;

        // Define a chave primária do banco de dados com incremento automático
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Propriedade para a descrição do produto
        public string Descricao
        {
            get => _descricao;
            set
            {
                // Validação para garantir que a descrição não seja nula
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

                _descricao = value;
            }
        }

        // Propriedade para a quantidade do produto
        public double Quantidade { get; set; }

        // Propriedade para o preço unitário do produto
        public double Preco { get; set; }

        // Propriedade calculada que retorna o total (Quantidade * Preço)
        public double Total { get => Quantidade * Preco; }
    }
}
