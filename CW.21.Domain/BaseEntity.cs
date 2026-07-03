namespace CW._21.Domain;

public abstract class BaseEntity : IAudible
{
    protected BaseEntity()
    {
    }

    public int Id { get;  set; }
    public DateTime CreatedAt {  get;  set; } = DateTime.UtcNow;
    public DateTime ModifiedAt {  get;  set; }
    public bool IsDeleted { get;  set; } = false;
    public void SoftDelete()
    {
        IsDeleted = true;
    }
    public void Update()
    {
        ModifiedAt= DateTime.UtcNow;
    }
}
