namespace hai123.Repositories.Repository;

public interface IEntity 
{
    public int Id { get; set; }
    
}

public interface IdAutableEntity
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public String? Creator { get; set; }
    public String? Updater { get; set; }
}
    