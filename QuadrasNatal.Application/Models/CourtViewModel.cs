

using QuadrasNatal.Core.Entities;


namespace QuadrasNatal.Application.Models
{
    public class CourtViewModel
    {
        public CourtViewModel(int id, string nome, string descricao, string tipoSuperficie, bool cobertura, bool iluminacao, bool disponivel, List<Comment> comments)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            TipoSuperficie = tipoSuperficie;
            Cobertura = cobertura;
            Iluminacao = iluminacao;
            Disponivel = disponivel;
            Comments = comments.Select(c => c.Content).ToList();
    
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string TipoSuperficie { get; private set; }
        public bool Cobertura { get; private set; }
        public bool Iluminacao { get; private set; }
        public bool Disponivel { get; private set; }

        public List<string> Comments { get; private set; }

        public static CourtViewModel FromEntity(Court entity) 
            =>  new (entity.Id, entity.Name, entity.Description, 
            entity.SurfaceType, entity.HasCover, entity.Lighting, 
            entity.Available, entity.Comments);
    }   
}