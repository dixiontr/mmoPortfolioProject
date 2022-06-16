namespace mmo.Domain.Common
{

    public abstract class aBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        
    }

}